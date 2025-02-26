using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_quest_party_member_web", DisableSyncStructure = true)]
public partial class EventQuestPartyMemberWeb
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "quest_no", IsPrimary = true)]
    public int QuestNo { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)", IsPrimary = true)]
    public sbyte ServerId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "send_charac_no")]
    public int SendCharacNo { get; set; } = 0;

}
