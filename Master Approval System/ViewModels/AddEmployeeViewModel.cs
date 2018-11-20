using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Master_Approval_System.ViewModels
{
    public class AddEmployeeViewModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Post { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        [Display(Name = "Default Password")]
        public String Password { get; set; }

        public String Message { get; set; }
    }
}