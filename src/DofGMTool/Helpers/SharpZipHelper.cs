using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace DofGMTool.Helpers;
public class SharpZipHelper
{
    public static byte[] SharpZipLibDecompress(byte[] data)
    {
        var compressed = new MemoryStream(data);
        var decompressed = new MemoryStream();
        var inputStream = new InflaterInputStream(compressed);
        inputStream.CopyTo(decompressed);
        return decompressed.ToArray();
    }
    public static byte[] SharpZipLibCompress(byte[] data)
    {
        var compressed = new MemoryStream();
        var outputStream = new DeflaterOutputStream(compressed);
        outputStream.Write(data, 0, data.Length);
        outputStream.Close();
        return compressed.ToArray();
    }
}