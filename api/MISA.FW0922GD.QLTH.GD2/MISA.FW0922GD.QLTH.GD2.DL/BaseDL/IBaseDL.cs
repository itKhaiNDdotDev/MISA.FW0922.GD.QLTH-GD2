using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.DL.BaseDL
{
    /// <summary>
    /// Interface định nghĩa các method dùng chung cho DataLayer (DL)
    /// </summary>
    /// <typeparam name="T">Class của đối tượng dữ liệu tương ứng</typeparam>
    /// Author: KhaiND (21/12/2022)
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// Author: KhaiND (21/12/2022)
        public IEnumerable<T> GetAll();

        /// <summary>
        /// Lấy thông tin một bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn lấy</param>
        /// <returns>Thông tin 1 bản ghi theo ID</returns>
        /// Author: KhaiND (21/12/2022)
        public T GetByID(int recordID);

        /// <summary>
        /// TTìm kiếm thông tin thông qua từ khóa theo trường Tên của bản ghi
        /// </summary>
        /// <param name="keyword">Từ khóa để tìm kiếm</param>
        /// <returns>Danh sách các bản ghi tìm thấy</returns>
        /// Author: KhaiND (21/12/2022)
        public IEnumerable<T> GetSearch(string keyword);

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu của bản ghi muốn thêm mới</param>
        /// <returns>ID của bản ghi vừa thêm mới</returns>
        /// Author: KhaiND (21/12/2022)
        public int Insert(T record);

        /// <summary>
        /// Cập nhật thông tin một bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu của bản ghi muốn thay đổi</param>
        /// <returns>ID của bản ghi vừa cập nhật</returns>
        /// Author: KhaiND (21/12/2022)
        public int Update(int recordID, T record);

        /// <summary>
        /// Xóa một bản ghi thông qua ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Author: KhaiND (21/12/2022)
        public int Delete(int recordID);
    }
}
