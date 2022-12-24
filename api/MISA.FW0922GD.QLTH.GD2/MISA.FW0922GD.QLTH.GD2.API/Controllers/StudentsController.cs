using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.BL.StudentBL;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs;
using MISA.FW0922GD.QLTH.GD2.Common.Enums;

namespace MISA.FW0922GD.QLTH.GD2.API.Controllers
{
    /// <summary>
    /// Các API quản lý thông tin Học sinh
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BasesController<Student>
    {
        #region Field

        private IBaseBL<Student> _baseBL;
        private IStudentBL _studentBL;


        #endregion

        #region Constructor

        public StudentsController(IBaseBL<Student> baseBL, IStudentBL studentBL) : base(baseBL)
        {
            _baseBL = baseBL;
            _studentBL = studentBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// API tìm kiếm theo thông tin Học sinh keyword thông qua Họ và tên
        /// </summary>
        /// <param name="keyword">Từ khóa để tìm kiếm</param>
        /// <returns>Danh sách Học sinh tìm thấy theo từ khóa</returns>
        /// Author: KhaiND (21/12/2022)
        [HttpGet("search")]
        public override IActionResult GetSearch([FromQuery] string? keyword)
        {
            try
            {
                var records = _studentBL.GetSearch(keyword);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }

                return StatusCode(StatusCodes.Status404NotFound);
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
