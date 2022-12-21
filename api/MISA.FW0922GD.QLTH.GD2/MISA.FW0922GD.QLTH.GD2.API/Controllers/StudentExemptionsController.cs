using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;

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

        #endregion

        #region Constructor

        public StudentExemptionsController(IBaseBL<StudentExemption> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method
        #endregion
    }
}
