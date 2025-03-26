using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_game_option", DisableSyncStructure = true)]
public partial class MemberGameOption
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "option_1", DbType = "blob")]
    public required byte[] Option1 { get; set; }

    [JsonProperty, Column(Name = "option_2", DbType = "blob")]
    public required byte[] Option2 { get; set; }

    [JsonProperty, Column(Name = "option_3", DbType = "blob")]
    public required byte[] Option3 { get; set; }

    [JsonProperty, Column(Name = "shortcut_emoticon", DbType = "blob")]
    public required byte[] ShortcutEmoticon { get; set; }

}
