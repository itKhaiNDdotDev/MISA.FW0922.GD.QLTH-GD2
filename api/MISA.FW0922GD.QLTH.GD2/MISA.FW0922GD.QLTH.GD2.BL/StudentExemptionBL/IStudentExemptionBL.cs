using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.StudentExemption;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;

namespace MISA.FW0922GD.QLTH.GD2.BL.StudentExemptionBL
{
    /// <summary>
    /// Khai báo các method dùng riêng cho BussinessLayer (BL) của thông tin miễn giảm đối với từng học sinh
    /// </summary>
    /// Author: KhaiND (22/12/2022)
    public interface IStudentExemptionBL
    {
        /// <summary>
        /// Lấy danh sách thông tin miễn giảm của các học sinh phân trang theo thứ tự học sinh (theo lớp)
        /// </summary>
        /// <param name="pageIndex">Số trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi trên một trang</param>
        /// <returns>Dánh sách miễn giảm kèm phân trang</returns>
        /// Auhtor: KhaiND (22/12/2022)
        public PagingResult<StudentExemptionRow> GetPagingByStudent(int pageIndex = 1, int pageSize = 30);

        /// <summary>
        /// Lấy danh sách thông tin miễn giảm của các học sinh phân trang theo thứ tự khoản thu
        /// </summary>
        /// <param name="pageIndex">Số trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi trên một trang</param>
        /// <returns>Dánh sách miễn giảm kèm phân trang</returns>
        /// Auhtor: KhaiND (22/12/2022)
        public PagingResult<StudentExemptionRow> GetPagingByFee(int pageIndex = 1, int pageSize = 30);

        /// <summary>
        /// Lấy danh sách miễn giảm của một học sinh theo ID của học sinh
        /// </summary>
        /// <param name="studentID">ID của học sinh muốn lấy thông tin miễn giảm</param>
        /// <returns>Danh sách các bản ghi thông tin miễn giảm của học sinh tương ứng</returns>
        /// Author: KhaiND (26/12/2022)
        public IEnumerable<StudentExemptionDetail> GetByStudentID(Guid studentID);

        /// <summary>
        /// Xóa một bản ghi thông tin miễn giảm của học sinh thông qua ID bản ghi
        /// </summary>
        /// <param name="studentExemptionID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Author: KhaiND (26/12/2022)
        public Guid Delete(Guid studentExemptionID);

        /// <summary>
        /// Xóa đồng thời nhiều bản ghi thông tin miễn giảm của học sinh thông qua danh sách ID
        /// </summary>
        /// <param name="studentExemptionIds">Danh sách ID các bản ghi muốn xóa</param>
        /// <returns>Danh sách ID các bản ghi vừa xóa</returns>
        /// Author: KhaiND (26/12/2022)
        public List<Guid> DeleteMany(List<Guid> studentExemptionIDs);
    }
}
