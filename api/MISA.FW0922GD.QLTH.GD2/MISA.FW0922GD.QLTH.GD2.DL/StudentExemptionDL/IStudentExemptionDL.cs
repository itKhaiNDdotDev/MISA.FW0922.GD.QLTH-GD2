using MISA.FW0922GD.QLTH.GD2.Common.Entities;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.StudentExemption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.DL.StudentExemptionDL
{
    /// <summary>
    /// Khai báo các method dùng riêng cho DataLayer (DL) của thông tin miễn giảm đối với từng học sinh
    /// </summary>
    /// Author: KhaiND (22/12/2022)
    public interface IStudentExemptionDL
    {
        /// <summary>
        /// Lấy danh sách thông tin miễn giảm của các học sinh phân trang theo thứ tự học sinh (theo lớp)
        /// </summary>
        /// <param name="offset">Thứ tự bản ghi bắt đầu của trang tính từ 0 trong Database</param>
        /// <param name="limmit">Số lượng bản ghi trên mỗi trang</param>
        /// <returns>Dánh sách miễn giảm kèm phân trang</returns>
        /// Auhtor: KhaiND (22/12/2022)
        public PagingResult<StudentExemptionRow> GetPagingByStudent(int offset = 0, int limmit = 30);

        /// <summary>
        /// Lấy danh sách thông tin miễn giảm của các học sinh phân trang theo thứ tự Khoản thu
        /// </summary>
        /// <param name="offset">Thứ tự bản ghi bắt đầu của trang tính từ 0 trong Database</param>
        /// <param name="limmit">Số lượng bản ghi trên mỗi trang</param>
        /// <returns>Dánh sách miễn giảm kèm phân trang</returns>
        /// Auhtor: KhaiND (22/12/2022)
        public PagingResult<StudentExemptionRow> GetPagingByFee(int offset = 0, int limmit = 30);

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

        /// <summary>
        /// Lưu dữ liệu thêm, sửa, xóa các bản ghi miễn giảm tương ứng
        /// </summary>
        /// <param name="insertListString">Danh sách bản ghi muốn thêm mới đã format thành String</param>
        /// <param name="updateListString">Danh sách bản ghi muốn cập nhật đã format thành String</param>
        /// <param name="deleteListIDString">Danh sách bản ghi muốn xóa đã format thành String</param>
        /// <returns>Tổng số bản ghi đã affact</returns>
        /// Author: KhaiND (03/01/2023)
        //public int InsertUpdateDelete(string insertListString, string updateListString, string deleteListIDString);
        public int InsertUpdateDelete(string listObjectString);

        /// <summary>
        /// Lấy thông tin miễn giảm (ngày bắt đầu và kết thúc áp dụng miễn giảm) theo khoản thu tương ứng học sinh
        /// Phục vụ validate dữ liệu
        /// </summary>
        /// <param name="studentID">ID học sinh</param>
        /// <param name="feeID">ID khoản thu</param>
        /// <returns>Danh sách miễn giảm tương ứng</returns>
        /// Author: KhainD (06/01/2022)
        public IEnumerable<StudentExemptionDetail> GetByStudentFee(Guid studentID, int feeID);
    }
}
