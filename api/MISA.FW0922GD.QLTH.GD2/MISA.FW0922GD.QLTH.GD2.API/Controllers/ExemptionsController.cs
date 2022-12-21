using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;

namespace MISA.FW0922GD.QLTH.GD2.API.Controllers
{
    /// <summary>
    /// Các API của hoạt động quản lý thông tin Diện miễn giảm
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    //[Route("api/[controller]")]
    [ApiController]
    public class ExemptionsController : BasesController<Exemption>
    {
        #region Field

        private IBaseBL<Exemption> _baseBL;

        #endregion

        #region Constructor

        public ExemptionsController(IBaseBL<Exemption> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method



        #endregion
    }
}
