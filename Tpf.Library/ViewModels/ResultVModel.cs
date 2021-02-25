using Tpf.Library.Enums;

namespace Tpf.Library.ViewModels
{
    /// <summary>
    /// 回應前端訊息用模型 - 附帶回傳物件
    /// </summary>
    public class ResultVModel
    {
        /// <summary>
        /// 服務叫用狀態
        /// </summary>
        public CodeEnum Code { get; set; } = CodeEnum.Fail;
        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string Message { get; set; } = "";
    }

    /// <summary>
    /// 回應前端訊息用模型 - 附帶回傳物件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultVModel<T>
    {
        /// <summary>
        /// 服務叫用狀態
        /// </summary>
        public CodeEnum Code { get; set; } = CodeEnum.Fail;
        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string Message { get; set; } = "";
        /// <summary>
        /// 回傳資料
        /// </summary>
        public T Data { get; set; }
    }
}
