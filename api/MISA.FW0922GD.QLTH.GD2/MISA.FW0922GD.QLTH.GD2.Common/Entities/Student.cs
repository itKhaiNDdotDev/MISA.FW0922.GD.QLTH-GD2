using MISA.FW0922GD.QLTH.GD2.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Entities
{
    /// <summary>
    /// Map với Entity tương ứng bảng Student quản lý thông tin Học sinh trong Database
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    public class Student : BaseEntity
    {
        #region Property

        /// <summary>
        /// ID của học sinh
        /// </summary>
        [Key]
        public Guid StudentID { get; set; }

        /// <summary>
        /// Mã định danh học sinh
        /// Trường thông tin bắt buộc và Unique
        /// </summary>
        [Required(ErrorMessage = Message.STUDENT_REQUIRED_CODE)]
        public string StudentCode { get; set; }

        /// <summary>
        /// Họ và tên học sinh
        /// Trường thông tin bắt buộc
        /// </summary>
        [Required(ErrorMessage = Message.STUDENT_REQUIRED_NAME)]
        public string StudentName { get; set; }

        /// <summary>
        /// Ngày sinh của học sinh
        /// Chỉ lấy dữ liệu phần ngày (Date)
        /// </summary>
        public DateTime? StudentDateOfBirth { get; set; }

        /// <summary>
        /// ID của Lớp làm khóa ngoại phụ thuộc trong Database để xác định Học sinh thuộc lớp (Branch - Class) nào
        /// </summary>
        public int? BranchID { get; set; }

        #endregion
    }
}
