using System.Runtime.InteropServices;
using System.Text;

namespace pvfLoaderXinyu;

/// <summary>
/// 头文件内容，没什么好说的
/// </summary>
public struct PvfHeader
{
    public int sizeGUID; //Always 0x24
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x24)]
    public byte[] GUID;
    public int fileVersion;
    public int dirTreeLength;//头文件占用字节大小
    public int dirTreeChecksum;//CRC32码
    public int numFilesInDirTree;//PVF文件总数
}


public class HeaderTreeNode
{
    public byte[] unpackedFileByteArr;
    public int filePathLength;
    public int relativeOffset;
    public int fileLength;
    public int computedFileLength;
    public string filePathName;
    public uint fileNumber;
    public uint fileCrc32;

    public int ReadNodeFromBitArrStream(PvfHeader header, FileStream fs, byte[] unpackedHeaderTree, int offsite)
    {
        try
        {
            fileNumber = BitConverter.ToUInt32(unpackedHeaderTree, offsite);
            filePathLength = BitConverter.ToInt32(unpackedHeaderTree, offsite + 4);
            byte[] filePath = new byte[filePathLength];
            Array.Copy(unpackedHeaderTree, offsite + 8, filePath, 0, filePathLength);
            fileLength = BitConverter.ToInt32(unpackedHeaderTree, offsite + filePathLength + 8);
            fileCrc32 = BitConverter.ToUInt32(unpackedHeaderTree, offsite + filePathLength + 12);
            relativeOffset = BitConverter.ToInt32(unpackedHeaderTree, offsite + filePathLength + 0x10);
            if (fileLength > 0)
            {
                computedFileLength = (int)((fileLength + 3L) & 4294967292L);
                unpackedFileByteArr = new byte[computedFileLength];
                fs.Seek(Marshal.SizeOf(typeof(PvfHeader)) + header.dirTreeLength + relativeOffset, SeekOrigin.Begin);
                fs.Read(unpackedFileByteArr, 0, computedFileLength);
                Util.UnpackHeaderTree(ref unpackedFileByteArr, computedFileLength, fileCrc32);
                for (int i = 0; i < (computedFileLength - fileLength); i++)
                {
                    unpackedFileByteArr[fileLength + i] = 0;
                }
            }
            //filePathName = Encoding.GetEncoding("gb2312").GetString(filePath).TrimEnd(new char[1]);//CP949(韩语)
            filePathName = Encoding.GetEncoding(0x3b5).GetString(filePath).TrimEnd(new char[1]);//CP949(韩语)
            return filePathLength + 20;
        }
        catch
        {
            return -1;
        }
    }
}
