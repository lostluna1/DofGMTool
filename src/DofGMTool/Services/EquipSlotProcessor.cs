using DofGMTool.Constant;
using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using zlib;

namespace DofGMTool.Services;
public class EquipSlotProcessor : IEquipSlotProcessor
{
    public IFreeSql<MySqlFlag>? _taiwan_cain_2nd;
    public EquipSlotProcessor()
    {
        //DatabaseHelper database = DatabaseHelper.Instance;
        //_taiwan_cain_2nd = DatabaseHelper.GetMySqlConnection(DBNames.TaiwanCain2nd);
    }

    public async Task<bool> SetEquipSlots(int characno, ObservableCollection<EquipSlotModel> eData, bool isCover = true)
    {
        //先读取
        List<EquipSlotModel> readData = isCover ? GetWearsData12() : await GetEquipSlots(characno);
        foreach (EquipSlotModel item in readData)
        {
            EquipSlotModel? obj = eData.Where(e => e.Type == item.Type).FirstOrDefault();
            if (obj != null)
            {
                item.EquipId = obj.EquipId;
                item.EnhancementLevel = obj.EnhancementLevel;
                item.EquipGrade = obj.EquipGrade;
                item.Durability = obj.Durability;
                item.AmplificationType = obj.AmplificationType;
                item.AmplificationValue = obj.AmplificationValue;
                item.Type = obj.Type;
                item.ForgingLevel = obj.ForgingLevel;
            }
        }

        var sb = new StringBuilder();

        foreach (EquipSlotModel item in readData)
        {
            sb.Append(EquipslotDataHex(item));
        }

        string latin1str = HexToLatin1(sb.ToString());
        Debug.WriteLine($"Latin1 String: {latin1str}");
        Debug.WriteLine($"Latin1 String (Hex): {ByteToHexString(Encoding.GetEncoding("latin1").GetBytes(latin1str))}");
        return true;

    }

    public async Task<List<EquipSlotModel>> GetEquipSlots(int characno)
    {
        _taiwan_cain_2nd = DatabaseHelper.GetMySqlConnection(DBNames.TaiwanCain2nd);
        if (_taiwan_cain_2nd == null)
        {
            throw new Exception("数据库连接未初始化。");
        }
        /*Type:
            *1:武器
         *2:称号
         *3:上衣
         *4:头肩
         *5:下装
         *6:鞋子
         *7:腰带
         *8:项链
         *9:手镯
         *10:戒指
         *11:左槽
         *12:右槽
         *
         *总字节长度732
         *每个位置61个字节
         * */

        //var sql = $"select UNCOMPRESS(equipslot) FROM taiwan_cain_2nd.inventory WHERE charac_no={characno}";
        _Inventory inventory = await _taiwan_cain_2nd.Ado.QuerySingleAsync<_Inventory>($"SELECT UNCOMPRESS(equipslot) as EquipSlot  FROM inventory WHERE charac_no = {characno}");
        byte[]? inventoryBytes = inventory.Equipslot;
        if (inventoryBytes is null || inventoryBytes.Length == 0)
        {
            return GetWearsData12();
        }
        var equipments = new List<EquipSlotModel>();
        string s = ByteToHexString(inventoryBytes);
        int n = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (i % 122 == 0)
            {
                n++;
                string temp = s.Substring(i, 122);
                equipments.Add(new EquipSlotModel()
                {
                    Type = (ulong)n,
                    EquipId = (ulong)Convert.ToInt32(HlReverse(temp.Substring(4, 8)), 16),
                    EnhancementLevel = (ulong)Convert.ToInt32(HlReverse(temp.Substring(12, 2)), 16),
                    EquipGrade = (ulong)Convert.ToInt32(HlReverse(temp.Substring(14, 8)), 16),
                    Durability = (ulong)Convert.ToInt32(HlReverse(temp.Substring(22, 2)), 16),
                    AmplificationType = (ulong)Convert.ToInt32(HlReverse(temp.Substring(34, 2)), 16),
                    AmplificationValue = (ulong)Convert.ToInt32(HlReverse(temp.Substring(36, 4)), 16),
                    ForgingLevel = (ulong)Convert.ToInt32(HlReverse(temp.Substring(102, 2)), 16),
                });

                if (n == 12)
                {
                    break;
                }
            }
        }
        List<byte[]> a = ExtractEquipSlots(inventoryBytes);
        List<EquipSlotModel> b = ConvertSlotsToEquipSlotModels(a);
        return equipments;

    }
    private List<EquipSlotModel> GetWearsData12()
    {
        var eData = new List<EquipSlotModel>();
        for (ulong i = 0; i < 12; i++) //空数据
        {
            eData.Add(new EquipSlotModel() { Type = i + 1 });
        }

        return eData;
    }
    public static string ByteToHexString(byte[] buff)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < buff.Length; i++)
        {
            sb.Append(buff[i].ToString("x2").ToUpper());

        }

        return sb.ToString();

    }
    public static string HlReverse(string str)
    {

        if (str.Length % 2 != 0)
        {
            return str;
        }

        var temp = new List<string>();

        for (int i = 0; i < str.Length; i++)
        {
            if (i % 2 == 0)
            {
                temp.Add(str.Substring(i, 2));
            }
        }

        temp.Reverse();
        return string.Join(string.Empty, temp);
    }

    private string EquipslotDataHex(EquipSlotModel edata)
    {
        //0001(类型 装备是1) DA690000(代码) 00(强化)  00000000(品级 越小越接近最最上级)  00(耐久度)  0000000000 00(红字类型) 0000(红字属性值) 00000000000000000000000000000000000000000000000000000000000000 00(锻造) 000000000000000000
        var data = new StringBuilder();
        if (edata.EquipId == 0)//无代码
        {
            for (int i = 0; i < 122; i++)
            {
                data.Append("0");
            }

            return data.ToString();//空数据
        }

        data.Append("0001");
        data.Append(HlReverse(edata.EquipId.ToString("X8")));
        data.Append(edata.EnhancementLevel.ToString("X2"));
        data.Append(HlReverse(edata.EquipGrade.ToString("X8")));
        data.Append(edata.Durability.ToString("X2"));
        data.Append("0000000000");
        data.Append(edata.AmplificationType.ToString("X2"));
        data.Append(HlReverse(edata.AmplificationValue.ToString("X4")));
        data.Append("00000000000000000000000000000000000000000000000000000000000000");
        data.Append(edata.ForgingLevel.ToString("X2"));
        data.Append("000000000000000000");
        return data.ToString();

    }
    public static string HexToLatin1(string hex)
    {
        //string latin1str = HexStringToBytes(hex);
        string latin1str = Encoding.GetEncoding("latin1").GetString(HexStringToBytes(hex));

        latin1str = latin1str.Replace("\\", "\\\\"); //必须转义
        latin1str = latin1str.Replace("'", "''"); //必须转义
        return latin1str;
    }
    public static byte[] HexStringToBytes(string str)
    {
        string strTemp = "";
        byte[] b = new byte[str.Length / 2];
        for (int i = 0; i < str.Length / 2; i++)
        {
            strTemp = str.Substring(i * 2, 2);
            b[i] = Convert.ToByte(strTemp, 16);
        }
        //按照指定编码将字节数组变为字符串
        return b;
    }



    // 第一步:先解出所有装备槽位的字节数据
    public List<byte[]> ExtractEquipSlots(byte[] decompressedData)
    {
        const int slotSize = 61;
        const int totalSlots = 12;
        var equipSlots = new List<byte[]>(totalSlots);

        try
        {
            for (int i = 0; i < totalSlots; i++)
            {
                byte[] slotData = new byte[slotSize];
                Array.Copy(decompressedData, i * slotSize, slotData, 0, slotSize);
                equipSlots.Add(slotData);
            }
        }
        catch (Exception e)
        {

            Debug.WriteLine(e.Message);
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
        var equipSlotModels = new List<EquipSlotModel>();

        for (int i = 0; i < equipSlots.Count; i++)
        {
            byte[] slot = equipSlots[i];
            var binaryString = new StringBuilder();
            foreach (byte b in slot)
            {
                string binary = Convert.ToString(b, 2).PadLeft(8, '0');
                binaryString.Append(binary);
            }

            string binaryData = binaryString.ToString();
            var model = new EquipSlotModel
            {
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

        // 补全缺失的槽位
        while (equipSlotModels.Count < 12)
        {
            equipSlotModels.Add(new EquipSlotModel());
        }

        return equipSlotModels;
    }


    /*public List<EquipSlotModel> ConvertSlotsToEquipSlotModels(List<byte[]> equipSlots)
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
    }*/



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
    /// 
    public byte[] CompressBytes(byte[] sourceByte)
    {
        if (sourceByte.Length != 732)
        {
            throw new ArgumentException("The length of the source byte array must be 732 bytes.");
        }

        var inputStream = new MemoryStream(sourceByte);
        Stream outStream = compressStream(inputStream);
        byte[] outPutByteArray = new byte[732];

        // 确保压缩后的数据长度为 732 字节
        if (outStream.Length < 732)
        {
            outStream.Position = 0;
            outStream.Read(outPutByteArray, 0, (int)outStream.Length);
        }
        else
        {
            outStream.Position = 0;
            outStream.Read(outPutByteArray, 0, 732);
        }

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

