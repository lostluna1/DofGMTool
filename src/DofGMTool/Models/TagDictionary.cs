namespace DofGMTool.Models;

public static class TagDictionary
{
    public static readonly Dictionary<string, string> EquipmentTypeTranslations = new()
    {
        { "[amulet]", "护身符" },
        { "[artifact blue]", "宠物装备 蓝" },
        { "[artifact green]", "宠物装备 绿" },
        { "[artifact red]", "宠物装备 红" },
        { "[aurora avatar]", "光环" },
        { "[breast avatar]", "胸部头像" },
        { "[coat avatar]", "上衣装扮" },
        { "[coat]", "胸甲" },
        { "[creature]", "宠物" },
        { "[face avatar]", "面部装扮" },
        { "[hair avatar]", "头发装扮" },
        { "[hat avatar]", "帽子装扮" },
        { "[magic stone]", "魔法石" },
        { "[pants avatar]", "裤子装扮" },
        { "[pants]", "护腿" },
        { "[ring]", "戒指" },
        { "[shoes avatar]", "鞋子装扮" },
        { "[shoes]", "鞋子" },
        { "[shoulder]", "肩膀" },
        { "[skin avatar]", "皮肤装扮" },
        { "[support]", "辅助装备" },
        { "[title name]", "称号" },
        { "[waist avatar]", "腰部装扮" },
        { "[waist]", "腰带" },
        { "[weapon]", "武器" },
        { "[wrist]", "手镯" }
    };

    public static readonly Dictionary<string, string> AttachTypeTranslations = new()
    {
        { "[free]", "不限制" },
        { "[sealing]", "封装" },
        { "[trade]", "不可交易" },
        { "[account]", "帐号绑定" },
        { "[trade delete]", "无法交易、删除" },
        { "[sealing trade]", "封装且不可交易" }
    };
    public static readonly Dictionary<string, string> CharacterTypeTranslations = new()
    {
        { "creatormage", "缔造者" },
        { "all]", "所有角色" },
        { "swordman", "鬼剑士" },
        { "demonicswordman", "黑暗武士" },
        { "fighter", "格斗家(女)" },
        { "atfighter", "格斗家(男)" },
        { "gunner", "神枪手(男)" },
        { "atgunner", "神枪手(女)" },
        { "mage", "魔法师(女)" },
        { "atmage", "魔法师(男)" },
        { "priest", "圣职者" },
        { "thief", "暗夜使者" }
    };
    public static readonly Dictionary<string, string> UsableJobTranslations = new()
    {
        { "[creator mage]", "缔造者" },
        { "[all]", "所有角色" },
        { "[swordman]", "鬼剑士" },
        { "[demonic swordman]", "黑暗武士" },
        { "[fighter]", "格斗家(女)" },
        { "[at fighter]", "格斗家(男)" },
        { "[gunner]", "神枪手(男)" },
        { "[at gunner]", "神枪手(女)" },
        { "[mage]", "魔法师(女)" },
        { "[at mage]", "魔法师(男)" },
        { "[priest]", "圣职者" },
        { "[thief]", "暗夜使者" }
    };

    public static readonly Dictionary<string, string> EquipmentGroupTypeTranslations = new()
        {
        { "ssword", "短剑" },
        { "totem", "图腾" },
        { "axe", "巨斧" },
        { "katana", "太刀" },
        { "automatic", "自动步枪" },
        { "club", "钝器" },
        { "lswd", "巨剑" },
        { "beamswd", "光剑" },
        { "knuckle", "手套" },
        { "claw", "爪" },
        { "tonfa", "东方棍" },
        { "gauntlet", "臂铠" },
        { "hcannon", "手炮" },
        { "wrist", "手镯" },
        { "la coat", "上衣" },
        { "lt pants", "裤子" },
        { "la waist", "腰带" },
        { "magic stone", "魔法石(左右槽)" },
        { "mt pants", "板甲下装" },
        { "mt waist", "板甲腰带" },
        { "mt coat", "板甲上衣" },
        { "mt shoes", "板甲鞋子" },
        { "mt shoulder", "板甲护肩" },
        { "ha pants", "重甲下装" },
        { "ha waist", "重甲腰带" },
        { "ha coat", "重甲上衣" },
        { "ha shoes", "重甲鞋子" },
        { "ha shoulder", "重甲护肩" },
        { "lt waist", "皮甲腰带" },
        { "lt coat", "皮甲上衣" },
        { "lt shoes", "皮甲鞋子" },
        { "lt shoulder", "皮甲护肩" },
        { "la pants", "轻甲下装" },
        { "la shoes", "轻甲鞋子" },
        { "la shoulder", "轻甲护肩" },
        { "cl pants", "布甲下装" },
        { "cl waist", "布甲腰带" },
        { "cl coat", "布甲上衣" },
        { "cl shoes", "布甲鞋子" },
        { "cl shoulder", "布甲护肩" },
        { "amulet", "项链" }
    };
    public static readonly Dictionary<string, string> ElementTranslations = new()
    {
        { "[fire element]", "火属性" },
        { "[water element]", "冰属性" },
        { "[light element]", "光属性" },
        { "[dark element]", "暗属性" }
    };

}
