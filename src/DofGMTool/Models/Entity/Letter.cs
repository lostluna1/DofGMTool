using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "letter", DisableSyncStructure = true)]
public partial class Letter
{

    [JsonProperty, Column(Name = "letter_id", IsPrimary = true, IsIdentity = true)]
    public int LetterId { get; set; }

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "letter_text", IsNullable = false)]
    public string LetterText { get; set; }

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegDate { get; set; }

    [JsonProperty, Column(Name = "send_charac_name", StringLength = 20, IsNullable = false)]
    public string SendCharacName { get; set; }

    [JsonProperty, Column(Name = "send_charac_no")]
    public int SendCharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "stat", DbType = "tinyint(4)")]
    public sbyte Stat { get; set; } = 0;

}
