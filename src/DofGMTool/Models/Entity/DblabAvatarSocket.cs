using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "dblab_avatar_socket", DisableSyncStructure = true)]
public partial class DblabAvatarSocket
{

    [JsonProperty, Column(Name = "it_id", IsPrimary = true)]
    public int ItId { get; set; } = 0;

    [JsonProperty, Column(Name = "jewel_socket", StringLength = 600)]
    public string JewelSocket { get; set; }

}
