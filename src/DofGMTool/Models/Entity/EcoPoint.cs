using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models
{

    [JsonObject(MemberSerialization.OptIn), Table(Name = "eco_point", DisableSyncStructure = true)]
    public partial class EcoPoint
    {

        [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
        public uint CharacNo { get; set; } = 0;

        [JsonProperty, Column(Name = "eco_point")]
        public uint Eco_Point { get; set; } = 0;

        [JsonProperty, Column(Name = "point_100", DbType = "tinyint(4)")]
        public sbyte Point100 { get; set; } = 0;

        [JsonProperty, Column(Name = "point_20", DbType = "tinyint(4)")]
        public sbyte Point20 { get; set; } = 0;

        [JsonProperty, Column(Name = "point_300", DbType = "tinyint(4)")]
        public sbyte Point300 { get; set; } = 0;

        [JsonProperty, Column(Name = "point_50", DbType = "tinyint(4)")]
        public sbyte Point50 { get; set; } = 0;

        [JsonProperty, Column(Name = "point_500", DbType = "tinyint(4)")]
        public sbyte Point500 { get; set; } = 0;

    }

}
