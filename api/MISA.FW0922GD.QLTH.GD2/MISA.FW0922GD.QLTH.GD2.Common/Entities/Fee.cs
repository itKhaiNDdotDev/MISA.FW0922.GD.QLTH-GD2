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
    /// Đối tượng map với Entity tương ứng bảng Fee quản lý thông tin các Khoản thu trong Database
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    public class Fee : BaseEntity
    {
        #region Property

        /// <summary>
        /// ID của khoản thu
        /// </summary>
        [Key]
        public int FeeID { get; set; }

        /// <summary>
        /// Tên khoản thu
        /// </summary>
        [Required(ErrorMessage = Message.REQUIRED_DATA)]
        public string FeeName { get; set; }

        /// <summary>
        /// Đơn giá
        /// </summary>
        public decimal FeePrice { get; set; }

        #endregion
    }
}
