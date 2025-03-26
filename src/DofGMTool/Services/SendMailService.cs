using DofGMTool.Constant;
using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace DofGMTool.Services;
public class SendMailService : ISendMailService
{
    //private IDatabaseService databaseService;
    public IInventoryManageService _inventoryManageService;
    public IFreeSql<MySqlFlag> taiwan_cain_2nd => DatabaseHelper.GetMySqlConnection(DBNames.TaiwanCain2nd);
    public IFreeSql<MySqlFlag> taiwan_cain => DatabaseHelper.GetMySqlConnection(DBNames.TaiwanCain);
    public IFreeSql<SqliteFlag> _freeSqlite;

    // 构造函数
    public SendMailService(IFreeSql<SqliteFlag> freeSqlite, IInventoryManageService inventoryManageService)
    {
        _inventoryManageService = inventoryManageService;
        _freeSqlite = freeSqlite;
        //DatabaseHelper databaseService = DatabaseHelper.Instance;

        //taiwan_cain_2nd = DatabaseHelper.GetMySqlConnection(DBNames.TaiwanCain2nd);
        //taiwan_cain = DatabaseHelper.GetMySqlConnection(DBNames.TaiwanCain);
    }
    public async Task<ObservableCollection<Equipments>> GetEquipmentExAsync(int partsetIndex, string? partsetName = null)
    {
        if (partsetIndex == 0 && string.IsNullOrEmpty(partsetName))
        {
            return new ObservableCollection<Equipments>();
        }

        FreeSql.ISelect<Equipments> query = _freeSqlite.Select<Equipments>()
            .Where(a => a.PartsetIndex == partsetIndex && a.PartsetIndex != 2);
        if (!string.IsNullOrEmpty(partsetName) && partsetIndex == 0)
        {
            query = query.Where(a => a.SetName == partsetName);
        }
        List<Equipments> data = await query.ToListAsync();
        var additionalItems = new HashSet<Equipments>();
        foreach (Equipments item in data)
        {
            string partSetItemId = item.PartsetItemArr;
            var numbers = new HashSet<string>(StringParser.ParsePartsetItemArr(partSetItemId));
            foreach (string itemIds in numbers)
            {
                Equipments specialPartsetObj = _freeSqlite.Select<Equipments>().Where(a => a.ItemId == itemIds).First();
                additionalItems.Add(specialPartsetObj);

            }
        }

        if (partsetIndex != 0 && !string.IsNullOrEmpty(partsetName))
        {
            return new ObservableCollection<Equipments>(data);
        }
        else if (partsetIndex == 0 && !string.IsNullOrEmpty(partsetName))
        {
            return new ObservableCollection<Equipments>(additionalItems.GroupBy(a => a.ItemId).Select(g => g.First()));

        }
        return [];
    }

    public async Task<ObservableCollection<EquipmentPartset>> GetEquipmentPartsetAsync(string query)
    {
        // 查询特殊套装名称并去重
        List<Equipments> specialPartsetNames = await _freeSqlite.Select<Equipments>()
            .Where(a => !string.IsNullOrEmpty(a.SetName) && (string.IsNullOrEmpty(query) || a.SetName.Contains(query)))
            .ToListAsync();
        var uniqueSpecialPartsetNames = specialPartsetNames
            .GroupBy(e => e.SetName)
            .Select(g => g.First())
            .ToList();

        // 查询普通套装
        FreeSql.ISelect<EquipmentPartset> condition = _freeSqlite.Select<EquipmentPartset>().Where(a => a.Id != 2);
        if (!string.IsNullOrEmpty(query))
        {
            condition = condition.Where(a => a.PartsetName.Contains(query));
        }
        List<EquipmentPartset> data = await condition.ToListAsync();

        // 添加特殊套装名称到结果中，避免重复
        var partsetNames = new HashSet<string>(data.Select(d => d.PartsetName));
        foreach (Equipments? item in uniqueSpecialPartsetNames)
        {
            if (!partsetNames.Contains(item.SetName))
            {
                data.Add(new EquipmentPartset { PartsetName = item.SetName });
            }
        }

        return new ObservableCollection<EquipmentPartset>(data);
    }


    public int SendMail(MailType type, MailModel mailModel, ObservableCollection<Equipments>? equipments = null)
    {
        taiwan_cain_2nd.CodeFirst.SyncStructure<_Postal>();
        return type switch
        {
            MailType.Stackable => SendStackable(mailModel),
            MailType.Equipment => SendEquipment(mailModel),
            MailType.Creature => SendCreature(mailModel),
            MailType.Avatar => SendAvatar(mailModel),
            MailType.Partset => SendEquipmentPartset(equipments, mailModel),
            _ => 0,
        };
    }

    public int PageSize = 300;

    public string Title = "GM Mail";
    public string Content = "test";
    //public string Content = "感谢使用百度台服DNF吧官方GM工具，如有问题请到官方贴吧反馈";
    //public string Content = "感謝使用百度臺服DNF吧官方GM工具，如有問題請到官方貼吧反饋";
    public async Task<ObservableCollection<Equipments>> GetItemsList(MailType type, string? query = null)
    {
        if (type == MailType.Equipment)
        {
            var typeFilter = new EquipTypeFilter
            {
                Types = ["装扮", "宠物"],
                IsInclude = false
            };
            (ObservableCollection<Equipments> Equipments, int TotalCount) result = await _inventoryManageService.GetEquipmentDataPaged(1, PageSize, null, query, null, typeFilter);
            var data = result.Equipments.Where(a => a.ItemName != "未定名")
                .ToList();

            return new ObservableCollection<Equipments>(data);

        }
        else if (type == MailType.Avatar)
        {
            var typeFilter = new EquipTypeFilter
            {
                Types = ["装扮", "光环"],
                IsInclude = true // 包含
            };
            (ObservableCollection<Equipments> Equipments, int TotalCount) result = await _inventoryManageService.GetEquipmentDataPaged(1, PageSize, null, query, null, typeFilter);
            var data = result.Equipments
                .ToList();

            return new ObservableCollection<Equipments>(data);

        }
        else if (type == MailType.Creature)
        {
            var typeFilter = new EquipTypeFilter
            {
                Types = ["宠物"],
                IsInclude = true // 包含
            };
            (ObservableCollection<Equipments> Equipments, int TotalCount) result = await _inventoryManageService.GetEquipmentDataPaged(1, PageSize, null, query, null, typeFilter);
            var data = result.Equipments
                .Where(a => a.AttachType is "不限制" or "封装" or "封装且不可交易" or "账号绑定")
                .Where(a => a.ItemId is not "63026" or "63005")
                .ToList();

            return new ObservableCollection<Equipments>(data);


        }
        else if (type == MailType.Stackable)
        {
            var typeFilter = new EquipTypeFilter
            {
                Types = ["消耗品/材料"],
                IsInclude = true // 包含
            };
            (ObservableCollection<Equipments> Equipments, int TotalCount) result = await _inventoryManageService.GetEquipmentDataPaged(1, PageSize, null, query, null, typeFilter);
            var data = result.Equipments
                .ToList();

            return new ObservableCollection<Equipments>(data);
        }
        return [];
    }
    private int SendAvatar(MailModel avatar)
    {
        if (avatar.CharacNo.Count == 0)
        {
            return -1;
        }
        DateTime time = DateTime.Now;
        avatar.Title = "GM_Mail";
        avatar.Content = "test";
        using FreeSql.IRepositoryUnitOfWork unitOfWork = taiwan_cain_2nd.CreateUnitOfWork();
        try
        {
            int postalId = -1;
            foreach (int item in avatar.CharacNo)
            {
                var letter = new Letter
                {
                    CharacNo = item,
                    SendCharacNo = 5,
                    SendCharacName = avatar.Title,
                    LetterText = avatar.Content,
                    RegDate = time,
                    Stat = 1
                };

                var userItem = new UserItems
                {
                    CharacNo = item,
                    ItId = avatar.ItemId,
                    JewelSocket = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                    MTime = new DateTime(9999, 12, 31, 23, 59, 59),
                    ExpireDate = new DateTime(9999, 12, 31, 23, 59, 59),
                    RegDate = time
                };

                var postal = new _Postal
                {
                    OccTime = time,
                    SendCharacNo = 5,
                    ReceiveCharacNo = item,
                    SendCharacName = avatar.Title,
                    ItemId = (uint)avatar.ItemId,
                    AddInfo = GetClothesID(),
                    Gold = (uint)avatar.Gold,
                    AvataFlag = 1,
                    UnlimitFlag = 1,
                    LetterId = GetLetterID()
                };

                taiwan_cain_2nd.Insert(letter).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteAffrows();
                taiwan_cain_2nd.Insert(userItem).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteAffrows();
                postalId = (int)taiwan_cain_2nd.Insert(postal).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteIdentity();
            }

            unitOfWork.Commit();
            return postalId;
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    private int SendCreature(MailModel creature)
    {
        if (creature.CharacNo.Count == 0)
        {
            return -1;
        }
        DateTime time = DateTime.Now;
        creature.Title = Title;
        creature.Content = Content;

        using FreeSql.IRepositoryUnitOfWork unitOfWork = taiwan_cain_2nd.CreateUnitOfWork();
        try
        {
            int postalId = -1;
            foreach (int item in creature.CharacNo)
            {
                var letter = new Letter
                {
                    CharacNo = item,
                    SendCharacNo = 5,
                    SendCharacName = creature.Title,
                    LetterText = creature.Content,
                    RegDate = time,
                    Stat = 1
                };

                var creatureItem = new CreatureItems
                {
                    CharacNo = item,
                    ItId = (uint)creature.ItemId,
                    RegDate = time,
                    Stomach = 100,
                    CreatureType = (sbyte)creature.CreatureType,
                    Stat = 1
                };

                var postal = new _Postal
                {
                    OccTime = time,
                    SendCharacNo = 5,
                    ReceiveCharacNo = item,
                    SendCharacName = creature.Title,
                    ItemId = (uint)creature.ItemId,
                    AddInfo = GetCreatureID(),
                    Gold = (uint)creature.Gold,
                    CreatureFlag = 1,
                    LetterId = GetLetterID()
                };

                taiwan_cain_2nd.Insert(letter).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteAffrows();
                taiwan_cain_2nd.Insert(creatureItem).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteAffrows();
                postalId = (int)taiwan_cain_2nd.Insert(postal).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteIdentity();
            }

            unitOfWork.Commit();
            return postalId;
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    private int SendEquipmentPartset(ObservableCollection<Equipments> equipments, MailModel mailModel)
    {
        if (equipments == null || equipments.Count == 0 || mailModel.CharacNo.Count == 0)
        {
            throw new Exception("发送前需要先选择一个套装");
            //return -1;
        }

        DateTime time = DateTime.Now;
        int letterId = GetLetterID(); // 获取相同的 LetterId

        using FreeSql.IRepositoryUnitOfWork unitOfWork = taiwan_cain_2nd.CreateUnitOfWork();
        try
        {
            foreach (int characNo in mailModel.CharacNo)
            {
                int itemCount = 0;
                var letter = new Letter
                {
                    CharacNo = characNo,
                    SendCharacNo = 0,
                    SendCharacName = mailModel.Title,
                    LetterText = mailModel.Content,
                    RegDate = time,
                    Stat = 1
                };

                taiwan_cain_2nd.Insert(letter).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteAffrows();

                foreach (Equipments equipment in equipments)
                {
                    if (itemCount >= 10)
                    {
                        // 超过10个物品，重新获取LetterId并创建新的Letter
                        letterId = GetLetterID();
                        letter = new Letter
                        {
                            CharacNo = characNo,
                            SendCharacNo = 0,
                            SendCharacName = mailModel.Title,
                            LetterText = mailModel.Content,
                            RegDate = time,
                            Stat = 1
                        };

                        taiwan_cain_2nd.Insert(letter).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteAffrows();
                        itemCount = 0;
                    }

                    var postal = new _Postal
                    {
                        OccTime = time,
                        ReceiveCharacNo = characNo,
                        SendCharacName = mailModel.Title,
                        SendCharacNo = 0,
                        ItemId = (uint)int.Parse(equipment.ItemId!),
                        AddInfo = 100, // 最上级
                        Endurance = 20, // 耐久
                        Upgrade = mailModel.PowerUpLevel,
                        AmplifyOption = (byte)mailModel.IncreaseType,
                        AmplifyValue = (byte)mailModel.IncreaseValue,
                        Gold = (uint)mailModel.Gold,
                        LetterId = letterId, // 使用相同的 LetterId
                        SeperateUpgrade = (byte)mailModel.Smithing
                    };

                    taiwan_cain_2nd.Insert(postal).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteIdentity();
                    itemCount++;
                }
            }

            unitOfWork.Commit();
            return letterId;
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }



    private int SendEquipment(MailModel equipment)
    {
        if (equipment.CharacNo.Count == 0)
        {
            return -1;
        }
        DateTime time = DateTime.Now;
        equipment.Title = Title;
        equipment.Content = Content;

        using FreeSql.IRepositoryUnitOfWork unitOfWork = taiwan_cain_2nd.CreateUnitOfWork();
        try
        {
            int postalId = -1;
            foreach (int item in equipment.CharacNo)
            {
                var letter = new Letter
                {
                    CharacNo = item,
                    SendCharacNo = 0,
                    SendCharacName = equipment.Title,
                    LetterText = equipment.Content,
                    RegDate = time,
                    Stat = 1
                };

                var postal = new _Postal
                {
                    OccTime = time,
                    ReceiveCharacNo = item,
                    SendCharacName = equipment.Title,
                    ItemId = (uint)equipment.ItemId,
                    AddInfo = 100, // 最上级
                    Endurance = 20, // 耐久
                    Upgrade = equipment.PowerUpLevel,
                    AmplifyOption = (byte)equipment.IncreaseType,
                    AmplifyValue = (byte)equipment.IncreaseValue,
                    Gold = (uint)equipment.Gold,
                    LetterId = GetLetterID(),
                    SeperateUpgrade = (byte)equipment.Smithing
                };

                taiwan_cain_2nd.Insert(letter).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteAffrows();
                postalId = (int)taiwan_cain_2nd.Insert(postal).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteIdentity();
            }

            unitOfWork.Commit();
            return postalId;
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    private int SendStackable(MailModel stackable)
    {
        if (stackable.CharacNo.Count == 0)
        {
            return -1;
        }

        DateTime time = DateTime.Now;
        stackable.Title = Title;
        stackable.Content = Content;

        using FreeSql.IRepositoryUnitOfWork unitOfWork = taiwan_cain_2nd.CreateUnitOfWork();
        try
        {
            int postalId = -1;
            foreach (int item in stackable.CharacNo)
            {
                var letter = new Letter
                {
                    CharacNo = item,
                    SendCharacNo = 0,
                    SendCharacName = stackable.Title,
                    LetterText = stackable.Content,
                    RegDate = time,
                    Stat = 1
                };

                var postal = new _Postal
                {
                    OccTime = time,
                    ReceiveCharacNo = item,
                    SendCharacName = stackable.Title,
                    ItemId = (uint)stackable.ItemId,
                    AddInfo = stackable.ItemCount,
                    Gold = (uint)stackable.Gold,
                    LetterId = GetLetterID(),
                };
                Debug.WriteLine(postal.AddInfo);
                taiwan_cain_2nd.Insert(letter).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteAffrows();
                postalId = (int)taiwan_cain.Insert(postal).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteIdentity();

            }

            unitOfWork.Commit();
            return postalId;
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    private int GetClothesID()
    {
        int result = taiwan_cain.Ado.QuerySingle<int>(
            "SELECT Auto_increment FROM information_schema.`TABLES` WHERE Table_Schema=@schema AND table_name=@table LIMIT 1",
            new { schema = "taiwan_cain_2nd", table = "user_items" }
        );
        return result;
    }

    private int GetLetterID()
    {
        int result = taiwan_cain.Ado.QuerySingle<int>(
            "SELECT Auto_increment FROM information_schema.`TABLES` WHERE Table_Schema=@schema AND table_name=@table LIMIT 1",
            new { schema = "taiwan_cain_2nd", table = "letter" }
        );
        return result;
    }

    private int GetCreatureID()
    {
        int result = taiwan_cain.Ado.QuerySingle<int>(
            "SELECT Auto_increment FROM information_schema.`TABLES` WHERE Table_Schema=@schema AND table_name=@table LIMIT 1",
            new { schema = "taiwan_cain_2nd", table = "creature_items" }
        );
        return result;
    }

    //private string ConvertToLatin1(string input)
    //{
    //    var bytes = Encoding.GetEncoding("latin1").GetBytes(input);
    //    return Encoding.GetEncoding("latin1").GetString(bytes);
    //}

    public static string ConvertToLatin1(string str)
    {
        // 将字符串从 UTF-8 编码转换为字节数组
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(str);
        // 将字节数组从 UTF-8 转换为 Latin1
        byte[] latin1Bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("latin1"), utf8Bytes);
        // 将 Latin1 字节数组转换为字符串
        string latin1Str = Encoding.GetEncoding("latin1").GetString(latin1Bytes);
        return latin1Str;
    }

    public ObservableCollection<_Postal> GetPostals()
    {
        var data = taiwan_cain_2nd.Select<_Postal>().Where(a => a.OccTime >= DateTime.Now.AddDays(-3) && a.ReceiveCharacNo == GlobalVariables.Instance.GlobalCurrentCharacInfo!.CharacNo).ToList();

        return new ObservableCollection<_Postal>(data);
    }

    public void DeletePostal(int id)
    {
        using FreeSql.IRepositoryUnitOfWork unitOfWork = taiwan_cain_2nd.CreateUnitOfWork();
        try
        {
            _Postal a = taiwan_cain_2nd.Select<_Postal>().Where(a => a.PostalId == id).First();
            if (a.DeleteFlag != 0)
            {
                throw new Exception("已接收的邮件无法删除");
            }
            taiwan_cain_2nd.Delete<_Postal>().Where(a => a.PostalId == id).WithTransaction(unitOfWork.GetOrBeginTransaction()).ExecuteAffrows();

            unitOfWork.Commit();
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    public async Task<string> GetRoleNameById(int characNo)
    {
        string result = await taiwan_cain.Select<CharacInfo>().Where(a => a.CharacNo == characNo).FirstAsync(a => a.CharacName);
        if (result != null)
        {
            return result;

        }
        return string.Empty;
    }
}
public partial class StringParser
{
    public static List<string> ParsePartsetItemArr(string partsetItemArr)
    {
        // 使用正则表达式匹配数字
        MatchCollection matches = NumberRegex().Matches(partsetItemArr);
        var result = new List<string>();

        foreach (Match match in matches)
        {
            result.Add(match.Value);
        }

        return result;
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();
}

