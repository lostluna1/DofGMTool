using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_option", DisableSyncStructure = true)]
public partial class CharacOption
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "best_clear_time", DbType = "blob")]
    public required byte[] BestClearTime { get; set; }

    [JsonProperty, Column(Name = "blue_marble_enter_count")]
    public byte BlueMarbleEnterCount { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_inform_notice", IsNullable = false)]
    public required string CharacInformNotice { get; set; }

    [JsonProperty, Column(Name = "options", DbType = "blob")]
    public required byte[] Options { get; set; }

}
