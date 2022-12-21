using Dapper;
using MISA.FW0922GD.QLTH.GD2.Common.Constants;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.DL.BaseDL
{
    /// <summary>
    /// Class impliment các method dùng chung ở DataLayer (DL)
    /// </summary>
    /// <typeparam name="T">Class của đối tượng dữ liệu tương ứng</typeparam>
    /// Author: KhaiND (21/12/2022)
    public class BaseDL<T> : IBaseDL<T>
    {
        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// Author: KhaiND (21/12/2022)
        public IEnumerable<T> GetAll()
        {
            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedure.GET_ALL, typeof(T).Name);

            // Khởi tạo kết nối đến Database MySQL
            var records = new List<T>();
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện gọi truy vấn vào Database
                records = (List<T>)mySqlConnection.Query<T>(storedProcedureName, commandType: CommandType.StoredProcedure);
            }

            // Xử lý kết quả trả về
            return records;
        }

        /// <summary>
        /// Lấy thông tin một bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn lấy</param>
        /// <returns>Thông tin 1 bản ghi theo ID</returns>
        /// Author: KhaiND (21/12/2022)
        public T GetByID(int recordID)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"{typeof(T).Name}ID", recordID);

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedure.GET_BY_ID, typeof(T).Name);

            // Khởi tạo kết nối đến Database MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện gọi truy vấn vào Database
                var record = mySqlConnection.QueryFirstOrDefault<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                return record;
            }
        }

        /// <summary>
        /// TTìm kiếm thông tin thông qua từ khóa theo trường Tên của bản ghi
        /// </summary>
        /// <param name="keyword">Từ khóa để tìm kiếm</param>
        /// <returns>Danh sách các bản ghi tìm thấy</returns>
        /// Author: KhaiND (21/12/2022)
        public IEnumerable<T> GetSearch(string? keyword)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("keyword", keyword);

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedure.GET_SEARCH, typeof(T).Name);

            // Khởi tạo kết nối đến Database MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện gọi truy vấn vào Database
                var records = mySqlConnection.Query<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                return records;
            }
        }

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu của bản ghi muốn thêm mới</param>
        /// <returns>ID của bản ghi vừa thêm mới</returns>
        /// Author: KhaiND (21/12/2022)
        public int Insert(T record)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            //var newID = Guid.NewGuid();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                object propertyValue;
                // Kiểm tra để lấy trường khóa chính (Key/PrimaryKey) chính là ID của bản ghi
                var primaryKeyAttribute = (KeyAttribute?)Attribute.GetCustomAttribute(property, typeof(KeyAttribute));
                if (primaryKeyAttribute == null)
                {
                    propertyValue = property.GetValue(record, null);
                    parameters.Add($"{propertyName}", propertyValue);
                }
            }

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedure.INSERT, typeof(T).Name);

            // Khởi tạo kết nối đến Database MySQL
            int affactedRecordCount = 0;
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện gọi truy vấn vào Database
                affactedRecordCount = mySqlConnection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }

            //// Xử lý kết quả trả về
            //if (affactedRecordCount > 0)
            //{
            //    return newID;
            //}
            //else
            //{
            //    return Guid.Empty;
            //}
            return affactedRecordCount;
        }

        /// <summary>
        /// Cập nhật thông tin một bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu của bản ghi muốn thay đổi</param>
        /// <returns>ID của bản ghi vừa cập nhật</returns>
        /// Author: KhaiND (21/12/2022)
        public int Update(int recordID, T record)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                object propertyValue;
                // Kiểm tra để lấy trường khóa chính (Key/PrimaryKey) chính là ID của bản ghi
                var primaryKeyAttribute = (KeyAttribute?)Attribute.GetCustomAttribute(property, typeof(KeyAttribute));
                if (primaryKeyAttribute != null)
                {
                    propertyValue = recordID;
                }
                else
                {
                    propertyValue = property.GetValue(record, null);
                }
                parameters.Add($"{propertyName}", propertyValue);
            }

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedure.UPDATE, typeof(T).Name);

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
                return recordID;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Xóa một bản ghi thông qua ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Author: KhaiND (21/12/2022)
        public int Delete(int recordID)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"{typeof(T).Name}ID", recordID);

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procedure.DELETE, typeof(T).Name);

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
                return recordID;
            }
            else
            {
                return -1;
            }
        }
    }
}