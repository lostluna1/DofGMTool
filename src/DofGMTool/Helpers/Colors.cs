using DofGMTool.Enums;
using System.Drawing;

namespace DofGMTool.Helpers;
public static class Npk_Colors
{
    public const int Argb1555 = 0x0e;
    public const int Argb4444 = 0x0f;
    public const int Argb8888 = 0X10;

    /// <summary>
    ///     将所有ARGB类型的数据转换为ARGB_8888的字节数组
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static void ReadColor(Stream stream, int bits, byte[] target, int offset)
    {
        byte[] bs = new byte[4];
        if (bits == Argb8888)
        {
            stream.Read(bs, 0, 4);
            bs.CopyTo(target, offset);
            return;
        }
        byte a = 0;
        byte r = 0;
        byte g = 0;
        byte b = 0;
        stream.Read(bs, 0, 2);
        switch (bits)
        {
            case Argb1555:
                a = (byte)(bs[1] >> 7);
                r = (byte)((bs[1] >> 2) & 0x1f);
                g = (byte)((bs[0] >> 5) | ((bs[1] & 3) << 3));
                b = (byte)(bs[0] & 0x1f);
                a = (byte)(a * 0xff);
                r = (byte)((r << 3) | (r >> 2));
                g = (byte)((g << 3) | (g >> 2));
                b = (byte)((b << 3) | (b >> 2));
                break;
            case Argb4444:
                a = (byte)(bs[1] & 0xf0);
                r = (byte)((bs[1] & 0xf) << 4);
                g = (byte)(bs[0] & 0xf0);
                b = (byte)((bs[0] & 0xf) << 4);
                break;
        }
        target[offset + 0] = b;
        target[offset + 1] = g;
        target[offset + 2] = r;
        target[offset + 3] = a;
    }

    public static void ReadColor(Stream stream, ColorBits bits, byte[] target, int offset)
    {
        ReadColor(stream, (int)bits, target, offset);
    }

    public static byte[] ReadColor(Stream stream, int bits)
    {
        byte[] target = new byte[4];
        ReadColor(stream, bits, target, 0);
        return target;
    }

    public static byte[] ReadColor(Stream stream, ColorBits bits)
    {
        return ReadColor(stream, (int)bits);
    }

    /// <summary>
    ///     将ARGB1555和ARGB4444转换为ARGB8888
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="data"></param>
    /// <param="bits"></param>
    public static void WriteColor(Stream stream, byte[] data, ColorBits bits)
    {
        if (bits == ColorBits.ARGB_8888)
        {
            stream.Write(data, 0, data.Length);
            return;
        }
        byte a = data[3];
        byte r = data[2];
        byte g = data[1];
        byte b = data[0];
        int left = 0;
        int right = 0;
        switch (bits)
        {
            case ColorBits.ARGB_1555:
                a = (byte)(a >> 7);
                r = (byte)(r >> 3);
                g = (byte)(g >> 3);
                b = (byte)(b >> 3);
                left = (byte)(((g & 7) << 5) | b);
                right = (byte)((a << 7) | (r << 2) | (g >> 3));
                break;
            case ColorBits.ARGB_4444:
                left = g | (b >> 4);
                right = a | (r >> 4);
                break;
        }
        stream.WriteByte((byte)left);
        stream.WriteByte((byte)right);
    }

    /// <summary>
    ///     写入一个颜色
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="color"></param>
    /// <param name="bits"></param>
    public static void WriteColor(this Stream stream, Color color, ColorBits bits)
    {
        byte[] data = { color.B, color.G, color.R, color.A };
        WriteColor(stream, data, bits);
    }

    /// <summary>
    ///     读取一个指定数量的色表
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static IEnumerable<Color> ReadPalette(Stream stream, int count)
    {
        for (int i = 0; i < count; i++)
        {
            byte[] data = new byte[4];
            stream.Read(data, 0, data.Length);
            yield return Color.FromArgb(data[3], data[0], data[1], data[2]);
        }
    }

    public static void WritePalette(Stream stream, IEnumerable<Color> table)
    {
        var list = table.ToList();
        foreach (Color color in list)
        {
            byte[] data = { color.R, color.G, color.B, color.A };
            stream.Write(data, 0, data.Length);
        }
    }

    public static string ToHexString(this Color color)
    {
        int val = color.ToArgb();
        string str = val.ToString("x2");
        for (int i = str.Length; i < 8; i++)
        {
            str = "0" + str;
        }
        return $"#{str}";
    }
}
