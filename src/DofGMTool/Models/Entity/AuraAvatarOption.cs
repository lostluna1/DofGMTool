using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "aura_avatar_option", DisableSyncStructure = true)]
public partial class AuraAvatarOption
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "option_type", DbType = "tinyint(4)", IsPrimary = true)]
    public sbyte OptionType { get; set; } = 0;

    [JsonProperty, Column(Name = "value_1")]
    public int Value1 { get; set; } = 0;

}
