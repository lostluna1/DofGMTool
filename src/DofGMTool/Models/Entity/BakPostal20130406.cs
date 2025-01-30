using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_postal_20130406", DisableSyncStructure = true)]
public partial class BakPostal20130406
{

    [JsonProperty, Column(Name = "receive_charac_no")]
    public int ReceiveCharacNo { get; set; } = 0;

}
