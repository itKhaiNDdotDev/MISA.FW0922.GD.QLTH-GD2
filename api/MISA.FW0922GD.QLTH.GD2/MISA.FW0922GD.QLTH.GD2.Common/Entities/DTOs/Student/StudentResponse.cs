using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FW0922GD.QLTH.GD2.Common.Entities.DTOs.Student
{
    /// <summary>
    /// DTO định nghĩa các trường thông tin của Học sinh muốn lấy về khi gọi API
    /// </summary>
    /// Author: KhaiND (22/12/2022)
    public class StudentResponse
    {
        public Guid StudentID { get; set; }

        public string StudentName { get; set; }

        public DateTime StudentDateOfBirth { get; set; }

        public string BranchName { get; set; }
    }
}
