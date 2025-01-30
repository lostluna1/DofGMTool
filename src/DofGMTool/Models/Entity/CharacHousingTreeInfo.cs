using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_housing_tree_info", DisableSyncStructure = true)]
public partial class CharacHousingTreeInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "current_point")]
    public short CurrentPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "day_water_count")]
    public short DayWaterCount { get; set; } = 0;

    [JsonProperty, Column(Name = "expire_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ExpireDate { get; set; }

    [JsonProperty, Column(Name = "leaf_point")]
    public short LeafPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "tree_id")]
    public uint TreeId { get; set; } = 0;

}
