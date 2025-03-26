using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_security_grade", DisableSyncStructure = true)]
public partial class MemberSecurityGrade
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "black_ip_try_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime BlackIpTryTime { get; set; }

    [JsonProperty, Column(Name = "cargopad_mod", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime CargopadMod { get; set; }

    [JsonProperty, Column(Name = "cargopad_status", DbType = "tinyint(4)")]
    public sbyte CargopadStatus { get; set; } = 0;

    [JsonProperty, Column(Name = "cargopad_validity_time")]
    public int CargopadValidityTime { get; set; } = 0;

    [JsonProperty, Column(Name = "gatekeeper_otp_reg", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime GatekeeperOtpReg { get; set; }

    [JsonProperty, Column(Name = "goblin_fail_cnt")]
    public int GoblinFailCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "goblin_pass_mod", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime GoblinPassMod { get; set; }

    [JsonProperty, Column(Name = "goblin_validity_time")]
    public int GoblinValidityTime { get; set; } = 0;

    [JsonProperty, Column(Name = "last_check_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastCheckTime { get; set; }

    [JsonProperty, Column(Name = "last_pass_fail_time")]
    public uint LastPassFailTime { get; set; } = 0;

    [JsonProperty, Column(Name = "last_vaccine_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastVaccineDate { get; set; }

    [JsonProperty, Column(Name = "last_visit_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastVisitTime { get; set; }

    [JsonProperty, Column(Name = "last_window_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastWindowDate { get; set; }

    [JsonProperty, Column(Name = "linear_pass_fail_cnt")]
    public int LinearPassFailCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "m_opt_reg", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime MOptReg { get; set; }

    [JsonProperty, Column(Name = "member_pc_reg", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime MemberPcReg { get; set; }

    [JsonProperty, Column(Name = "pass_fail_cnt")]
    public int PassFailCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "pass_modify_check", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime PassModifyCheck { get; set; }

    [JsonProperty, Column(Name = "pc_opt_reg", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime PcOptReg { get; set; }

    [JsonProperty, Column(Name = "security_card_fail_cnt")]
    public int SecurityCardFailCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "security_card_reg", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime SecurityCardReg { get; set; }

    [JsonProperty, Column(Name = "security_card_validity_time")]
    public int SecurityCardValidityTime { get; set; } = 0;

    [JsonProperty, Column(Name = "validity_ip", StringLength = 15, IsNullable = false)]
    public required string ValidityIp { get; set; }

}
