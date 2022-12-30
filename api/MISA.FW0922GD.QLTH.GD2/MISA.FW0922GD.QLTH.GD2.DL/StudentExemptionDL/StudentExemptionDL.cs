using Dapper;
using MISA.FW0922GD.QLTH.GD2.Common.Constants;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;
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

        /// <summary>
        /// Lấy danh sách miễn giảm của một học sinh theo ID của học sinh
        /// </summary>
        /// <param name="studentID">ID của học sinh muốn lấy thông tin miễn giảm</param>
        /// <returns>Danh sách các bản ghi thông tin miễn giảm của học sinh tương ứng</returns>
        /// Author: KhaiND (26/12/2022)
        public IEnumerable<StudentExemptionDetail> GetByStudentID(Guid studentID)
        {
            // Chuẩn bị tham số đầu vào
            var parameter = new DynamicParameters();
            parameter.Add("StudentID", studentID);

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = Procedure.SE_GET_BY_STUDENT;

            //Khởi tọa kết nối đến Database MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện gọi truy vấn vào Database
                var studentExemptions = (List<StudentExemptionDetail>)mySqlConnection.Query<StudentExemptionDetail>(storedProcedureName, parameter, commandType: CommandType.StoredProcedure);

                // Xử lý kết quả trả về
                return studentExemptions;
            }    
        }

        /// <summary>
        /// Xóa một bản ghi thông tin miễn giảm của học sinh thông qua ID bản ghi
        /// </summary>
        /// <param name="studentExemptionID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Author: KhaiND (26/12/2022)
        public Guid Delete(Guid studentExemptionID)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("StudentExemptionID", studentExemptionID);

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedure.DELETE, "StudentExemption");

            // Khởi tạo kết nối đến Database MySQL
            int affactedRecordCount = 0;
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện gọi truy vấn vào Database
                affactedRecordCount = mySqlConnection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }

            // Xử lý kết quả trả về
            if (affactedRecordCount > 0)
            {
                return studentExemptionID;
            }
            else
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Xóa đồng thời nhiều bản ghi thông tin miễn giảm của học sinh thông qua danh sách ID
        /// </summary>
        /// <param name="studentExemptionIds">Danh sách ID các bản ghi muốn xóa</param>
        /// <returns>Danh sách ID các bản ghi vừa xóa</returns>
        /// Author: KhaiND (26/12/2022)
        public List<Guid> DeleteMany(List<Guid> studentExemptionIDs)
        {
            // Kiểm tra đầu vào
            var deletedIDs = new List<Guid>();
            if (studentExemptionIDs == null || studentExemptionIDs.Count <= 0)
            {
                return deletedIDs;
            }

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            string listIDString = $"('{String.Join("','", studentExemptionIDs)}')";
            parameters.Add("ListSEIDString", listIDString);

            // Chuẩn bị câu lệnh truy vấn
            string storedProcedureName = String.Format(Procedure.DELETE_MANY, "StudentExemption"); ;

            // Khởi tọa kết nối đến Database MySQL
            int affactedRecordCount = 0;
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                // Sử dụng Transaction
                using (var transaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        // Thực hiện gọi truy vấn xóa nhiều vào Database
                        affactedRecordCount += mySqlConnection.Execute(storedProcedureName, parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);

                        transaction.Commit();
                        mySqlConnection.Close();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        mySqlConnection.Close();
                        Console.WriteLine(ex.Message);
                        affactedRecordCount = 0;
                    }
                }
            }

            // Xử lý kết quả trả về
            if (affactedRecordCount > 0)
            {
                deletedIDs = studentExemptionIDs;
            }
            return deletedIDs;
        }
    }
}