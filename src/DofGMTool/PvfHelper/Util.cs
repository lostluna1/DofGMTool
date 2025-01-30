using System.Runtime.InteropServices;

namespace pvfLoaderXinyu;

internal class Util
{
    public static object? ReadFileAsType(FileStream fs, Type struct1)//从文件流中读取结构体，详细使用方法看引用就好了。。。
    {
        int size = Marshal.SizeOf(struct1);
        byte[] buffer = new byte[size];
        fs.Read(buffer, 0, size);
        return RawDes(buffer, struct1);
    }
    public static object? RawDes(byte[] rawdatas, Type anytype)
    {
        int rawsize = Marshal.SizeOf(anytype);
        if (rawsize > rawdatas.Length)
            return null;
        nint buffer = Marshal.AllocHGlobal(rawsize);
        Marshal.Copy(rawdatas, 0, buffer, rawsize);
        object? retobj = Marshal.PtrToStructure(buffer, anytype);
        Marshal.FreeHGlobal(buffer);
        return retobj;
    }

    public static void UnpackHeaderTree(ref byte[] byteArr, int fileLen, uint crc32)//解密算法，从IDA直接解释过来的
    {
        uint passwd = 0x81A79011;
        int index = 0;
        while (index < fileLen)
        {
            Array.Copy(BitConverter.GetBytes(ROR4(BitConverter.ToUInt32(byteArr, index) ^ passwd ^ crc32, 6)), 0, byteArr, index, 4);
            index += 4;
        }
    }
    public static uint ROR4(uint uint_0, int int_1)
    {
        return (uint_0 >> int_1) | (uint_0 << (32 - int_1));
    }

    public static string FindTagKeyVal(string line, string a, string b)//emmm这个从字符串a>b里提取a和b的方法就不用解释了吧。。。
    {
        int index = 0;
        if (a != "")
            index = line.IndexOf(a, StringComparison.Ordinal);//如果a不为空在行中搜索a
        if (index == -1)
            return "";
        index += a.Length;
        string str = line[index..];//对line提取a后面的部分
        if (b == "")
            return str;
        int num = str.IndexOf(b, StringComparison.Ordinal);
        return num == -1 ? "" : str[..num];
    }
}
