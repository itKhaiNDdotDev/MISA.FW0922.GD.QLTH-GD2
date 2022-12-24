using Dapper;
using MISA.FW0922GD.QLTH.GD2.Common.Constants;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.Student;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.DL.StudentDL
{
    /// <summary>
    /// Impliment các method dùng riêng cho DataLayer (DL) đối với dữ liệu Học sinh
    /// </summary>
    /// Author: KhainD (22/12/2022)
    public class StudentDL : IStudentDL
    {
        /// <summary>
        /// Tìm kiếm học sinh thông qua từ khóa theo Họ và tên
        /// </summary>
        /// <param name="keyword">Từ khóa để tìm kiếm</param>
        /// <returns>Danh sách thông tin các học sinh tìm thấy</returns>
        /// Author: KhaiND (22/12/2022)
        public IEnumerable<StudentResponse> GetSearch(string? keyword)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("keyword", keyword);

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedure.GET_SEARCH, "Student");

            // Khởi tạo kết nối đến Database MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện gọi truy vấn vào Database
                var records = mySqlConnection.Query<StudentResponse>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                return records;
            }
        }
    }
}
