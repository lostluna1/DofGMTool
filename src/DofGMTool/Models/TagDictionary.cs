namespace DofGMTool.Models;

public static class TagDictionary
{
    public const string Amulet = "护身符";
    public const string ArtifactBlue = "宠物装备 蓝";
    public const string ArtifactGreen = "宠物装备 绿";
    public const string ArtifactRed = "宠物装备 红";
    public const string AuroraAvatar = "光环";
    public const string BreastAvatar = "胸部头像";
    public const string CoatAvatar = "上衣装扮";
    public const string Coat = "胸甲";
    public const string Creature = "宠物";
    public const string FaceAvatar = "面部装扮";
    public const string HairAvatar = "头发装扮";
    public const string HatAvatar = "帽子装扮";
    public const string MagicStone = "魔法石";
    public const string PantsAvatar = "裤子装扮";
    public const string Pants = "护腿";
    public const string Ring = "戒指";
    public const string ShoesAvatar = "鞋子装扮";
    public const string Shoes = "鞋子";
    public const string Shoulder = "肩膀";
    public const string SkinAvatar = "皮肤装扮";
    public const string Support = "辅助装备";
    public const string TitleName = "称号";
    public const string WaistAvatar = "腰部装扮";
    public const string Waist = "腰带";
    public const string Weapon = "武器";
    public const string Wrist = "手镯";

    public const string Free = "不限制";
    public const string Sealing = "封装";
    public const string Trade = "不可交易";
    public const string Account = "帐号绑定";
    public const string TradeDelete = "无法交易、删除";
    public const string SealingTrade = "封装且不可交易";

    public const string CreatorMage = "缔造者";
    public const string All = "所有角色";
    public const string Swordman = "鬼剑士";
    public const string DemonicSwordman = "黑暗武士";
    public const string Fighter = "格斗家(女)";
    public const string AtFighter = "格斗家(男)";
    public const string Gunner = "神枪手(男)";
    public const string AtGunner = "神枪手(女)";
    public const string Mage = "魔法师(女)";
    public const string AtMage = "魔法师(男)";
    public const string Priest = "圣职者";
    public const string Thief = "暗夜使者";

    public const string Ssword = "短剑";
    public const string Totem = "图腾";
    public const string Axe = "巨斧";
    public const string Katana = "太刀";
    public const string Automatic = "自动步枪";
    public const string Club = "钝器";
    public const string Lswd = "巨剑";
    public const string Beamswd = "光剑";
    public const string Knuckle = "手套";
    public const string Claw = "爪";
    public const string Tonfa = "东方棍";
    public const string Gauntlet = "臂铠";
    public const string Hcannon = "手炮";
    public const string LaCoat = "上衣";
    public const string LtPants = "裤子";
    public const string LaWaist = "腰带";
    public const string MagicStoneSlot = "魔法石(左右槽)";
    public const string MtPants = "板甲下装";
    public const string MtWaist = "板甲腰带";
    public const string MtCoat = "板甲上衣";
    public const string MtShoes = "板甲鞋子";
    public const string MtShoulder = "板甲护肩";
    public const string HaPants = "重甲下装";
    public const string HaWaist = "重甲腰带";
    public const string HaCoat = "重甲上衣";
    public const string HaShoes = "重甲鞋子";
    public const string HaShoulder = "重甲护肩";
    public const string LtWaist = "皮甲腰带";
    public const string LtCoat = "皮甲上衣";
    public const string LtShoes = "皮甲鞋子";
    public const string LtShoulder = "皮甲护肩";
    public const string LaPants = "轻甲下装";
    public const string LaShoes = "轻甲鞋子";
    public const string LaShoulder = "轻甲护肩";
    public const string ClPants = "布甲下装";
    public const string ClWaist = "布甲腰带";
    public const string ClCoat = "布甲上衣";
    public const string ClShoes = "布甲鞋子";
    public const string ClShoulder = "布甲护肩";
    public const string AmuletNecklace = "项链";

    public const string FireElement = "火属性";
    public const string WaterElement = "冰属性";
    public const string LightElement = "光属性";
    public const string DarkElement = "暗属性";

    public static readonly Dictionary<string, string> EquipmentTypeTranslations = new()
    {
        { "[amulet]", Amulet },
        { "[artifact blue]", ArtifactBlue },
        { "[artifact green]", ArtifactGreen },
        { "[artifact red]", ArtifactRed },
        { "[aurora avatar]", AuroraAvatar },
        { "[breast avatar]", BreastAvatar },
        { "[coat avatar]", CoatAvatar },
        { "[coat]", Coat },
        { "[creature]", Creature },
        { "[face avatar]", FaceAvatar },
        { "[hair avatar]", HairAvatar },
        { "[hat avatar]", HatAvatar },
        { "[magic stone]", MagicStone },
        { "[pants avatar]", PantsAvatar },
        { "[pants]", Pants },
        { "[ring]", Ring },
        { "[shoes avatar]", ShoesAvatar },
        { "[shoes]", Shoes },
        { "[shoulder]", Shoulder },
        { "[skin avatar]", SkinAvatar },
        { "[support]", Support },
        { "[title name]", TitleName },
        { "[waist avatar]", WaistAvatar },
        { "[waist]", Waist },
        { "[weapon]", Weapon },
        { "[wrist]", Wrist }
    };

    public static readonly Dictionary<string, string> AttachTypeTranslations = new()
    {
        { "[free]", Free },
        { "[sealing]", Sealing },
        { "[trade]", Trade },
        { "[account]", Account },
        { "[trade delete]", TradeDelete },
        { "[sealing trade]", SealingTrade }
    };

    public static readonly Dictionary<string, string> CharacterTypeTranslations = new()
    {
        { "creatormage", CreatorMage },
        { "all]", All },
        { "swordman", Swordman },
        { "demonicswordman", DemonicSwordman },
        { "fighter", Fighter },
        { "atfighter", AtFighter },
        { "gunner", Gunner },
        { "atgunner", AtGunner },
        { "mage", Mage },
        { "atmage", AtMage },
        { "priest", Priest },
        { "thief", Thief }
    };

    public static readonly Dictionary<string, string> UsableJobTranslations = new()
    {
        { "[creator mage]", CreatorMage },
        { "[all]", All },
        { "[swordman]", Swordman },
        { "[demonic swordman]", DemonicSwordman },
        { "[fighter]", Fighter },
        { "[at fighter]", AtFighter },
        { "[gunner]", Gunner },
        { "[at gunner]", AtGunner },
        { "[mage]", Mage },
        { "[at mage]", AtMage },
        { "[priest]", Priest },
        { "[thief]", Thief }
    };

    public static readonly Dictionary<string, string> EquipmentGroupTypeTranslations = new()
    {
        { "ssword", Ssword },
        { "totem", Totem },
        { "axe", Axe },
        { "katana", Katana },
        { "automatic", Automatic },
        { "club", Club },
        { "lswd", Lswd },
        { "beamswd", Beamswd },
        { "knuckle", Knuckle },
        { "claw", Claw },
        { "tonfa", Tonfa },
        { "gauntlet", Gauntlet },
        { "hcannon", Hcannon },
        { "wrist", Wrist },
        { "la coat", LaCoat },
        { "lt pants", LtPants },
        { "la waist", LaWaist },
        { "magic stone", MagicStoneSlot },
        { "mt pants", MtPants },
        { "mt waist", MtWaist },
        { "mt coat", MtCoat },
        { "mt shoes", MtShoes },
        { "mt shoulder", MtShoulder },
        { "ha pants", HaPants },
        { "ha waist", HaWaist },
        { "ha coat", HaCoat },
        { "ha shoes", HaShoes },
        { "ha shoulder", HaShoulder },
        { "lt waist", LtWaist },
        { "lt coat", LtCoat },
        { "lt shoes", LtShoes },
        { "lt shoulder", LtShoulder },
        { "la pants", LaPants },
        { "la shoes", LaShoes },
        { "la shoulder", LaShoulder },
        { "cl pants", ClPants },
        { "cl waist", ClWaist },
        { "cl coat", ClCoat },
        { "cl shoes", ClShoes },
        { "cl shoulder", ClShoulder },
        { "amulet", AmuletNecklace }
    };

    public static readonly Dictionary<string, string> ElementTranslations = new()
    {
        { "[fire element]", FireElement },
        { "[water element]", WaterElement },
        { "[light element]", LightElement },
        { "[dark element]", DarkElement }
    };
}
