namespace DofGMTool.Models;
public struct NpkHeader
{
    /// <summary>
    /// 16
    /// </summary>
    public byte[] FlagBytes { get; set; }
    public string FlagStr { get; set; }
    public byte[] CountBytes { get; set; }
    public int Count { get; set; }
}