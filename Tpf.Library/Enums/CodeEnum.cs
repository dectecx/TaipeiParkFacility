using System.ComponentModel;

namespace Tpf.Library.Enums
{
    /// <summary>
    /// 服務叫用狀態
    /// </summary>
    public enum CodeEnum
    {
        /// <summary>
        /// 失敗
        /// </summary>
        [Description("失敗")]
        Fail = 0,
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1,
    }
}
