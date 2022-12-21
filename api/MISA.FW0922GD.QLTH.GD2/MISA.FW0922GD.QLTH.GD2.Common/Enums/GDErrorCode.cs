using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Enums
{
    /// <summary>
    /// Enum định nghĩa các mã lỗi khi có lỗi xảy ra
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    public enum GDErrorCode
    {
        /// <summary>
        /// Lỗi gặp exception
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Lỗi dữ liệu đầu vào không hợp lệ
        /// </summary>
        InvalidData = 2,

        /// <summary>
        /// Thêm mới bản ghi thất bại
        /// </summary>
        InsertFailed = 3,

        /// <summary>
        /// Cập nhật bản ghi thất bại
        /// </summary>
        UpdateFailed = 4,

        /// <summary>
        /// Xóa bản ghi thất bại
        /// </summary>
        DeleteFailed = 5
    }
}
