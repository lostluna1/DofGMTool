using System.Text;

namespace pvfLoaderXinyu;

public class PvfFile : IDisposable
{
    /// <summary>
    /// PVF文件头
    /// </summary>
    private PvfHeader header;

    /// <summary>
    /// 文件流，用于读取pvf文件
    /// </summary>
    private readonly FileStream fs;

    /// <summary>
    /// 文件索引字典，键为文件完整路径，值为文件索引对象
    /// </summary>
    public Dictionary<string, HeaderTreeNode> headerTreeCache = new();

    /// <summary>
    /// stringtable.bin文件的索引键值关系，键为数字索引，值为字符串
    /// </summary>
    public Dictionary<int, string> stringBinMap = new();

    /// <summary>
    /// n_string.lst文件的索引键值关系，键值均为字符串
    /// </summary>
    public Dictionary<string, string> nStringMap = new();
    static PvfFile()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
    /*
        pvf共分三部分：Header头，Tree文件索引头，文件内容数据，本类中：
        使用struct PvfHeader{}来存储Header头，在本类中为header对象
        使用Dictionary<string, HeaderTreeNode> headerTreeCache来存储Tree文件索引头，键为文件索引的文件名，值为索引对象
        使用HeaderTreeNode的索引对象存储文件内容，详情请看本类构造方法。
    */
    public PvfFile(string file)//本构造方法使用后需dispose释放内存，构造过程请放到线程中异步调用。
    {
        //打开文件
        fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
        //读取pvf文件头结构体到header变量
        header = (PvfHeader)Util.ReadFileAsType(fs, typeof(PvfHeader));
        ////获取文件索引列表字节总大小
        //int headLength = header.dirTreeLength;
        //分配内存
        byte[] decryptedTree = new byte[header.dirTreeLength];
        //读取文件索引列表
        fs.Read(decryptedTree, 0, header.dirTreeLength);
        //解密，解密后的字节数组为decryptedTree
        Util.UnpackHeaderTree(ref decryptedTree, header.dirTreeLength, (uint)header.dirTreeChecksum);
        //模拟读取字节数组的指针
        int pos = 0;
        for (int i = 0; i < header.numFilesInDirTree; i++)
        {
            HeaderTreeNode item = new();
            //从pos位置开始读取HeaderTreeNode对象，返回值为指针应该偏移的字节数
            int a = item.ReadNodeFromBitArrStream(header, fs, decryptedTree, pos);
            if (a < 0)
                throw new Exception("读取错误，格式非法");//读取错误直接报错

            //指针后移
            pos += a;
            //把对象放入字典，以文件名为键
            headerTreeCache[item.filePathName] = item;
        }
        //读取stringtable.bin文件创建stringtable索引
        LoadStringTableBin(headerTreeCache["stringtable.bin"].unpackedFileByteArr);
        //读取n_string.lst文件创建n_string索引
        LoadNStringLst(headerTreeCache["n_string.lst"].unpackedFileByteArr);
    }

    private void LoadStringTableBin(byte[] unpackedFileByteArr)
    {
        //文件的第一位int是索引总数
        int count = BitConverter.ToInt32(unpackedFileByteArr, 0);

        for (int i = 0; i < count; i++)
        {
            //每次循环的第一个int是键开始的地址
            int startpos = BitConverter.ToInt32(unpackedFileByteArr, (i * 4) + 4);
            //每次循环的第二个int是键结束的地址
            int endpos = BitConverter.ToInt32(unpackedFileByteArr, (i * 4) + 8);
            //相减就是值的长度
            int len = endpos - startpos;
            //索引就是出现的第几个
            int index = i;
            //分配内存以存储该值的字符串
            byte[] pathBytes = new byte[len];
            //取出该字符串内容
            Array.Copy(unpackedFileByteArr, startpos + 4, pathBytes, 0, len);
            //解码，这里使用的是BIG5，对于某些文件不一定正确，如果需要更正可以在这个编码这里下手。
            string pathName = Encoding.GetEncoding("BIG5").GetString(pathBytes).TrimEnd(new char[1]);
            //放到索引表中备用
            stringBinMap[index] = pathName;
        }
    }
    private void LoadNStringLst(byte[] unpackedFileByteArr)
    {
        //第一位一定是53424，如果不是那你pvf有问题
        if (BitConverter.ToUInt16(unpackedFileByteArr, 0) != 53424)
            return;

        //从第二位开始每次读取十个字节
        for (int i = 2; i < unpackedFileByteArr.Length; i += 10)
        {
            //如果是最后十个字节或者最后不满十个字节就不执行
            if (unpackedFileByteArr.Length - i >= 10)
            {
                //前6位干嘛的不知道，6-10位的int值是stringtable的键，取出来
                string k = stringBinMap[BitConverter.ToInt32(unpackedFileByteArr, i + 6)];
                //取出来的stringtable的值是文件列表的一个文件的文件名，不过使用了驼峰命名需要将其置为小写并清除空格。

                HeaderTreeNode node = headerTreeCache[k.ToLower().Trim()];
                //如果找到了这个文件
                if (node != null)
                {
                    //直接用编码取这个文件的内容
                    string full = Encoding.GetEncoding("BIG5").GetString(node.unpackedFileByteArr).TrimEnd(new char[1]);

                    //根据换行分割，逐行遍历
                    foreach (string line in full.Split(new char[2] { '\r', '\n' }))
                    {
                        //行包含符号'>'，如name_xxx>格斗家
                        if (line.Contains('>'))
                        {
                            //取键 name_xxx
                            string key = Util.FindTagKeyVal(line, "", ">");
                            //取值 格斗家
                            string val = Util.FindTagKeyVal(line, ">", "");
                            //放到索引表中备用
                            if (key.Length > 0 && val.Length > 0)
                                nStringMap[key] = val;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 根据文件名返回文件内容
    /// </summary>
    /// <param name="path"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public string? GetPvfFileByPath(string path, Encoding encoding)
    {
        HeaderTreeNode node = headerTreeCache[path.ToLower().Trim()];
        if (node == null)
            return null;
        return GetPvfFileByPath(node, encoding);
    }

    /// <summary>
    /// 根据文件索引对象返回文件内容
    /// </summary>
    /// <param name="node"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public string GetPvfFileByPath(HeaderTreeNode node, Encoding encoding)
    {
        //直接取解密内容
        byte[] unpackedStrBytes = node.unpackedFileByteArr;
        //导出文本的偏移指针
        int strpos = 0;
        //导出文本的字典，键为偏移，值为字符串的字节形式，如0=>字符串AAA,3=>字符串BBB，整个字符串为AAABBB，AAA的基址为0，BBB的基址为3
        Dictionary<int, byte[]> arr = new();

        byte[] bts = encoding.GetBytes("#PVF_File\r\n");
        //开头加上一行#PVF_File
        arr.Add(strpos, bts);
        //指针向后移动
        strpos = bts.Length;

        //文件结构为：byte[2](0xb0,0xd0打开好多文件这里都是这个值，猜测应该是固定的)byte[1]int[1]byte[1]int[1]byte[1]...以此循环，byte[1]为指示符，int[1]占四位为一个数字，具体意义需要看指示位
        if (unpackedStrBytes.Length >= 7)//如果总字节长度>=7
        {
            for (int i = 2; i < unpackedStrBytes.Length; i += 5)//以5为单步从第二位开始遍历字节
            {
                //string s = encoding.GetString(numArray).TrimEnd(new char[1]);
                if (unpackedStrBytes.Length - i >= 5)//到最后了就不处理了防止内存越界
                {
                    //猜测应该是内容指示位
                    byte currentByte = unpackedStrBytes[i];
                    //如果这个字节是这些中的一个进行对应的特殊处理，如果不是那就没有字符串
                    if (currentByte is 2 or 4 or 5 or 6 or 7 or 8 or 10)
                    {
                        //取该指示位后面的整数
                        int after1 = BitConverter.ToInt32(unpackedStrBytes, i + 1);
                        if (currentByte == 10)//这个字符是10时
                        {
                            //取指示位前面的整数
                            int before1 = BitConverter.ToInt32(unpackedStrBytes, i - 4);

                            //解释字符串内容的方法已集成到unpackSpecialChr(指示位,后一位整数,前一位整数)中
                            //获取该指示位代表的字符串
                            bts = Encoding.UTF8.GetBytes(string.Concat(UnpackSpecialChr(currentByte, after1, before1), "\r\n"));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                        //这个字符是7时
                        else if (currentByte == 7)
                        {
                            //7不需要前一位整数，外面要套上“``”
                            bts = Encoding.UTF8.GetBytes(string.Concat("`", UnpackSpecialChr(currentByte, after1, 0), "`\r\n"));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                        //这个字符是2或者4时，末尾不是换行而是制表符\t
                        else if (currentByte is 2 or 4)
                        {
                            bts = Encoding.UTF8.GetBytes(string.Concat(UnpackSpecialChr(currentByte, after1, 0), "\t"));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                        //{指示位=`stringbin[后面的整数]`}
                        else if (currentByte is 6 or 8)
                        {
                            string[] str = new string[] { "{", currentByte.ToString(), "=`", UnpackSpecialChr(currentByte, after1, 0), "`}\r\n" };
                            bts = encoding.GetBytes(string.Concat(str));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                        //是5的情况，stringbin[后面的整数]
                        else if (currentByte == 5)
                        {
                            bts = Encoding.UTF8.GetBytes(string.Concat("\r\n", UnpackSpecialChr(currentByte, after1, 0), "\r\n"));
                            arr.Add(strpos, bts);
                            strpos += bts.Length;
                        }
                    }
                }
            }
            //末尾添个换行符
            bts = encoding.GetBytes("\r\n");
            arr.Add(strpos, bts);
            strpos += bts.Length;
        }
        //创建一个正好大小的字节数组
        byte[] bytes = new byte[strpos];
        foreach (int pos in arr.Keys)
            for (int i = 0; i < arr[pos].Length; i++)
                //使用导出文本的字典填充字节数组
                bytes[i + pos] = arr[pos][i];

        //释放内存
        arr.Clear();

        //转换成文本
        string str1 = encoding.GetString(bytes).TrimEnd(new char[1]);
        return str1;
    }

    private string UnpackSpecialChr(byte curr, int after1, int before1)
    {
        switch (curr)
        {
            case 2:
                //int型数
                return after1.ToString();
            case 4:
                //4为float型数
                return BitConverter.ToSingle(BitConverter.GetBytes(after1), 0).ToString("f6");
            case 5:
            case 6:
            case 7:
            case 8:
                if (stringBinMap.ContainsKey(after1))
                    //字符串类型，字符串数据存在stringtable.bin里
                    return stringBinMap[after1];
                return "";
            case 10:
                if (!stringBinMap.ContainsKey(after1))
                    return "";

                //字符串类型，字符串数据存在stringtable.bin里
                string str = stringBinMap[after1];

                //<指示符前面的数字::字符串`nstring[指示符前面的数字]`>
                string[] strArrays = new string[] { "<", before1.ToString(), "::", str, "`", GetNString(str), "`>" };
                return string.Concat(strArrays);
        }
        return "";
    }

    private string GetNString(string str)
    {
        if (nStringMap.ContainsKey(str))
            return nStringMap[str];
        return "";
    }

    public void Dispose()
    {
        headerTreeCache = new Dictionary<string, HeaderTreeNode>();
        stringBinMap = new Dictionary<int, string>();
        nStringMap = new Dictionary<string, string>();
        fs.Close();
        fs.Dispose();
    }
}
