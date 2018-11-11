using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Approval_System.Models
{
    public class Employee : User
    {
        public string Post { get; set; }
        public string salary { get; set; }

        public SalaryProcessRequest SalaryProcessRequest { get; set; }
        public int? SalaryProcessRequestId { get; set; }

        public SalaryMasterRequest SalaryMasterRequest { get; set; }
        public int? SalaryMasterRequestId { get; set; }

        public ProfileUpdateRequest ProfileUpdateRequest { get; set; }
        public int? ProfileUpdateRequestId { get; set; }
    }
}