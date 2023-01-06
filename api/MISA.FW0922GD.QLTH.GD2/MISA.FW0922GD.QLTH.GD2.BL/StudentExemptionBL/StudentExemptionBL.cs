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

        /// <summary>
        /// Thực hiện lưu dữ liệu thay đổi khi thêm, sửa, xóa đồng thời nhiều bản ghi thông tin miễn giảm
        /// </summary>
        /// <param name="studentExemptions">Đối tượng danh sách dữ liệu đầu vào cho các bản ghi miễn giảm</param>
        /// <returns>Số bản ghi đã affact</returns>
        /// Author: KhaiND (03/01/2022)
        public int InsertUpdateDelete(List<StudentExemptionRequest> studentExemptions)
        {
            // Kiểm tra đầu vào
            // VALIIDATE BACKEND
            //var insertRecords = new List<string>();
            //var updateRecords = new List<string>();
            //var deleteIDs = new List<Guid>();
            var listObject = new List<string>();
            if (studentExemptions == null || studentExemptions.Count <= 0)
            {
                return 0;
            }

            // Build string từ đối tượng dữ liệu
            foreach(var item in studentExemptions)
            {
                if (item.Flag == 0)
                {
                    // Bỏ trường flag đi
                    // Thêm trường ID với new Guid()
                    item.StudentExemptionID = Guid.NewGuid();
                    // Kiểm tra các trường dữ liệu cần thiết
                    //var temp = item.Select( x => new
                    //{
                    //    x.StudentExemptionID,
                    //    x.StudentID,
                    //    x.FeeUD,
                    //    x.ExemptionID,
                    //    x.StudentExemptionLevel,
                    //    x.StudentExemptionLevelIsUnitByPercent,
                    //    x.StudentExemptionFromDate,
                    //    x.StudentExemptionToDate,
                    //    x.CreatedDate,
                    //    x.CreatedBy,
                    //    x.ModifiedDate,
                    //    x.ModifiedBy
                    //}).ToList();
                    //var temp = $"('{item.StudentExemptionID}', '{item.StudentID}', '{item.FeeID}','{item.ExemptionID}', " +
                    //    $"'{item.StudentExemptionLevel}', '{((int?)item.StudentExemptionLevelIsUnitByPercent)}', " +
                    //    $"'{item.StudentExemptionFromDate}', '{item.StudentExemptionToDate}', " +
                    //    $"'{item.CreatedDate}', '{item.CreatedBy}', '{item.ModifiedDate}', '{item.ModifiedBy}')";
                    //insertRec```ords.Add(item);
                    //insertRecords.Add(temp);
                }
                //if (item.Flag == 1)
                //{
                //    // Bỏ trường flag đi
                //    // Kiểm tra các trường dữ liệu cần thiết
                //    item.ModifiedDate = DateTime.Now;
                //    item.ModifiedBy = "KhaiND";
                //    var temp = $"('{item.StudentExemptionID}', '{item.StudentID}', '{item.FeeID}','{item.ExemptionID}', " +
                //        $"'{item.StudentExemptionLevel}', '{((int)item.StudentExemptionLevelIsUnitByPercent.Value)}', " +
                //        $"'{item.StudentExemptionFromDate.Value.ToString("yyyy-MM-dd")}', '{item.StudentExemptionToDate.Value.ToString("yyyy-MM-dd")}', " +
                //        $"'{item.ModifiedDate.Value.ToString("yyyy-MM-dd")}', '{item.ModifiedBy}')";
                //    updateRecords.Add(temp);
                //}
                //if(item.Flag == 2 && item.StudentExemptionID != null)
                //{
                //    deleteIDs.Add(item.StudentExemptionID.Value);
                //}

                item.CreatedDate = DateTime.Now;
                item.CreatedBy = "KhaiND";
                item.ModifiedDate = DateTime.Now;
                item.ModifiedBy = "KhaiND";
                var temp = $"('{item.StudentExemptionID}', '{item.StudentID}', '{item.FeeID}','{item.ExemptionID}', " +
                    $"'{item.StudentExemptionLevel}', '{((int?)item.StudentExemptionLevelIsUnitByPercent)}', " +
                    $"'{item.StudentExemptionFromDate.Value.ToString("yyyy-MM-dd")}', '{item.StudentExemptionToDate.Value.ToString("yyyy-MM-dd")}', " +
                    $"'{item.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm:ss")}', '{item.CreatedBy}', '{item.ModifiedDate.Value.ToString("yyyy-MM-dd HH:mm:ss")}', '{item.ModifiedBy}', " +
                    $"'{item.Flag}')";
                listObject.Add(temp);
            }
            //string insertListString = $"{String.Join(", ", insertRecords)}";
            //string updateListString = $"{String.Join(", ", updateRecords)}";
            //string deleteListIDString = $"('{String.Join("','", deleteIDs)}')";
            string listObjectString = $"{String.Join(", ", listObject)}";

            // Gọi đến DL
            return _studentExemptionDL.InsertUpdateDelete(listObjectString);
            // Xử lý kết quả trả về
        }

        #endregion
    }
}
