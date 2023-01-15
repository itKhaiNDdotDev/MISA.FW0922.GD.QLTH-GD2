using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.BL.StudentExemptionBL;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.StudentExemption;
using MISA.FW0922GD.QLTH.GD2.Common.Enums;
using MISA.FW0922GD.QLTH.GD2.DL.StudentExemptionDL;
using System.Resources;

namespace MISA.FW0922GD.QLTH.GD2.API.Controllers
{
    /// <summary>
    /// Các API quản lý thông tin miễn giảm áp dụng cho các học sinh tương ứng
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentExemptionsController : BasesController<StudentExemption>
    {
        #region Field

        private IBaseBL<StudentExemption> _baseBL;
        private IStudentExemptionBL _studentExemptionBL;

        #endregion

        #region Constructor

        public StudentExemptionsController(IBaseBL<StudentExemption> baseBL, IStudentExemptionBL studentExemptionBL) : base(baseBL)
        {
            _baseBL = baseBL;
            _studentExemptionBL = studentExemptionBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// API lấy dữ liệu danh sách thông tin miễn giảm áp dụng cho các học sinh có phân trang theo Học sinh (theo Lớp)
        /// </summary>
        /// <param name="pageIndex">Số trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi trên một trang</param>
        /// <returns>Dữ liệu danh sách thông tin miễn giảm kèm phân trang</returns>
        /// Author: KhaiND (22/12/2022)
        [HttpGet("paging/student")]
        public IActionResult GetPagingByStudent([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 30)
        {
            try
            {
                // Không cần xét các trường hợp đầu vào trống vì đã xét trong Dattabase và DL
                var result = _studentExemptionBL.GetPagingByStudent(pageIndex, pageSize);
                if (result == null || result.TotalRecord == 0 || result.Data == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = GDErrorCode.Exception,
                    DevMsg = Common.Resources.Common.Exception_DevMsg,
                    UserMsg = Common.Resources.Common.Exception_UserMsg,
                    MoreInfo = Common.Resources.Common.Exception_MoreInfo,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API lấy dữ liệu danh sách thông tin miễn giảm áp dụng cho các học sinh có phân trang theo khoản thu
        /// </summary>
        /// <param name="pageIndex">Số trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi trên một trang</param>
        /// <returns>Dữ liệu danh sách thông tin miễn giảm kèm phân trang</returns>
        /// Author: KhaiND (22/12/2022)
        [HttpGet("paging/fee")]
        public IActionResult GetPagingByFee([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 30)
        {
            try
            {
                // Không cần xét các trường hợp đầu vào trống vì đã xét trong Dattabase và DL
                var result = _studentExemptionBL.GetPagingByFee(pageIndex, pageSize);
                if (result == null || result.TotalRecord == 0 || result.Data == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = GDErrorCode.Exception,
                    DevMsg = Common.Resources.Common.Exception_DevMsg,
                    UserMsg = Common.Resources.Common.Exception_UserMsg,
                    MoreInfo = Common.Resources.Common.Exception_MoreInfo,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API thực hiện lấy danh sách thông tin miễn giảm của một học sinh tương ứng thông qua ID học sinh
        /// </summary>
        /// <param name="studentID">ID của học sinh muốn lấy thông tin miễn giảm</param>
        /// <returns>Danh sách thông tin miễn giảm tương ứng với học sinh</returns>
        /// Author: KhaiND (26/12/2022)
        [HttpGet("student/{studentID}")]
        public IActionResult GetByStudentID([FromRoute] Guid studentID)
        {
            try
            {
                var studentExemptions = _studentExemptionBL.GetByStudentID(studentID);
                if (studentExemptions == null || studentExemptions.Count() <= 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, studentExemptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = GDErrorCode.Exception,
                    DevMsg = Common.Resources.Common.Exception_DevMsg,
                    UserMsg = Common.Resources.Common.Exception_UserMsg,
                    MoreInfo = Common.Resources.Common.Exception_MoreInfo,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API xóa một bản ghi thông tin miễn giảm thông qua ID
        /// </summary>
        /// <param name="studentExemptionID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Author: KhaiND (26/12/2022)
        [HttpDelete("{studentExemptionID}")]
        public IActionResult Delete([FromRoute] Guid studentExemptionID)
        {
            try
            {
                // Xét trường hợp không tìm thấy
                //var record = _studentExemptionBL.GetByID(studentExemptionID);
                //if (record == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound);
                //}

                // Kiểm tra đầu vào rỗng
                if (studentExemptionID == null || studentExemptionID == Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var result = _studentExemptionBL.Delete(studentExemptionID);
                if (!result.IsSuccess)
                {
                    var errorRes = (ErrorResult)result.Data;
                    errorRes.TraceId = HttpContext.TraceIdentifier;
                    if (errorRes.ErrorCode == GDErrorCode.InvalidData)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, errorRes);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, errorRes);
                    }
                }
                return StatusCode(StatusCodes.Status200OK, result.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = GDErrorCode.Exception,
                    DevMsg = Common.Resources.Common.Exception_DevMsg,
                    UserMsg = Common.Resources.Common.Exception_UserMsg,
                    MoreInfo = Common.Resources.Common.Exception_MoreInfo,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API thực hiện xóa đồng thời danh sách nhiều bản ghi thông tin miễn giảm đối với học sinh thông qua ID của các bản ghi
        /// </summary>
        /// <param name="studentExemptionIDs">ID của các bản ghi</param>
        /// <returns>Danh sách ID các bản ghi đã xóa thành công</returns>
        [HttpPost("deleteMany")]
        public IActionResult DeleteMany([FromBody] List<Guid> studentExemptionIDs)
        {
            try
            {
                // Kiểm tra đầu vào rỗng
                if (studentExemptionIDs == null || studentExemptionIDs.Count <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var result = _studentExemptionBL.DeleteMany(studentExemptionIDs);
                if (!result.IsSuccess)
                {
                    var errorRes = (ErrorResult)result.Data;
                    errorRes.TraceId = HttpContext.TraceIdentifier;
                    if (errorRes.ErrorCode == GDErrorCode.InvalidData)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, errorRes);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, errorRes);
                    }
                }
                return StatusCode(StatusCodes.Status200OK, result.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = GDErrorCode.Exception,
                    DevMsg = Common.Resources.Common.Exception_DevMsg,
                    UserMsg = Common.Resources.Common.Exception_UserMsg,
                    MoreInfo = Common.Resources.Common.Exception_MoreInfo,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API lưu dữ liệu thêm, sửa, xóa đồng thời nhiều bản ghi danh sách miễn giảm của học sinh từ form
        /// </summary>
        /// <param name="studentExemptions">Các bản ghi thêm, sửa, xóa</param>
        /// <returns>Kết quả cập nhật vào Database</returns>
        /// Author: KhaiND (02/01/2023)
        [HttpPost("save")]
        public IActionResult InsertUpdateDelete([FromBody] List<StudentExemptionRequest> studentExemptions)
        {
            try
            {
                // Kiểm tra đầu vào rỗng
                if(studentExemptions == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, studentExemptions);
                }

                var result = _studentExemptionBL.InsertUpdateDelete(studentExemptions);
                if(!result.IsSuccess)
                {
                    var errorRes = (ErrorResult)result.Data;
                    errorRes.TraceId = HttpContext.TraceIdentifier;
                    if(errorRes.ErrorCode == GDErrorCode.InvalidData)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, errorRes);
                    }    
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, errorRes);
                    }
                }
                return StatusCode(StatusCodes.Status200OK, result.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = GDErrorCode.Exception,
                    DevMsg = Common.Resources.Common.Exception_DevMsg,
                    UserMsg = Common.Resources.Common.Exception_UserMsg,
                    MoreInfo = Common.Resources.Common.Exception_MoreInfo,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        #endregion
    }
}
