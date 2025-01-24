using DofGMTool.Models;
using System.Text;

namespace DofGMTool.Helpers;
public class NpkIndex
{
    /// <summary>
    /// 4
    /// </summary>
    public byte[] OffsetBytes { get; set; }
    public uint Offset { get; set; }
    /// <summary>
    /// 4
    /// </summary>
    public byte[] SizeBytes { get; set; }
    public uint Size { get; set; }
    /// <summary>
    /// 256
    /// </summary>
    public byte[] NameBytes { get; set; }
    public string Name { get; set; }

    public byte[] ImageDataBytes { get; private set; }

    public List<ImageIndex> Images { get; } = new();
    public ImgData ImageData { get; }

    public NpkIndex()
    {

    }

    public void ParserImg(byte[] imageDataBytes)
    {
        ImageDataBytes = imageDataBytes;

        int startIndex = 0;
        byte[] flagBytes = new byte[16];
        Array.Copy(imageDataBytes, 0, flagBytes, 0, flagBytes.Length);
        startIndex += flagBytes.Length;
        string flag = Encoding.ASCII.GetString(flagBytes);

        byte[] dataLengthBytes = new byte[4];
        Array.Copy(imageDataBytes, startIndex, dataLengthBytes, 0, dataLengthBytes.Length);
        startIndex += dataLengthBytes.Length;
        uint dataLength = BitConverter.ToUInt32(dataLengthBytes);

        // 保留位
        byte[] safeBytes = new byte[4];
        Array.Copy(imageDataBytes, startIndex, safeBytes, 0, safeBytes.Length);
        startIndex += safeBytes.Length;

        // img 版本
        byte[] imgVerBytes = new byte[4];
        Array.Copy(imageDataBytes, startIndex, imgVerBytes, 0, imgVerBytes.Length);
        startIndex += imgVerBytes.Length;
        uint imgVer = BitConverter.ToUInt32(imgVerBytes);

        // 图像数量内容
        byte[] imgCountBytes = new byte[4];
        Array.Copy(imageDataBytes, startIndex, imgCountBytes, 0, imgCountBytes.Length);
        startIndex += imgCountBytes.Length;
        uint imgCount = BitConverter.ToUInt32(imgCountBytes);
        Images.Clear();
        // 取图像索引
        for (int i = 0; i < imgCount; i++)
        {
            try
            {
                byte[] colorBytes = new byte[4];
                Array.Copy(imageDataBytes, startIndex, colorBytes, 0, colorBytes.Length);
                startIndex += colorBytes.Length;

                // 索引指向型
                if (colorBytes[0] == 17)
                {
                    byte[] vector = new byte[4];
                    Array.Copy(imageDataBytes, startIndex, vector, 0, vector.Length);
                    startIndex += vector.Length;

                    Images.Add(new ImageIndex
                    {
                        VectorIndex = BitConverter.ToUInt32(vector)
                    });

                    continue;
                }

                byte[] zibBytes = new byte[4];
                Array.Copy(imageDataBytes, startIndex, zibBytes, 0, zibBytes.Length);
                startIndex += zibBytes.Length;

                byte[] widthBytes = new byte[4];
                Array.Copy(imageDataBytes, startIndex, widthBytes, 0, widthBytes.Length);
                startIndex += widthBytes.Length;
                uint width = BitConverter.ToUInt32(widthBytes);
                if (Name.Contains("consumption.img") && width != 28)
                {
                }
                byte[] heightBytes = new byte[4];
                Array.Copy(imageDataBytes, startIndex, heightBytes, 0, heightBytes.Length);
                startIndex += heightBytes.Length;
                uint height = BitConverter.ToUInt32(heightBytes);

                // 图像数据长度
                byte[] lengthBytes = new byte[4];
                Array.Copy(imageDataBytes, startIndex, lengthBytes, 0, lengthBytes.Length);
                startIndex += lengthBytes.Length;
                uint length = BitConverter.ToUInt32(lengthBytes);

                byte[] xBytes = new byte[4];
                Array.Copy(imageDataBytes, startIndex, xBytes, 0, xBytes.Length);
                startIndex += xBytes.Length;
                uint x = BitConverter.ToUInt32(xBytes);

                byte[] yBytes = new byte[4];
                Array.Copy(imageDataBytes, startIndex, yBytes, 0, yBytes.Length);
                startIndex += yBytes.Length;
                uint y = BitConverter.ToUInt32(yBytes);

                byte[] frameWidthBytes = new byte[4];
                Array.Copy(imageDataBytes, startIndex, frameWidthBytes, 0, frameWidthBytes.Length);
                startIndex += frameWidthBytes.Length;
                uint frameWidth = BitConverter.ToUInt32(frameWidthBytes);

                byte[] frameHeightBytes = new byte[4];
                Array.Copy(imageDataBytes, startIndex, frameHeightBytes, 0, frameHeightBytes.Length);
                startIndex += frameHeightBytes.Length;
                uint frameHeight = BitConverter.ToUInt32(frameHeightBytes);

                var imgIndex = new ImageIndex
                {
                    ColorBytes = colorBytes,
                    ZibBytes = zibBytes,
                    IsZib = zibBytes[0] == 0x06,
                    WidthBytes = widthBytes,
                    Width = width,
                    Height = height,
                    LengthBytes = lengthBytes,
                    Length = length,
                    XBytes = xBytes,
                    ImgTypeBytes = new byte[4] { 0x11, 0x00, 0x00, 0x00 },
                    X = x,
                    YBytes = yBytes,
                    Y = y,
                    FrameWidthBytes = frameWidthBytes,
                    FrameWidth = frameWidth,
                    FrameHeightBytes = frameHeightBytes,
                    FrameHeight = frameHeight
                };

                Images.Add(imgIndex);
            }
            catch { }
        }

        for (int i = 0; i < Images.Count; i++)
        {
            if (Images[i].VectorIndex != null) continue;
            uint len = Images[i].Length;
            if (len > imageDataBytes.Length) continue;
            if (imageDataBytes.Length - startIndex < len) continue;
            byte[] data = new byte[len];
            Array.Copy(imageDataBytes, startIndex, data, 0, len);
            startIndex += (int)len;

            Images[i].ImageBytes = data;
        }
    }
}