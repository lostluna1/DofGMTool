using System.ComponentModel;

namespace DofGMTool.Constant;

public enum Pay
{
    /// <summary>
    /// 点卷
    /// </summary>
    [Description("点卷")]
    DMoney,
    /// <summary>
    /// 代币卷
    /// </summary>
    [Description("代币卷")]
    DDot,
    /// <summary>
    /// 金币
    /// </summary>
    [Description("金币")]
    Money,
    /// <summary>
    /// SP点
    /// </summary>
    [Description("SP点")]
    SP,
    /// <summary>
    /// TP点
    /// </summary>
    [Description("TP点")]
    TP,
    /// <summary>
    /// PK等级(1-34)
    /// </summary>
    [Description("PK等级(1-34)")]
    PKLv,
    /// <summary>
    /// 胜利次数
    /// </summary>
    [Description("胜利次数")]
    VictoryCount,
    /// <summary>
    /// 胜利点
    /// </summary>
    [Description("胜利点")]
    VictoryValue
}
