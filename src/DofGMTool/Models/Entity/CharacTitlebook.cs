using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_titlebook", DisableSyncStructure = true)]
public partial class CharacTitlebook
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "despair", DbType = "blob")]
    public required byte[] Despair { get; set; }

    [JsonProperty, Column(Name = "event", DbType = "blob")]
    public required byte[] Event { get; set; }

    [JsonProperty, Column(Name = "general_section", DbType = "blob")]
    public required byte[] GeneralSection { get; set; }

    [JsonProperty, Column(Name = "specific_section", DbType = "blob")]
    public required byte[] SpecificSection { get; set; }

}
