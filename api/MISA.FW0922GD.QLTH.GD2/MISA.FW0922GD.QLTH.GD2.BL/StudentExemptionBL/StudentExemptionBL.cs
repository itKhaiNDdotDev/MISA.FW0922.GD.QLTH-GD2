using MISA.FW0922GD.QLTH.GD2.Common.Entities;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.StudentExemption;
using MISA.FW0922GD.QLTH.GD2.DL.StudentExemptionDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.BL.StudentExemptionBL
{
    /// <summary>
    /// Impliment các method dùng riêng cho BussinessLayer (BL) của thông tin miễn giảm đối với từng học sinh
    /// </summary>
    /// Author: KhaiND (22/12/2022)
    public class StudentExemptionBL : IStudentExemptionBL
    {
        #region Field

        private IStudentExemptionDL _studentExemptionDL;

        #endregion

        #region Constructor

        public StudentExemptionBL(IStudentExemptionDL studentExemptionDL)
        {
            _studentExemptionDL = studentExemptionDL;
        }

        #endregion


        #region Method

        /// <summary>
        /// Lấy danh sách thông tin miễn giảm của các học sinh phân trang theo thứ tự học sinh (theo lớp)
        /// </summary>
        /// <param name="pageIndex">Số trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi trên một trang</param>
        /// <returns>Dánh sách miễn giảm kèm phân trang</returns>
        /// Auhtor: KhaiND (22/12/2022)
        public PagingResult<StudentExemptionRow> GetPagingByStudent(int pageIndex = 1, int pageSize = 30)
        {
            int offset, limit;
            if (pageIndex < 1)
            {
                offset = 0;
            }
            else
            {
                offset = (pageIndex - 1) * pageSize;
            }

            if (pageSize < 1)
            {
                limit = 1;
            }
            else
            {
                limit = pageSize;
            }

            return _studentExemptionDL.GetPagingByStudent(offset, limit);
        }

        /// <summary>
        /// Lấy danh sách thông tin miễn giảm của các học sinh phân trang theo thứ tự khoản thu
        /// </summary>
        /// <param name="pageIndex">Số trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi trên một trang</param>
        /// <returns>Dánh sách miễn giảm kèm phân trang</returns>
        /// Auhtor: KhaiND (22/12/2022)
        public PagingResult<StudentExemptionRow> GetPagingByFee(int pageIndex = 1, int pageSize = 30)
        {
            int offset, limit;
            if (pageIndex < 1)
            {
                offset = 0;
            }
            else
            {
                offset = (pageIndex - 1) * pageSize;
            }

            if (pageSize < 1)
            {
                limit = 1;
            }
            else
            {
                limit = pageSize;
            }

            return _studentExemptionDL.GetPagingByFee(offset, limit);
        }

        /// <summary>
        /// Lấy danh sách miễn giảm của một học sinh theo ID của học sinh
        /// </summary>
        /// <param name="studentID">ID của học sinh muốn lấy thông tin miễn giảm</param>
        /// <returns>Danh sách các bản ghi thông tin miễn giảm của học sinh tương ứng</returns>
        /// Author: KhaiND (26/12/2022)
        public IEnumerable<StudentExemptionDetail> GetByStudentID(Guid studentID)
        {
            return _studentExemptionDL.GetByStudentID(studentID);
        }

        /// <summary>
        /// Xóa một bản ghi thông tin miễn giảm của học sinh thông qua ID bản ghi
        /// </summary>
        /// <param name="studentExemptionID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Author: KhaiND (26/12/2022)
        public Guid Delete(Guid studentExemptionID)
        {
            return _studentExemptionDL.Delete(studentExemptionID);
        }

        /// <summary>
        /// Xóa đồng thời nhiều bản ghi thông tin miễn giảm của học sinh thông qua danh sách ID
        /// </summary>
        /// <param name="studentExemptionIds">Danh sách ID các bản ghi muốn xóa</param>
        /// <returns>Danh sách ID các bản ghi vừa xóa</returns>
        /// Author: KhaiND (26/12/2022)
        public List<Guid> DeleteMany(List<Guid> studentExemptionIDs)
        {
            return _studentExemptionDL.DeleteMany(studentExemptionIDs);
        }

        #endregion
    }
}
