using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_advance_altar", DisableSyncStructure = true)]
public partial class CharacAdvanceAltar
{

    /// <summary>
    /// ﾄｳｸｯﾅﾍｹ?｣
    /// </summary>
    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    /// <summary>
    /// ｺｯｽﾅｸ?ｺﾅﾍ ｾﾆﾀﾌｵ
    /// </summary>
    [JsonProperty, Column(Name = "ridable_id", IsPrimary = true)]
    public int RidableId { get; set; } = 0;

    /// <summary>
    /// ｾ?ﾗｷｹﾀﾌｵ?ｻ?｡ｿ｡ｼｭ ｱｸｸﾅﾇﾑ ｾﾆﾀﾌﾅﾛ ｸｮｽｺﾆｮ
    /// </summary>
    [JsonProperty, Column(Name = "buy_item_list", DbType = "blob")]
    public required byte[] BuyItemList { get; set; }

    /// <summary>
    /// ｽｺﾅﾗﾀﾌﾁ?unlock ﾀﾌﾆ衄ｮｸｦ ｺｸｿｩﾁ狎ﾟ ﾇﾏｴﾂﾁ?
    /// </summary>
    [JsonProperty, Column(Name = "is_unlock_stage_effect")]
    public short IsUnlockStageEffect { get; set; } = 0;

    /// <summary>
    /// ｾ??ｺｸｻ?ｸｮｽｺﾆｮ
    /// </summary>
    [JsonProperty, Column(Name = "reward_list", DbType = "blob")]
    public required byte[] RewardList { get; set; }

    /// <summary>
    /// ｽｽｷﾔ ｸｮｽｺﾆｮ
    /// </summary>
    [JsonProperty, Column(Name = "slot_list", DbType = "blob")]
    public required byte[] SlotList { get; set; }

    /// <summary>
    /// ﾅｬｸｮｾ?ﾑ, ﾀﾔﾀ?ﾇﾒ ｼ?ﾀﾖｴﾂ ｽｺﾅﾗﾀﾌﾁ?ｮｽｺﾆｮ
    /// </summary>
    [JsonProperty, Column(Name = "stage_list", DbType = "blob")]
    public required byte[] StageList { get; set; }

    /// <summary>
    /// ｼｼｶ?･ｿ｡ｼｭ ｱｸｸﾅﾇﾑ ﾀｯｷ?star(ﾁ?｡ﾇﾏｰ?ｰｨｼﾒ ｾ?ｽ)
    /// </summary>
    [JsonProperty, Column(Name = "star_cera")]
    public int StarCera { get; set; } = 0;

    /// <summary>
    /// ｽｺﾅﾗﾀﾌﾁ?ﾅｬｸｮｾ?ｺｸｻ?ｸｷﾎ ｹﾞﾀｺ star (ﾁ?｡ﾇﾏｰ?ｰｨｼﾒ ｾ?ｽ)
    /// </summary>
    [JsonProperty, Column(Name = "star_game")]
    public int StarGame { get; set; } = 0;

    /// <summary>
    /// starｸｦ ﾃﾊｱ篳ｭﾇﾑ ﾈｸｼ?ｱ篳ｹ:ﾃﾊｱ篳ｭ ﾈｽｼ?｡ ｵ??ｺ??ﾌ ｴﾙｸｧ)
    /// </summary>
    [JsonProperty, Column(Name = "star_reset_count")]
    public short StarResetCount { get; set; } = 0;

    /// <summary>
    /// ｻ鄙?｡ｴﾉﾇﾑ star (=ｻ鄙?ﾏｰ?ｳｲﾀｺ star)
    /// </summary>
    [JsonProperty, Column(Name = "star_usable")]
    public int StarUsable { get; set; } = 0;

    /// <summary>
    /// ｼｭｹﾙﾀﾌｹ??蠢｡ｼｭ ﾅｬｸｮｾ?ﾑ ﾃﾖｴ?ｽｺﾅﾗﾀﾌﾁ??｣
    /// </summary>
    [JsonProperty, Column(Name = "survival_best")]
    public short SurvivalBest { get; set; } = 0;

    /// <summary>
    /// ｼｼｶ?･ｿ｡ｼｭ ｱｸｸﾅﾇﾑ ﾀｯｷ眤ﾔﾀ螻ﾇ
    /// </summary>
    [JsonProperty, Column(Name = "ticket_cera")]
    public short TicketCera { get; set; } = 0;

    /// <summary>
    /// ｹｫｷ眤ﾔﾀ螻ﾇ(ｻ鄂ﾅﾀﾇ ﾃﾊｴ??ﾃｳｷｳ ｸﾅﾀﾏ ﾃ､ｿ??
    /// </summary>
    [JsonProperty, Column(Name = "ticket_free")]
    public short TicketFree { get; set; } = 0;

}
