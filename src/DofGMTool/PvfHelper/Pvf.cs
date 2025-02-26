using System.Diagnostics;
using System.Text;

namespace pvfLoaderXinyu;

public class PvfFile : IDisposable
{
    private PvfHeader header;
    private readonly FileStream fs;
    public Dictionary<string, HeaderTreeNode> headerTreeCache = [];
    public Dictionary<int, string> stringBinMap = [];
    public Dictionary<string, string> nStringMap = [];
    public string fileName = "";

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
        if (BitConverter.ToUInt16(unpackedFileByteArr, 0) != 53424)//第一位一定是53424，如果不是那你pvf有问题
            return;
        for (int i = 2; i < unpackedFileByteArr.Length; i += 10)//从第二位开始每次读取十个字节
        {
            if (unpackedFileByteArr.Length - i >= 10)//如果是最后十个字节或者最后不满十个字节就不执行
            {
                string k = stringBinMap[BitConverter.ToInt32(unpackedFileByteArr, i + 6)];//前6位干嘛的不知道，6-10位的int值是stringtable的键，取出来
                HeaderTreeNode node = headerTreeCache[k.ToLower().Trim()];//取出来的stringtable的值是文件列表的一个文件的文件名，不过使用了驼峰命名需要将其置为小写并清除空格。
                if (node != null)//如果找到了这个文件
                {
                    string full = Encoding.GetEncoding("BIG5").GetString(node.unpackedFileByteArr).TrimEnd(new char[1]);//直接用编码取这个文件的内容
                    foreach (string line in full.Split(new char[2] { '\r', '\n' }))//根据换行分割，逐行遍历
                    {
                        if (node.filePathName == "character/common/jacket/leather/vest_crleather.equ")
                        {
                            Debug.WriteLine(line);
                        }
                        if (line.IndexOf('>') >= 0)//行包含符号'>'，如name_xxx>格斗家
                        {
                            string key = Util.FindTagKeyVal(line, "", ">");//取键 name_xxx
                            string val = Util.FindTagKeyVal(line, ">", "");//取值 格斗家
                            if (key.Length > 0 && val.Length > 0)
                            {
                                string uniqueKey = $"{k.ToLower().Trim()}_{key}";//将文件路径和键组合成唯一键
                                nStringMap[uniqueKey] = val;//放到索引表中备用
                            }
                        }
                    }
                }
            }
        }
        return;
    }

    public string? GetPvfFileByPath(string path, Encoding encoding)
    {
        return headerTreeCache.TryGetValue(path.ToLower().Trim(), out HeaderTreeNode? node) ? GetPvfFileByPath(node, encoding) : null;
    }

    public string GetPvfFileByPath(HeaderTreeNode node, Encoding encoding)
    {
        fileName = string.Empty;
        fileName = node.filePathName;
        byte[] unpackedStrBytes = node.unpackedFileByteArr;
        int strpos = 0;
        Dictionary<int, byte[]> arr = [];
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
        foreach (KeyValuePair<int, byte[]> kvp in arr)
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
        string strPrefix = fileName.Split('/')[0];
        foreach (KeyValuePair<string, string> item in nStringMap)
        {
            if (item.Key.Contains(str) && item.Key.Split('/')[0] == strPrefix)
            {
                return item.Value;
            }
        }
        return "";
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
