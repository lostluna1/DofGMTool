using DofGMTool.Contracts.Services;
using DofGMTool.Models;
using System.Diagnostics;
using System.Text;
using zlib;

namespace DofGMTool.Services;
public class EquipSlotProcessor : IEquipSlotProcessor
{
    // 第一步:先解出所有装备槽位的字节数据
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

        // 调试信息
        Debug.WriteLine($"Original Binary Data: {binaryData}");
        Debug.WriteLine($"New Binary Value: {newBinaryValue}");

        // 逆序处理
        var reversedNewBinaryValue = new StringBuilder();
        for (int i = newBinaryValue.Length - 8; i >= 0; i -= 8)
        {
            reversedNewBinaryValue.Append(newBinaryValue.AsSpan(i, 8));
        }

        var updatedBinaryData = new StringBuilder(binaryData);
        updatedBinaryData.Remove(bitStartIndex, bitLength);
        updatedBinaryData.Insert(bitStartIndex, reversedNewBinaryValue.ToString());

        // 调试信息
        Debug.WriteLine($"Updated Binary Data: {updatedBinaryData}");

        for (int i = 0; i < slot.Length; i++)
        {
            slot[i] = Convert.ToByte(updatedBinaryData.ToString().Substring(i * 8, 8), 2);
        }

        return equipSlots;
    }



    // 第二步:将解析的字节数据转换为二进制字符串后再转为十进制数字就得到真实数据
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
    /// 将解析出的每个装备槽位的二进制字符串以每N*8个数字为一组,之后再逆序排序
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string ReverseGroups(string input)
    {
        /*
         第0组 封装/魔法封印
第1组 类型 1装备 8时装 5 6
第2到第五5组 装备id
第6组 强化等级
第7到第10组 装备品级
第11到第12组 耐久度
第13到第16组 宝珠
第17组 增幅 1体力 2精神 3力量 4智力
第18到19组 增幅附加值 最大65536
第31到32组 异界气息
第37到50组 魔法封印，具体可以看看神牛的教程，或者插件相关的代码
第51组 锻造等级
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
    /// 压缩字节数组
    /// </summary>
    /// <param name="sourceByte">需要被压缩的字节数组</param>
    /// <returns>压缩后的字节数组</returns>
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
    /// 压缩流
    /// </summary>
    /// <param name="sourceStream">需要被压缩的流</param>
    /// <returns>压缩后的流</returns>
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
    /// 复制流
    /// </summary>
    /// <param name="input">原始流</param>
    /// <param name="output">目标流</param>
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

