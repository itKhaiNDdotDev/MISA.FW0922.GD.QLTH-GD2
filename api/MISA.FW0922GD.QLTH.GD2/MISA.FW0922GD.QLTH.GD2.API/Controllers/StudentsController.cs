using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;

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

        #endregion

        #region Constructor

        public StudentsController(IBaseBL<Student> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method
        #endregion
    }
}
