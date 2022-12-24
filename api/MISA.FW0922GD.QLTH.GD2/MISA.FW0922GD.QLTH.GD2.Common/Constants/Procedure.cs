using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Constants
{
    /// <summary>
    /// Format tên của các Stored Procedure trong Database
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    public class Procedure
    {
        /// <summary>
        /// Các Procedure lấy danh sách tất cả bản ghi
        /// </summary>
        public static string GET_ALL = "Proc_{0}_GetAll";

        /// <summary>
        /// Các Procedure lấy thông tin một bản ghi theo ID
        /// </summary>
        public static string GET_BY_ID = "Proc_{0}_GetByID";

        /// <summary>
        /// Các Procedure tìm kiếm các bản ghi thông qua từ khóa
        /// </summary>
        public static string GET_SEARCH = "Proc_{0}_GetSearch";

        /// <summary>
        /// Các Procedure thêm mới một bản ghi
        /// </summary>
        public static string INSERT = "Proc_{0}_Insert";

        /// <summary>
        /// Các Procedure thêm mới nhiều bản ghi
        /// </summary>
        public static string INSERT_MANY = "Proc_{0}_InsertMany";

        /// <summary>
        /// Các Procedure cập nhật thông tin một bản ghi
        /// </summary>
        public static string UPDATE = "Proc_{0}_Update";

        /// <summary>
        /// Các Procedure xóa một bản ghi
        /// </summary>
        public static string DELETE = "Proc_{0}_DeleteByID";

        /// <summary>
        /// Các Procedure xóa một bản ghi
        /// </summary>
        public static string DELETE_MANY = "Proc_{0}_DeleteMany";

        /// <summary>
        /// Procedure lấy danh sách thông tin miễn giảm của các học sinh (StudentExemption - SE) phân trang và sắp xếp theo Học sinh (Lớp)
        /// </summary>
        public static string SE_GET_PAGING_BY_STUDENT = "Proc_StudentExemption_GetPagingByStudent";

        /// <summary>
        /// Procedure lấy danh sách thông tin miễn giảm của các học sinh (StudentExemption - SE) phân trang và sắp xếp theo Khoản thu
        /// </summary>
        public static string SE_GET_PAGING_BY_FEE = "Proc_StudentExemption_GetPagingByFee";
    }
}
