using MISA.FW0922GD.QLTH.GD2.Common.Constants;
using MISA.FW0922GD.QLTH.GD2.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.StudentExemption
{
    /// <summary>
    /// Các thông tin của một bản ghi miễn giảm hiển thị trên Form chi tiết miễn giảm học sinh
    /// </summary>
    /// Author: KhaiND (28/12/2022)
    public class StudentExemptionDetail
    {
        #region Property

        /// <summary>
        /// ID của bản ghi thông tin miễn giảm áp dụng trên học sinh
        /// </summary>
        public Guid StudentExemptionID { get; set; }

        /// <summary>
        /// Khóa ngoại ID của Khoản thu đến bảng Fee trong Database
        /// </summary>
        public int FeeID { get; set; }

        /// <summary>
        /// Tên khoản thu
        /// </summary>
        public string FeeName { get; set; }

        /// <summary>
        /// Khóa ngoại ID của Diện miễn giảm đến bảng Exemption trong Database
        /// </summary>
        public int ExemptionID { get; set; }

        /// <summary>
        /// Tên diện miễn giảm
        /// </summary>
        public string ExemptionName { get; set; }

        /// <summary>
        /// Mức miễn giảm
        /// </summary>
        public decimal StudentExemptionLevel { get; set; }

        /// <summary>
        /// Đơn vị tính mức miễn giảm đang sử dụng có phải là phần trăm (%) hay không
        /// Giá trị mặc định: Percent (1 - tương ứng với true - đang sử dụng đơn vị %)
        /// </summary>
        public LevelUnit StudentExemptionLevelIsUnitByPercent { get; set; }

        /// <summary>
        /// Ngày (tháng) bắt đầu áp dụng miễn giảm
        /// </summary>
        public DateTime StudentExemptionFromDate { get; set; }

        /// <summary>
        /// Ngày (tháng) kết thúc áp dụng miễn giảm
        /// </summary>
        public DateTime StudentExemptionToDate { get; set; }

        #endregion
    }
}
