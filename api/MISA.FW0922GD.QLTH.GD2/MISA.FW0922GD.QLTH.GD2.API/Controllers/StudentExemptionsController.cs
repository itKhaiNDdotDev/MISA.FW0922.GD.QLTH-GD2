using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.BL.StudentExemptionBL;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs;
using MISA.FW0922GD.QLTH.GD2.Common.Enums;
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

        #endregion
    }
}
