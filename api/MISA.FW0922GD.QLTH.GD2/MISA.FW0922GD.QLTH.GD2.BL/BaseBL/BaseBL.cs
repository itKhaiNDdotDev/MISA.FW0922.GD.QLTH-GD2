using MISA.FW0922GD.QLTH.GD2.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.BL.BaseBL
{
    /// <summary>
    /// Impliment các method dùng chung cho DataLayer (DL)
    /// </summary>
    /// <typeparam name="T">Class của đối tượng dữ liệu tương ứng</typeparam>
    /// Author: KhaiND (21/12/2022)
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// Author: KhaiND (21/12/2022)
        public IEnumerable<T> GetAll()
        {
            return _baseDL.GetAll();
        }

        /// <summary>
        /// Lấy thông tin một bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn lấy</param>
        /// <returns>Thông tin 1 bản ghi theo ID</returns>
        /// Author: KhaiND (21/12/2022)
        public T GetByID(int recordID)
        {
            return _baseDL.GetByID(recordID);
        }

        /// <summary>
        /// TTìm kiếm thông tin thông qua từ khóa theo trường Tên của bản ghi
        /// </summary>
        /// <param name="keyword">Từ khóa để tìm kiếm</param>
        /// <returns>Danh sách các bản ghi tìm thấy</returns>
        /// Author: KhaiND (21/12/2022)
        public IEnumerable<T> GetSearch(string keyword)
        {
            return _baseDL.GetSearch(keyword);
        }

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu của bản ghi muốn thêm mới</param>
        /// <returns>ID của bản ghi vừa thêm mới</returns>
        /// Author: KhaiND (21/12/2022)
        public int Insert(T record)
        {
            return _baseDL.Insert(record);
        }

        /// <summary>
        /// Cập nhật thông tin một bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu của bản ghi muốn thay đổi</param>
        /// <returns>ID của bản ghi vừa cập nhật</returns>
        /// Author: KhaiND (21/12/2022)
        public int Update(int recordID, T record)
        {
            return _baseDL.Update(recordID, record);
        }

        /// <summary>
        /// Xóa một bản ghi thông qua ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Author: KhaiND (21/12/2022)
        public int Delete(int recordID)
        {
            return _baseDL.Delete(recordID);
        }

        #endregion
    }
}
