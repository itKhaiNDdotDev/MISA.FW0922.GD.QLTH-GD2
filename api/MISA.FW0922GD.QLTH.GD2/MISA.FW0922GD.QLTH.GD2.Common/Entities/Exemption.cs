using MISA.FW0922GD.QLTH.GD2.Common.Constants;
using MISA.FW0922GD.QLTH.GD2.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Entities
{
    /// <summary>
    /// Map với Entity tương ứng Bảng Exemption quản lý thông tin các diện miễn giảm trong Database
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    public class Exemption : BaseEntity
    {
        #region Property

        /// <summary>
        /// ID của diện miễn giảm
        /// </summary>
        [Key]
        public int ExemptionID { get; set; }

        /// <summary>
        /// Tên diện miễn giảm
        /// </summary>
        [Required(ErrorMessage = Message.REQUIRED_DATA)]
        public string ExemptionName { get; set; }

        /// <summary>
        /// Mô tả chi tiết về diện miễn giảm (Ghi rõ các từ viết tắt dùng làm tooltip)
        /// </summary>
        public string ExemptionDescription { get; set; }

        /// <summary>
        /// Mức miễn giảm gợi ý
        /// </summary>
        public decimal ExemptionFixLevel { get; set; }

        /// <summary>
        /// Đơn vị tính mức miễn giảm gợi ý đang sử dụng có phải là phần trăm (%) hay không
        /// Giá trị mặc định: Percent (1 - tương ứng với true - đang sử dụng đơn vị %)
        /// </summary>
        public LevelUnit ExemptionFixLevelIsUnitByPercent { get; set; }

        /// <summary>
        /// Loại diện miễn giảm
        /// Giá trị mặc định: "Ưu tiên"
        /// </summary>
        public string ExemptionType { get; set; }

        #endregion
    }
}
