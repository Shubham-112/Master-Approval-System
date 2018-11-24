using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Master_Approval_System.Models;

namespace Master_Approval_System.ViewModels
{
    public class ApprovalProcessViewModel
    {
        public List<ApplicationUser> ApproverList { get; set; }

        [Required]
        [Display(Name = "Name of Approver:")]
        public List<String> Approver { get; set; }

        [Required]
        [Display(Name = "Name of Level:")]
        public List<int> Level { get; set; }
    }
}