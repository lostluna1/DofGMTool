using DofGMTool.Contracts.Services;
using DofGMTool.Models;
using System.Diagnostics;
using System.Text;
using zlib;

namespace DofGMTool.Services;
public class EquipSlotProcessor : IEquipSlotProcessor
{
    // ��һ��:�Ƚ������װ����λ���ֽ�����
    public List<byte[]> ExtractEquipSlots(byte[] decompressedData)
    {
        const int slotSize = 61;
        const int totalSlots = 12;
        var equipSlots = new List<byte[]>(totalSlots);

        for (int i = 0; i < totalSlots; i++)
        {
            byte[] slotData = new byte[slotSize];
            Array.Copy(decompressedData, i * slotSize, slotData, 0, slotSize);
            equipSlots.Add(slotData);
        }

        return equipSlots;
    }
    public List<byte[]> UpdateEquipSlotData(List<byte[]> equipSlots, int slotIndex, ulong newValue, int bitStartIndex, int bitLength)
    {
        if (slotIndex < 0 || slotIndex >= equipSlots.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(slotIndex), "Invalid slot index.");
        }

        byte[] slot = equipSlots[slotIndex];
        var binaryString = new StringBuilder();
        foreach (byte b in slot)
        {
            string binary = Convert.ToString(b, 2).PadLeft(8, '0');
            binaryString.Append(binary);
        }

        string binaryData = binaryString.ToString();
        string newBinaryValue = Convert.ToString((long)newValue, 2).PadLeft(bitLength, '0');

        if (newBinaryValue.Length > bitLength)
        {
            throw new ArgumentException("New value exceeds the specified bit length.");
        }

        // ������Ϣ
        Debug.WriteLine($"Original Binary Data: {binaryData}");
        Debug.WriteLine($"New Binary Value: {newBinaryValue}");

        // ������
        var reversedNewBinaryValue = new StringBuilder();
        for (int i = newBinaryValue.Length - 8; i >= 0; i -= 8)
        {
            reversedNewBinaryValue.Append(newBinaryValue.AsSpan(i, 8));
        }

        var updatedBinaryData = new StringBuilder(binaryData);
        updatedBinaryData.Remove(bitStartIndex, bitLength);
        updatedBinaryData.Insert(bitStartIndex, reversedNewBinaryValue.ToString());

        // ������Ϣ
        Debug.WriteLine($"Updated Binary Data: {updatedBinaryData}");

        for (int i = 0; i < slot.Length; i++)
        {
            slot[i] = Convert.ToByte(updatedBinaryData.ToString().Substring(i * 8, 8), 2);
        }

        return equipSlots;
    }



    // �ڶ���:���������ֽ�����ת��Ϊ�������ַ�������תΪʮ�������־͵õ���ʵ����
    public List<EquipSlotModel> ConvertSlotsToEquipSlotModels(List<byte[]> equipSlots)
    {
        List<EquipSlotModel> equipSlotModels = [];

        foreach (byte[] slot in equipSlots)
        {
            var binaryString = new StringBuilder();
            foreach (byte b in slot)
            {
                string binary = Convert.ToString(b, 2).PadLeft(8, '0');
                binaryString.Append(binary);
            }

            string binaryData = binaryString.ToString();
            var model = new EquipSlotModel
            {
                // 
                Enchantment = ConvertToDecimal(ReverseGroups(binaryData.Substring(0, 8))),
                Type = ConvertToDecimal(ReverseGroups(binaryData.Substring(8, 8))),
                EquipId = ConvertToDecimal(ReverseGroups(binaryData.Substring(16, 32))),
                EnhancementLevel = ConvertToDecimal(ReverseGroups(binaryData.Substring(48, 8))),
                EquipGrade = ConvertToDecimal(ReverseGroups(binaryData.Substring(56, 32))),
                Durability = ConvertToDecimal(ReverseGroups(binaryData.Substring(88, 16))),
                Orb = ConvertToDecimal(ReverseGroups(binaryData.Substring(104, 32))),
                AmplificationType = ConvertToDecimal(ReverseGroups(binaryData.Substring(136, 8))),
                AmplificationValue = ConvertToDecimal(ReverseGroups(binaryData.Substring(144, 16))),
                AbyssalBreath = ConvertToDecimal(ReverseGroups(binaryData.Substring(160, 16))),
                MagicSeal = ConvertToDecimal(ReverseGroups(binaryData.Substring(176, 112))),
                ForgingLevel = ConvertToDecimal(ReverseGroups(binaryData.Substring(288, 8)))
            };

            equipSlotModels.Add(model);
        }

        return equipSlotModels;
    }



    /// <summary>
    /// ����������ÿ��װ����λ�Ķ������ַ�����ÿN*8������Ϊһ��,֮������������
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string ReverseGroups(string input)
    {
        /*
         ��0�� ��װ/ħ����ӡ
��1�� ���� 1װ�� 8ʱװ 5 6
��2������5�� װ��id
��6�� ǿ���ȼ�
��7����10�� װ��Ʒ��
��11����12�� �;ö�
��13����16�� ����
��17�� ���� 1���� 2���� 3���� 4����
��18��19�� ��������ֵ ���65536
��31��32�� �����Ϣ
��37��50�� ħ����ӡ��������Կ�����ţ�Ľ̳̣����߲����صĴ���
��51�� ����ȼ�
         */
        var groups = new List<string>();
        for (int i = 0; i < input.Length; i += 8)
        {
            groups.Add(input.Substring(i, 8));
        }
        groups.Reverse();
        return string.Join(string.Empty, groups);
    }

    public ulong ConvertToDecimal(string binaryString)
    {
        return Convert.ToUInt64(binaryString, 2);
    }

    /// <summary>
    /// ѹ���ֽ�����
    /// </summary>
    /// <param name="sourceByte">��Ҫ��ѹ�����ֽ�����</param>
    /// <returns>ѹ������ֽ�����</returns>
    public byte[] CompressBytes(byte[] sourceByte)
    {
        var inputStream = new MemoryStream(sourceByte);

        Stream outStream = compressStream(inputStream);
        byte[] outPutByteArray = new byte[outStream.Length];
        outStream.Position = 0;
        outStream.Read(outPutByteArray, 0, outPutByteArray.Length);
        outStream.Close();
        inputStream.Close();
        return outPutByteArray;
    }
    /// <summary>
    /// ѹ����
    /// </summary>
    /// <param name="sourceStream">��Ҫ��ѹ������</param>
    /// <returns>ѹ�������</returns>
    private static Stream compressStream(Stream sourceStream)
    {
        var streamOut = new MemoryStream();
        streamOut.Write(BitConverter.GetBytes(sourceStream.Length), 0, 4);
        var streamZOut = new ZOutputStream(streamOut, zlibConst.Z_DEFAULT_COMPRESSION);
        CopyStream(sourceStream, streamZOut);
        streamZOut.finish();
        return streamOut;
    }
    /// <summary>
    /// ������
    /// </summary>
    /// <param name="input">ԭʼ��</param>
    /// <param name="output">Ŀ����</param>
    public static void CopyStream(System.IO.Stream input, System.IO.Stream output)
    {
        byte[] buffer = new byte[2000];
        int len;
        while ((len = input.Read(buffer, 0, 2000)) > 0)
        {
            output.Write(buffer, 0, len);
        }
        output.Flush();
    }

    public byte[] CompressEquipSlots(List<byte[]> equipSlots)
    {
        using var memoryStream = new MemoryStream();
        foreach (byte[] slot in equipSlots)
        {
            memoryStream.Write(slot, 0, slot.Length);
        }
        return memoryStream.ToArray();
    }
}

