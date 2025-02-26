using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_hinamatsuri_cnt", DisableSyncStructure = true)]
public partial class EventHinamatsuriCnt
{

    [JsonProperty, Column(Name = "cnt")]
    public int Cnt { get; set; } = 0;

}
