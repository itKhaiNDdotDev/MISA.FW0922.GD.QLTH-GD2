using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Entities
{
    /// <summary>
    /// BaseEntity chứa các trường thông tin bắt buộc tái sử dụng ở nhiều Entity
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    public class BaseEntity
    {
        #region Property

        /// <summary>
        /// Thời gian tọa bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Thời gian chỉnh sửa bản ghi lần gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa bản ghi lần gần nhất
        /// </summary>
        public string? ModifiedBy { get; set; }

        #endregion
    }
}
