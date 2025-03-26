using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_files", DisableSyncStructure = true)]
public partial class GuildFiles
{

    [JsonProperty, Column(Name = "gf_no", DbType = "tinyint(4)", IsPrimary = true, IsIdentity = true)]
    public sbyte GfNo { get; set; }

    [JsonProperty, Column(Name = "gno", IsPrimary = true)]
    public int Gno { get; set; } = 0;

    [JsonProperty, Column(Name = "file_location", StringLength = 100, IsNullable = false)]
    public required string FileLocation { get; set; }

    [JsonProperty, Column(Name = "file_server", StringLength = 50, IsNullable = false)]
    public required string FileServer { get; set; }

}
