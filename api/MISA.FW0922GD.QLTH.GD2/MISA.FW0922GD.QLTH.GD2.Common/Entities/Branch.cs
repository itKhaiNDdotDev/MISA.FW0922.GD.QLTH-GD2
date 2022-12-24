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
    /// Map với Entity tương ứng Bảng Branch quản lý thông tin các Lớp (Class - không dùng từ này vì trùng từ khóa) trong Database
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    public class Branch : BaseEntity
    {
        #region Property

        /// <summary>
        /// ID của lớp
        /// </summary>
        [Key]
        public int BranchID { get; set; }

        /// <summary>
        /// Tên lớp
        /// </summary>
        [Required(ErrorMessage = Message.REQUIRED_DATA)]
        public string BranchName { get; set; }

        #endregion
    }
}
