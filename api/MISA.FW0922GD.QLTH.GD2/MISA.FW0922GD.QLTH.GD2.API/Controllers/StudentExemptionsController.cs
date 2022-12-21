using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;

namespace MISA.FW0922GD.QLTH.GD2.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentExemptionsController : BasesController<StudentExemption>
    {
        #region Field

        private IBaseBL<Subject> _baseBL;

        #endregion

        #region Constructor

        public SubjectsController(IBaseBL<Subject> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method
        #endregion
    }
}
