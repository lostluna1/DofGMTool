using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "db_connect", DisableSyncStructure = true)]
public partial class DbConnect
{

    [JsonProperty, Column(Name = "comments")]
    public string Comments { get; set; }

    [JsonProperty, Column(Name = "db_ip", StringLength = 16, IsNullable = false)]
    public string DbIp { get; set; }

    [JsonProperty, Column(Name = "db_name", StringLength = 50, IsNullable = false)]
    public string DbName { get; set; }

    [JsonProperty, Column(Name = "db_passwd", StringLength = 50, IsNullable = false)]
    public string DbPasswd { get; set; }

    [JsonProperty, Column(Name = "db_port")]
    public uint DbPort { get; set; }

    [JsonProperty, Column(Name = "db_server_group")]
    public byte? DbServerGroup { get; set; }

    [JsonProperty, Column(Name = "db_type")]
    public uint DbType { get; set; }

    [JsonProperty, Column(Name = "db_userid", StringLength = 20, IsNullable = false)]
    public string DbUserid { get; set; }

    [JsonProperty, Column(Name = "host_name", StringLength = 50)]
    public string HostName { get; set; }

    [JsonProperty, Column(Name = "no")]
    public uint No { get; set; } = 0;

}
