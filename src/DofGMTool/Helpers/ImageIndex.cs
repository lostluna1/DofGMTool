namespace DofGMTool.Helpers;
public class ImageIndex
{
    /// <summary>
    /// 4
    /// </summary>
    public byte[] ColorBytes { get; set; }
    /// <summary>
    /// 4
    /// </summary>
    public byte[] ZibBytes { get; set; }
    public bool IsZib { get; set; }
    /// <summary>
    /// 4
    /// </summary>
    public byte[] WidthBytes { get; set; }
    public uint Width { get; set; }
    /// <summary>
    /// 4
    /// </summary>
    public byte[] HeightBytes { get; set; }
    public uint Height { get; set; }
    /// <summary>
    /// 4
    /// </summary>
    public byte[] LengthBytes { get; set; }
    public uint Length { get; set; }
    /// <summary>
    /// 4
    /// </summary>
    public byte[] XBytes { get; set; }
    public uint X { get; set; }

    /// <summary>
    /// 4
    /// </summary>
    public byte[] YBytes { get; set; }
    public uint Y { get; set; }

    /// <summary>
    /// 4
    /// </summary>
    public byte[] FrameWidthBytes { get; set; }
    public uint FrameWidth { get; set; }
    /// <summary>
    /// 4
    /// </summary>
    public byte[] FrameHeightBytes { get; set; }
    public uint FrameHeight { get; set; }

    /// <summary>
    /// 4 固定值
    /// </summary>
    public byte[] ImgTypeBytes { get; set; }

    /// <summary>
    /// 4
    /// </summary>
    public byte[] FrameNoBytes { get; set; }

    public uint FrameNo { get; set; }

    public byte[] ImageBytes { get; set; }

    public uint? VectorIndex { get; set; }
}