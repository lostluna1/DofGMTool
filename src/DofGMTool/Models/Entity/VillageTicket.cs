using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "village_ticket", DisableSyncStructure = true)]
public partial class VillageTicket
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "village", IsPrimary = true)]
    public ushort Village { get; set; } = 0;

}
