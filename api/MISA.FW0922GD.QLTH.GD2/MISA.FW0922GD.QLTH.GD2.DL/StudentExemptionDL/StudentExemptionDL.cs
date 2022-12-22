using Dapper;
using MISA.FW0922GD.QLTH.GD2.Common.Constants;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.StudentExemption;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.DL.StudentExemptionDL
{
    /// <summary>
    /// Impliment các method dùng riêng cho DataLayer (DL) của thông tin miễn giảm đối với từng học sinh
    /// </summary>
    /// Author: KhaiND (22/12/2022)
    public class StudentExemptionDL : IStudentExemptionDL
    {
        /// <summary>
        /// Lấy danh sách thông tin miễn giảm của các học sinh phân trang theo thứ tự học sinh (theo lớp)
        /// </summary>
        /// <param name="offset">Thứ tự bản ghi bắt đầu của trang tính từ 0 trong Database</param>
        /// <param name="limmit">Số lượng bản ghi trên mỗi trang</param>
        /// <returns>Dánh sách miễn giảm kèm phân trang</returns>
        /// Auhtor: KhaiND (22/12/2022)
        public PagingResult<StudentExemptionRow> GetPagingByStudent(int offset = 0, int limmit = 30)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("offset", offset);
            parameters.Add("limit", limmit);

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedure.SE_GET_PAGING_BY_STUDENT;

            // Khởi tọa kết nối đến Database MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện gọi truy vấn vào Database
                var multiResult = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                // Xử lý kết quả trả về
                var studentExemptions = multiResult.Read<StudentExemptionRow>().ToList();
                int totalRecord = multiResult.Read<int>().Single();
                return new PagingResult<StudentExemptionRow>
                {
                    TotalRecord = totalRecord,
                    Data = studentExemptions
                };
            }
        }

        /// <summary>
        /// Lấy danh sách thông tin miễn giảm của các học sinh phân trang theo thứ tự khoản thu
        /// </summary>
        /// <param name="offset">Thứ tự bản ghi bắt đầu của trang tính từ 0 trong Database</param>
        /// <param name="limmit">Số lượng bản ghi trên mỗi trang</param>
        /// <returns>Dánh sách miễn giảm kèm phân trang</returns>
        /// Auhtor: KhaiND (22/12/2022)
        public PagingResult<StudentExemptionRow> GetPagingByFee(int offset = 0, int limmit = 30)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("offset", offset);
            parameters.Add("limit", limmit);

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedure.SE_GET_PAGING_BY_FEE;

            // Khởi tọa kết nối đến Database MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện gọi truy vấn vào Database
                var multiResult = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                // Xử lý kết quả trả về
                var studentExemptions = multiResult.Read<StudentExemptionRow>().ToList();
                int totalRecord = multiResult.Read<int>().Single();
                return new PagingResult<StudentExemptionRow>
                {
                    TotalRecord = totalRecord,
                    Data = studentExemptions
                };
            }
        }
    }
}
