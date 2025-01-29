using System.Diagnostics;
using System.Text;
using Windows.Foundation.Collections;

namespace pvfLoaderXinyu;

public class PvfFile : IDisposable
{
    private PvfHeader header;
    private readonly FileStream fs;
    public Dictionary<string, HeaderTreeNode> headerTreeCache = new();
    public Dictionary<int, string> stringBinMap = new();
    public Dictionary<string, string> nStringMap = new();

    static PvfFile()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    public PvfFile(string file)
    {
        //headerTreeCache.Clear();
        //stringBinMap.Clear();
        //nStringMap.Clear();
        fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
        header = (PvfHeader?)Util.ReadFileAsType(fs, typeof(PvfHeader)) ?? throw new InvalidOperationException("读取错误，格式非法");

        byte[] decryptedTree = new byte[header.dirTreeLength];
        fs.Read(decryptedTree, 0, header.dirTreeLength);
        Util.UnpackHeaderTree(ref decryptedTree, header.dirTreeLength, (uint)header.dirTreeChecksum);
        int pos = 0;
        for (int i = 0; i < header.numFilesInDirTree; i++)
        {
            HeaderTreeNode item = new();
            int a = item.ReadNodeFromBitArrStream(header, fs, decryptedTree, pos);
            if (a < 0)
                throw new Exception("读取错误，格式非法");
            pos += a;

            headerTreeCache[item.filePathName] = item;
        }
        LoadStringTableBin(headerTreeCache["stringtable.bin"].unpackedFileByteArr);
        LoadNStringLst(headerTreeCache["n_string.lst"].unpackedFileByteArr);
    }

    private void LoadStringTableBin(byte[] unpackedFileByteArr)
    {
        int count = BitConverter.ToInt32(unpackedFileByteArr, 0);
        for (int i = 0; i < count; i++)
        {
            int startpos = BitConverter.ToInt32(unpackedFileByteArr, (i * 4) + 4);
            int endpos = BitConverter.ToInt32(unpackedFileByteArr, (i * 4) + 8);
            int len = endpos - startpos;
            byte[] pathBytes = new byte[len];
            Array.Copy(unpackedFileByteArr, startpos + 4, pathBytes, 0, len);
            string pathName = Encoding.GetEncoding("BIG5").GetString(pathBytes).TrimEnd(new char[1]);
            stringBinMap[i] = pathName;
        }
    }

    private void LoadNStringLst(byte[] unpackedFileByteArr)
    {
        if (BitConverter.ToUInt16(unpackedFileByteArr, 0) != 53424)
            return;

        for (int i = 2; i < unpackedFileByteArr.Length; i += 10)
        {
            if (unpackedFileByteArr.Length - i >= 10)
            {
                string k = stringBinMap[BitConverter.ToInt32(unpackedFileByteArr, i + 6)];
                if (headerTreeCache.TryGetValue(k.ToLower().Trim(), out var node))
                {
                    string full = Encoding.GetEncoding("BIG5").GetString(node.unpackedFileByteArr).TrimEnd(new char[1]);
                    foreach (string line in full.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (line.Contains('>'))
                        {
                            string key = Util.FindTagKeyVal(line, "", ">");
                            string val = Util.FindTagKeyVal(line, ">", "");
                            if (key.Length > 0 && val.Length > 0)
                                nStringMap[key] = val;
                        }
                    }
                }
            }
        }
    }

    public string? GetPvfFileByPath(string path, Encoding encoding)
    {
        if (headerTreeCache.TryGetValue(path.ToLower().Trim(), out var node))
        {
            return GetPvfFileByPath(node, encoding);
        }
        return null;
    }

    public string GetPvfFileByPath(HeaderTreeNode node, Encoding encoding)
    {
        byte[] unpackedStrBytes = node.unpackedFileByteArr;
        int strpos = 0;
        Dictionary<int, byte[]> arr = new();
        byte[] bts = encoding.GetBytes("#PVF_File\r\n");
        arr.Add(strpos, bts);
        strpos = bts.Length;

        if (unpackedStrBytes.Length >= 7)
        {
            for (int i = 2; i < unpackedStrBytes.Length; i += 5)
            {
                if (unpackedStrBytes.Length - i >= 5)
                {
                    byte currentByte = unpackedStrBytes[i];
                    if (currentByte is 2 or 4 or 5 or 6 or 7 or 8 or 10)
                    {
                        int after1 = BitConverter.ToInt32(unpackedStrBytes, i + 1);
                        if (currentByte == 10)
                        {
                            int before1 = BitConverter.ToInt32(unpackedStrBytes, i - 4);
                            bts = Encoding.UTF8.GetBytes(string.Concat(UnpackSpecialChr(currentByte, after1, before1), "\r\n"));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                        else if (currentByte == 7)
                        {
                            bts = Encoding.UTF8.GetBytes(string.Concat("`", UnpackSpecialChr(currentByte, after1, 0), "`\r\n"));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                        else if (currentByte is 2 or 4)
                        {
                            bts = Encoding.UTF8.GetBytes(string.Concat(UnpackSpecialChr(currentByte, after1, 0), "\t"));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                        else if (currentByte is 6 or 8)
                        {
                            string[] str = new string[] { "{", currentByte.ToString(), "=`", UnpackSpecialChr(currentByte, after1, 0), "`}\r\n" };
                            bts = encoding.GetBytes(string.Concat(str));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                        else if (currentByte == 5)
                        {
                            bts = Encoding.UTF8.GetBytes(string.Concat("\r\n", UnpackSpecialChr(currentByte, after1, 0), "\r\n"));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                    }
                }
            }
            bts = encoding.GetBytes("\r\n");
            arr.Add(strpos, bts);
            strpos += bts.Length;
        }

        byte[] bytes = new byte[strpos];
        foreach (var kvp in arr)
        {
            Array.Copy(kvp.Value, 0, bytes, kvp.Key, kvp.Value.Length);
        }

        arr.Clear();
        return encoding.GetString(bytes).TrimEnd(new char[1]);
    }

    private string UnpackSpecialChr(byte curr, int after1, int before1)
    {
        return curr switch
        {
            2 => after1.ToString(),
            4 => BitConverter.ToSingle(BitConverter.GetBytes(after1), 0).ToString("f6"),
            5 or 6 or 7 or 8 => stringBinMap.ContainsKey(after1) ? stringBinMap[after1] : "",
            10 => stringBinMap.ContainsKey(after1) ? GetNString(stringBinMap[after1]) : "",
            _ => "",
        };
    }

    private string GetNString(string str)
    {
        return nStringMap.ContainsKey(str) ? nStringMap[str] : "";
    }

    public void Dispose()
    {
        headerTreeCache.Clear();
        stringBinMap.Clear();
        nStringMap.Clear();
        fs.Close();
        fs.Dispose();
    }
}
