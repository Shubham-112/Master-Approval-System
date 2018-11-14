using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Master_Approval_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmpId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public Company Company { get; set; }
        public int? CompanyId { get; set; }
    }
}