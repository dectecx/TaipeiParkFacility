using System.Collections.Generic;

namespace Tpf.Library.ViewModels
{
    /// <summary>
    /// 公園模型
    /// </summary>
    public class ParkVModel
    {
        /// <summary>
        /// 公園名稱
        /// </summary>
        public string ParkName { get; set; }
        /// <summary>
        /// 行政區
        /// </summary>
        public string Dict { get; set; }
        /// <summary>
        /// 管理單位
        /// </summary>
        public string ManagementUnit { get; set; }
        /// <summary>
        /// 設施列表
        /// </summary>
        public List<FacilityVModel> facilityList { get; set; }
    }

    /// <summary>
    /// 設施模型
    /// </summary>
    public class FacilityVModel
    {
        /// <summary>
        /// 設施名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public int Cnt { get; set; }
    }
}
