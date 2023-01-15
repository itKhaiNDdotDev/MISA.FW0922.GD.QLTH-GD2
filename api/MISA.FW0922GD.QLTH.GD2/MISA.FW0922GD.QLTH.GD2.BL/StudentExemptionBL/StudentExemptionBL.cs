using MISA.FW0922GD.QLTH.GD2.Common.Constants;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.StudentExemption;
using MISA.FW0922GD.QLTH.GD2.Common.Enums;
using MISA.FW0922GD.QLTH.GD2.DL.StudentExemptionDL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        public ServiceResult Delete(Guid studentExemptionID)
        {
            // Kiểm tra đầu vào
            if (studentExemptionID == Guid.Empty || studentExemptionID == null)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = GDErrorCode.InvalidData,
                        DevMsg = Common.Resources.Common.Invalid_DevMsg,
                        UserMsg = Common.Resources.Common.Invalid_UserMsg,
                        MoreInfo = Common.Resources.Common.Invalid_MoreInfo
                    }
                };
            }

            var deletedID = _studentExemptionDL.Delete(studentExemptionID);
            if (deletedID != Guid.Empty && deletedID != null)
            {
                return new ServiceResult
                {
                    IsSuccess = true,
                    Data = deletedID
                };
            }
            return new ServiceResult
            {
                IsSuccess = false,
                Data = new ErrorResult
                {
                    ErrorCode = GDErrorCode.DeleteFailed,
                    DevMsg = Common.Resources.Common.DeleteFailed_DevMsg,
                    UserMsg = Common.Resources.Common.DeleteFailed_UserMsg,
                    MoreInfo = Common.Resources.Common.DeleteFailed_UserMsg
                }
            };
        }

        /// <summary>
        /// Xóa đồng thời nhiều bản ghi thông tin miễn giảm của học sinh thông qua danh sách ID
        /// </summary>
        /// <param name="studentExemptionIds">Danh sách ID các bản ghi muốn xóa</param>
        /// <returns>Danh sách ID các bản ghi vừa xóa</returns>
        /// Author: KhaiND (26/12/2022)
        public ServiceResult DeleteMany(List<Guid> studentExemptionIDs)
        {
            // Kiểm tra đầu vào
            if(studentExemptionIDs == null || studentExemptionIDs.Count <= 0)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = GDErrorCode.InvalidData,
                        DevMsg = Common.Resources.Common.Invalid_DevMsg,
                        UserMsg = Common.Resources.Common.Invalid_UserMsg,
                        MoreInfo = Common.Resources.Common.Invalid_MoreInfo
                    }
                };
            }

            var deletedIDs = _studentExemptionDL.DeleteMany(studentExemptionIDs);
            if(deletedIDs.Count > 0)
            {
                return new ServiceResult
                {
                    IsSuccess = true,
                    Data = deletedIDs.ToList()
                };
            }
            return new ServiceResult
            {
                IsSuccess = false,
                Data = new ErrorResult
                {
                    ErrorCode = GDErrorCode.DeleteFailed,
                    DevMsg = Common.Resources.Common.DeleteFailed_DevMsg,
                    UserMsg = Common.Resources.Common.DeleteFailed_UserMsg,
                    MoreInfo = Common.Resources.Common.DeleteFailed_UserMsg
                }
            };
        }

        /// <summary>
        /// Thực hiện lưu dữ liệu thay đổi khi thêm, sửa, xóa đồng thời nhiều bản ghi thông tin miễn giảm
        /// </summary>
        /// <param name="studentExemptions">Đối tượng danh sách dữ liệu đầu vào cho các bản ghi miễn giảm</param>
        /// <returns>Số bản ghi đã affact</returns>
        /// Author: KhaiND (03/01/2022)
        public ServiceResult InsertUpdateDelete(List<StudentExemptionRequest> studentExemptions)
        {
            // Kiểm tra đầy vào
            var listObject = new List<string>();
            if (studentExemptions == null || studentExemptions.Count <= 0)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = GDErrorCode.InvalidData,
                        DevMsg = Common.Resources.Common.Invalid_DevMsg,
                        UserMsg = Common.Resources.Common.Invalid_UserMsg,
                        MoreInfo = Common.Resources.Common.Invalid_MoreInfo
                    }
                };
            }

            // Validate data
            var validateRes = ValidateData(studentExemptions);
            if(!validateRes.IsSuccess)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = GDErrorCode.InvalidData,
                        DevMsg = Common.Resources.Common.Invalid_DevMsg,
                        UserMsg = Common.Resources.Common.Invalid_UserMsg,
                        MoreInfo = new
                        {
                            Detail = validateRes.Data,
                            Common.Resources.Common.Invalid_MoreInfo
                        }
                    }
                };
            }

            // Build string từ đối tượng dữ liệu
            foreach(var item in studentExemptions)
            {
                if (item.Flag == 0)
                {
                    // Thêm trường ID với new Guid()
                    item.StudentExemptionID = Guid.NewGuid();
                }

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
            string listObjectString = $"{String.Join(", ", listObject)}";

            // Gọi đến DL
            return new ServiceResult
            {
                IsSuccess = true,
                Data = new
                {
                    AffactedRows = _studentExemptionDL.InsertUpdateDelete(listObjectString)
                }
            };
            // Xử lý kết quả trả về
        }

        /// <summary>
        /// Định nghĩa cặp StudentID và FeeID phục vụ việc kiểm tra trùng thời gian miễn giảm trong cùng khoản thu đối với một học sinh
        /// </summary>
        /// Author: KhainD (07/01/2023)
        protected class StudentAndFee
        {
            /// <summary>
            /// ID học sinh
            /// </summary>
            internal Guid StudentID { get; set; }
            /// <summary>
            /// ID khoản thu
            /// </summary>
            internal int FeeID { get; set; }
        }

        private ServiceResult ValidateData(List<StudentExemptionRequest> studentExemptions)
        {
            var validateFailures = new List<object>();
            // Duyệt qua từng bản ghi
            var studentAndFees = new List<StudentAndFee>();
            foreach (var studentExemption in studentExemptions)
            {
                // Lấy ID của Khoản thu và học sinh tương ứng (phục vụ kiểm tra trùng thời gian miễn giảm)
                if(studentExemption.StudentID != null && studentExemption.StudentID != Guid.Empty && studentExemption.FeeID != null && studentExemption.FeeID > 0)
                {
                    var studentAndFee = new StudentAndFee
                    {
                        StudentID = studentExemption.StudentID.Value,
                        FeeID = studentExemption.FeeID.Value
                    };
                    if(!studentAndFees.Contains(studentAndFee))
                    {
                        studentAndFees.Add(studentAndFee);
                    }
                }

                var subValidateFailures = new List<string>();
                // Lấy danh sách thuộc tính của Entity và duyêt qua
                var properties = typeof(StudentExemptionRequest).GetProperties();
                foreach (var property in properties)
                {
                    var propertyValue = property.GetValue(studentExemption);
                    // Duyệt qua và Validate các trường thông tin bắt buộc
                    var requiredAttribute = (RequiredAttribute?)Attribute.GetCustomAttribute(property, typeof(RequiredAttribute));
                    if (requiredAttribute != null && (string.IsNullOrEmpty(propertyValue?.ToString()) || propertyValue == null))
                    {
                        subValidateFailures.Add(requiredAttribute.ErrorMessage + ": " + property.Name);
                    }
                }

                // Kiểm tra FromDate > ToDate
                if(studentExemption.StudentExemptionFromDate > studentExemption.StudentExemptionToDate)
                {
                    subValidateFailures.Add(Message.EXEMPTION_TIME_INCORRECT);
                }

                // Push detail vao object loi
                if(subValidateFailures.Count > 0)
                {
                    validateFailures.Add(new
                    {
                        StudentExemptionID = studentExemption.StudentExemptionID,
                        InvalidInfo = subValidateFailures
                    });
                }
            }


            // Kiểm tra trùng thời gian miễn giảm
            foreach(var studentAndFee in studentAndFees)
            {
                var reqRecords = studentExemptions.Where(x => ( x.StudentID == studentAndFee.StudentID && x.FeeID == studentAndFee.FeeID));
                if (reqRecords.Any()) // Không cần thiết lắm
                {
                    // Lấy danh sách bản ghi theo StudentID và FeeID tương ứng từ DL
                    var oldExemptions = _studentExemptionDL.GetByStudentFee(studentAndFee.StudentID, studentAndFee.FeeID);

                    // Loại bỏ các bản ghi có trong request khỏi validate CSDL
                    foreach (var req in reqRecords)
                    {
                        oldExemptions = oldExemptions.Where(x => (x.StudentExemptionID != req.StudentExemptionID));
                    }
                    // Loại bỏ các bản ghi xóa trong request
                    reqRecords = reqRecords.Where(x => x.Flag != 2);

                    if (reqRecords.Any())
                    {
                        for (int i = 0; i < reqRecords.Count() - 1; i++)
                        {
                            var iFromDate = reqRecords.ToList()[i].StudentExemptionFromDate.Value;
                            var iToDate = reqRecords.ToList()[i].StudentExemptionToDate.Value;
                            // Kiểm tra các bản ghi request có trùng thời gian miễn giảm không
                            for (int j = i+1; j < reqRecords.Count(); j++)
                            {
                                var jFromDate = reqRecords.ToList()[j].StudentExemptionFromDate.Value;
                                var jToDate = reqRecords.ToList()[j].StudentExemptionToDate.Value;
                                if (iFromDate >= jFromDate && iFromDate <= jToDate)
                                {
                                    validateFailures.Add(String.Format(Message.EXEMPTION_DUPLICATE_TIME, reqRecords.ToList()[i].FeeID));
                                }
                                else if (iToDate >= jFromDate && iToDate <= jToDate)
                                {
                                    validateFailures.Add(String.Format(Message.EXEMPTION_DUPLICATE_TIME, reqRecords.ToList()[i].FeeID));
                                }
                                else if (jFromDate >= iFromDate && jFromDate <= iToDate)
                                {
                                    validateFailures.Add(String.Format(Message.EXEMPTION_DUPLICATE_TIME, reqRecords.ToList()[i].FeeID));
                                }
                                else if (jToDate >= iFromDate && jToDate <= iToDate)
                                {
                                    validateFailures.Add(String.Format(Message.EXEMPTION_DUPLICATE_TIME, reqRecords.ToList()[i].FeeID));
                                }
                            }    

                            // Kiểm tra các bản ghi request và các bản ghi còn lại trong CSDL có trùng thời gian miễn giảm không
                            if (oldExemptions.Any())
                            {
                                foreach(var keepReocrd in oldExemptions)
                                {
                                    var keepFromDate = keepReocrd.StudentExemptionFromDate;
                                    var keepToDate = keepReocrd.StudentExemptionToDate;
                                    if (iFromDate >= keepFromDate && iFromDate <= keepToDate)
                                    {
                                        validateFailures.Add(String.Format(Message.EXEMPTION_DUPLICATE_TIME, reqRecords.ToList()[i].FeeID));
                                    }
                                    else if (iToDate >= keepFromDate && iToDate <= keepToDate)
                                    {
                                        validateFailures.Add(String.Format(Message.EXEMPTION_DUPLICATE_TIME, reqRecords.ToList()[i].FeeID));
                                    }
                                    else if (keepFromDate >= iFromDate && keepFromDate <= iToDate)
                                    {
                                        validateFailures.Add(String.Format(Message.EXEMPTION_DUPLICATE_TIME, reqRecords.ToList()[i].FeeID));
                                    }
                                    else if (keepToDate >= iFromDate && keepToDate <= iToDate)
                                    {
                                        validateFailures.Add(String.Format(Message.EXEMPTION_DUPLICATE_TIME, reqRecords.ToList()[i].FeeID));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // XỬ lý kết quả trả về
            if (validateFailures.Count > 0)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = validateFailures
                };
            }
            return new ServiceResult { IsSuccess = true };
        }

        #endregion
    }
}
