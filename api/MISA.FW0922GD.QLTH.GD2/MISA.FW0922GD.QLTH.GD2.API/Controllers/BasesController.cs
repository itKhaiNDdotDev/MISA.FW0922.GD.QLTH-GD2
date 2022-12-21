using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs;
using MISA.FW0922GD.QLTH.GD2.Common.Enums;
using System.Resources;

namespace MISA.FW0922GD.QLTH.GD2.API.Controllers
{
    /// <summary>
    /// Base cho các API thêm, sửa, xóa, lấy danh sách, lấy thông tin bản ghi và tìm kiếm cơ bản
    /// </summary>
    /// <typeparam name="T">Class của đối tượng Entity thực thi tương ứng</typeparam>
    /// Author: KhaiND (21/12/2022)
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// API lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// Author: KhaiND (21/12/2022)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var records = _baseBL.GetAll();

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }

                return StatusCode(StatusCodes.Status200OK, new List<T>());
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
        /// API lấy thông tin bản ghi thông qua ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <returns>Thông tin chi tiết của bản ghi</returns>
        /// Author: KhaiND (21/12/2022)
        [HttpGet("{recordID}")]
        public IActionResult GetByID([FromRoute] int recordID)
        {
            try
            {
                var record = _baseBL.GetByID(recordID);

                if (record != null)
                {
                    return StatusCode(StatusCodes.Status200OK, record);
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

        /// <summary>
        /// API tìm kiếm theo keyword
        /// </summary>
        /// <param name="keyword">Từ khóa để tìm kiếm</param>
        /// <returns>Danh sách các bản ghi tìm thấy theo từ khóa</returns>
        /// Author: KhaiND (21/12/2022)
        [HttpGet("search")]
        public IActionResult GetSearch([FromQuery] string? keyword)
        {
            try
            {
                var records = _baseBL.GetSearch(keyword);

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

        /// <summary>
        /// API thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu của bản ghi muốn thêm</param>
        /// <returns>ID của bản ghi vừa được thêm</returns>
        /// Created By: KhaiND (19/11/2022)
        [HttpPost]
        public IActionResult Insert([FromBody] T record)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _baseBL.Insert(record));
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
        /// API cập nhật thông tin một bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn chỉnh sửa</param>
        /// <param name="record">Dữ liệu muốn đưa vào cập nhật cho bản ghi</param>
        /// <returns>ID của bản ghi vừa cập nhật</returns>
        /// Created By: KhaiND (19/11/2022)
        [HttpPut("{recordID}")]
        public IActionResult Update([FromRoute] int recordID, [FromBody] T record)
        {
            try
            {
                // Xét 404 khi recordID không tìm thấy
                var foundRecord = _baseBL.GetByID(recordID);
                if (foundRecord == null)
                {
                    StatusCode(StatusCodes.Status404NotFound);
                }

                // TÌm thấy thì gọi BL tiến hành thủ tục cập nhật
                return StatusCode(StatusCodes.Status200OK, _baseBL.Update(recordID, record));
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
        /// API xóa một bản ghi thông qua ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Created By: KhaiND (19/11/2022)
        [HttpDelete("{recordID}")]
        public IActionResult Delete([FromRoute] int recordID)
        {
            try
            {
                // Xét trường hợp không tìm thấy
                var record = _baseBL.GetByID(recordID);
                if (record == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return StatusCode(StatusCodes.Status200OK, _baseBL.Delete(recordID));

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
