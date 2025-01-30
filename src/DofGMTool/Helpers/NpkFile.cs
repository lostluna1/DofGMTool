using DofGMTool.Models;
using System.Text;

namespace DofGMTool.Helpers;
public class NpkFile
{
    private static string checkString = "puchikon@neople dungeon and fighter DNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNF ";
    private static byte[] checkBytes = Encoding.ASCII.GetBytes(checkString);

    public List<NpkIndex> NpkFiles { get; set; } = [];

    public NpkFile(string filePath)
    {
        NpkFiles.Clear();
        using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        byte[] fileBytes = new byte[fs.Length];
        fs.Read(fileBytes, 0, fileBytes.Length);
        fs.Close();

        int startIndex = 0;
        byte[] flagBytes = new byte[16];
        Array.Copy(fileBytes, startIndex, flagBytes, 0, flagBytes.Length);
        startIndex = flagBytes.Length;

        byte[] countBytes = new byte[4];
        Array.Copy(fileBytes, startIndex, countBytes, 0, countBytes.Length);
        startIndex += countBytes.Length;

        var header = new NpkHeader
        {
            FlagBytes = flagBytes,
            FlagStr = Encoding.ASCII.GetString(flagBytes),
            CountBytes = countBytes,
            Count = BitConverter.ToInt32(countBytes)
        };

        int checkCodeLength = 32 * header.Count;

        // 循环读取img文件
        for (int i = 0; i < header.Count; i++)
        {
            byte[] offsetBytes = new byte[4];
            Array.Copy(fileBytes, startIndex, offsetBytes, 0, offsetBytes.Length);
            startIndex += offsetBytes.Length;

            byte[] sizeBytes = new byte[4];
            Array.Copy(fileBytes, startIndex, sizeBytes, 0, sizeBytes.Length);
            startIndex += sizeBytes.Length;

            byte[] nameBytes = new byte[256];
            Array.Copy(fileBytes, startIndex, nameBytes, 0, nameBytes.Length);
            startIndex += nameBytes.Length;

            byte[] imgDataBytes = new byte[BitConverter.ToUInt32(sizeBytes)];
            Array.Copy(fileBytes, BitConverter.ToUInt32(offsetBytes), imgDataBytes, 0, imgDataBytes.Length);

            var nkpIndex = new NpkIndex
            {
                OffsetBytes = offsetBytes,
                Offset = BitConverter.ToUInt32(offsetBytes),
                SizeBytes = sizeBytes,
                Size = BitConverter.ToUInt32(sizeBytes),
                NameBytes = nameBytes,
                Name = DecodeName(nameBytes).Trim()
            };
            nkpIndex?.ParserImg(imgDataBytes);
            if (nkpIndex == null)
            {
            }
            NpkFiles.Add(nkpIndex);
        }
    }

    private static string DecodeName(byte[] org)
    {
        byte[] orgNameBytes = new byte[256];
        if (org.Length < 256)
        {
            Array.Copy(org, orgNameBytes, org.Length);
            for (int i = org.Length; i < 256; i++)
            {
                orgNameBytes[i] = 0x00;
            }
        }
        else
            orgNameBytes = org;

        byte[] newNameBytes = new byte[256];
        for (int i = 0; i < 256; i++)
        {
            newNameBytes[i] = (byte)(orgNameBytes[i] ^ checkBytes[i]);
        }

        return Encoding.ASCII.GetString(newNameBytes.Where(t => t != 0x00).ToArray());
    }
}