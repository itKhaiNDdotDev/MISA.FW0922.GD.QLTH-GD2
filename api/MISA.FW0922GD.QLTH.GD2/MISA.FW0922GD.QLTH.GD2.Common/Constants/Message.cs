﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Constants
{
    /// <summary>
    /// Các thông điệp sử dụng trong mã nguồn yêu cầu constant
    /// </summary>
    /// Author: KhaiND (21/12/2022)
    public class Message
    {
        /// <summary>
        /// Thông điệp trường dữ liệu là bắt buộc, không được phép để trống
        /// </summary>
        public const string REQUIRED_DATA = "Dữ liệu không được phép để trống.";

        /// <summary>
        /// Thông điệp khi bỏ qua trường thông tin bắt buộc StudentCOde (Mã học sinh)
        /// </summary>
        public const string STUDENT_REQUIRED_CODE = "Mã học sinh không được phép bỏ trống.";

        /// <summary>
        /// Thông điệp khi kiểm tra có trùng mã học sinh (mã đã tồn tại) sử dụng trong action thêm mới hoặc chỉnh sửa thông tin Học sinh
        /// </summary>
        public const string STUDENT_DUPLICATED_CODE = "Mã học sinh đã tồn tại! Vui lòng kiểm tra lại.";

        /// <summary>
        /// Thông điệp khi bỏ qua trường thông tin bắt buộc StudentName (Họ và tên Học sinh)
        /// </summary>
        public const string STUDENT_REQUIRED_NAME = "Họ và tên không được phép bỏ trống.";
    }
}