using MISA.FW0922GD.QLTH.GD2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.StudentExemption
{
    /// <summary>
    /// DTO định nghĩa các thông tin muốn lấy về cho mỗi bản ghi trên bảng dữ liệu miễn giảm áp dụng cho các học sinh tương ứng
    /// </summary>
    /// Author: KhaiND (22/12/2022)
    public class StudentExemptionRow
    {
        /// <summary>
        /// ID của bản ghi thông tin miễn giảm
        /// </summary>
        public Guid StudentExemptionID { get; set; }

        /// <summary>
        /// ID của học sinh
        /// </summary>
        public Guid StudentID { get; set; }

        /// <summary>
        /// Họ và tên học sinh
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// Ngày sinh của học sinh
        /// </summary>
        public DateTime? StudentDateOfBirth { get; set; }

        /// <summary>
        /// Tên lớp tương ứng với học sinh
        /// </summary>
        public string BranchName { get; set; }
        
        /// <summary>
        /// Mức miễn giảm
        /// </summary>
        public decimal StudentExemptionLevel { get; set; }

        /// <summary>
        /// Đơn vị tính mức miễn giảm có là phần trăm (%) hay không?
        /// </summary>
        public LevelUnit StudentExemptionLevelIsUnitByPercent { get; set; }

        /// <summary>
        /// Tên khoản thu
        /// </summary>
        public string FeeName { get; set; }

        /// <summary>
        /// Thời gian áp dụng miễn giảm
        /// </summary>
        public string StudentExemptionTime { get; set; }

        /// <summary>
        /// Tên diện miễn giảm
        /// </summary>
        public string ExemptionName { get; set; }
    }
}