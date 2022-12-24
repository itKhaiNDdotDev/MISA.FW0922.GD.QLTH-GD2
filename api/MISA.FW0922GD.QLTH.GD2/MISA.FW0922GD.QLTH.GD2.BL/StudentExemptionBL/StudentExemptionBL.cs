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

        #endregion
    }
}
