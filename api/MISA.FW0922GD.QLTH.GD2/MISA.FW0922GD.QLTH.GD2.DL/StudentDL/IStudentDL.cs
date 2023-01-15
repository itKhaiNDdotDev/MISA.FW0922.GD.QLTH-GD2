using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.DL.StudentDL
{
    /// <summary>
    /// Khai báo các method dùng riêng cho DataLayer (DL) đối với dữ liệu Học sinh
    /// </summary>
    /// Author: KhainD (22/12/2022)
    public interface IStudentDL
    {
        /// <summary>
        /// Tìm kiếm học sinh thông qua từ khóa theo Họ và tên
        /// </summary>
        /// <param name="keyword">Từ khóa để tìm kiếm</param>
        /// <returns>Danh sách thông tin các học sinh tìm thấy</returns>
        /// Author: KhaiND (22/12/2022)
        public IEnumerable<StudentResponse> GetSearch(string? keyword);

        /// <summary>
        /// Lấy thông tin một học sinh thông qua ID
        /// </summary>
        /// <param name="studentID">ID của học sinh</param>
        /// <returns>Thông tin chi tiết học sinh</returns>
        /// Author: KhaiND (28/12/2022)
        public StudentResponse GetByID(Guid studentID);
    }
}
