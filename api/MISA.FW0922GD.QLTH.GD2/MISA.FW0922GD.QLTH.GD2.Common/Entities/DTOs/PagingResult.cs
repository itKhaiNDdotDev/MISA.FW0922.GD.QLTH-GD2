using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs
{
    /// <summary>
    /// DTO trả về danh sách dữ liệu tương ứng kèm thông tin phân trang
    /// </summary>
    /// <typeparam name="T">class định kiểu của đối tượng Entity muốn lấy</typeparam>
    /// Author: KhaiND (22/12/2022)
    public class PagingResult<T>
    {
        /// <summary>
        /// Tổng số bản ghi thỏa mãn
        /// </summary>
        public int TotalRecord { get; set; }

        /// <summary>
        /// Đối tượng dữ liệu chứa danh sách chi tiết các bản ghi
        /// </summary>
        public List<T> Data { get; set; }
    }
}
