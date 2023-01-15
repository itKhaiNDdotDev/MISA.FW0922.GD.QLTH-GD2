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
    public class StudentExemptionRequest : BaseEntity
    {
        /// <summary>
        /// ID của bản ghi thông tin miễn giảm áp dụng trên học sinh
        /// </summary>
        public Guid? StudentExemptionID { get; set; }

        /// <summary>
        /// ID của học sinh
        /// </summary>
        [Required(ErrorMessage = Message.STUDENT_REQUIRED)]
        public Guid? StudentID { get; set; }

        /// <summary>
        /// Khóa ngoại ID của Khoản thu đến bảng Fee trong Database
        /// </summary>
        [Required(ErrorMessage = Message.REQUIRED_DATA)]
        public int? FeeID { get; set; }

        /// <summary>
        /// Khóa ngoại ID của Diện miễn giảm đến bảng Exemption trong Database
        /// </summary>
        [Required(ErrorMessage = Message.REQUIRED_DATA)]
        public int? ExemptionID { get; set; }

        /// <summary>
        /// Mức miễn giảm
        /// </summary>
        [Required(ErrorMessage = Message.REQUIRED_DATA)]
        public decimal? StudentExemptionLevel { get; set; }

        /// <summary>
        /// Đơn vị tính mức miễn giảm đang sử dụng có phải là phần trăm (%) hay không
        /// Giá trị mặc định: Percent (1 - tương ứng với true - đang sử dụng đơn vị %)
        /// </summary>
        [Required(ErrorMessage = Message.REQUIRED_DATA)]
        public LevelUnit? StudentExemptionLevelIsUnitByPercent { get; set; }

        /// <summary>
        /// Ngày (tháng) bắt đầu áp dụng miễn giảm
        /// </summary>
        [Required(ErrorMessage = Message.REQUIRED_DATA)]
        public DateTime? StudentExemptionFromDate { get; set; }

        /// <summary>
        /// Ngày (tháng) kết thúc áp dụng miễn giảm
        /// </summary>
        [Required(ErrorMessage = Message.REQUIRED_DATA)]
        public DateTime? StudentExemptionToDate { get; set; }

        public int Flag { get; set; }
    }
}
