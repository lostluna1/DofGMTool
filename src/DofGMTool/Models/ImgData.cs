namespace DofGMTool.Models;
public class ImgData
{
    /// <summary>
    /// 16
    /// </summary>
    public byte[] FlagBytes { get; set; }
    public string FlagStr { get; set; }
    /// <summary>
    /// 4
    /// </summary>
    public byte[] DataLengthBytes { get; set; }
    public uint DataLength { get; set; }
    /// <summary>
    /// 4 保留位
    /// </summary>
    public byte[] SafeBytes { get; set; }

    /// <summary>
    /// 4
    /// </summary>
    public byte[] ImgVerBytes { get; set; }
    public uint ImgVer { get; set; }

    /// <summary>
    /// 4
    /// 图像数量
    /// </summary>
    public byte[] ImgCountBytes { get; set; }
    public uint ImageCount { get; set; }

    public byte[] ImageData { get; }

    public ImgData(byte[] imageData)
    {
        ImageData = imageData;
        int startIndex = 0;

        //
        byte[] imgTypeBytes = new byte[4];
        Array.Copy(imageData, startIndex, imgTypeBytes, 0, imgTypeBytes.Length);
        startIndex += imgTypeBytes.Length;

        // 帧号
        byte[] frameNoBytes = new byte[4];
        Array.Copy(imageData, startIndex, frameNoBytes, 0, frameNoBytes.Length);
        startIndex += frameNoBytes.Length;
        uint frameNo = BitConverter.ToUInt32(frameNoBytes);
    }
}