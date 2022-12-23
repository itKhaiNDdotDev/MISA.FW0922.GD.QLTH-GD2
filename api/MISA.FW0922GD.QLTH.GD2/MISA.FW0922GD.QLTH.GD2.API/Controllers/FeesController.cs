﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FW0922GD.QLTH.GD2.BL.BaseBL;
using MISA.FW0922GD.QLTH.GD2.Common.Entities;

namespace MISA.FW0922GD.QLTH.GD2.API.Controllers
{
    /// <summary>
    /// Các API quản lý thông tin Khoản thu
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    //[Route("api/[controller]")]
    [ApiController]
    public class FeesController : BasesController<Fee>
    {
        #region Field

        private IBaseBL<Fee> _baseBL;

        #endregion

        #region Constructor

        public FeesController(IBaseBL<Fee> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method



        #endregion
    }
}
