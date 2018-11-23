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
        [Display(Name = "Name of Approver:")]
        public IEnumerable<int> Approver { get; set; }

        [Display(Name = "Name of Level:")]
        public IEnumerable<int> Level { get; set; }
    }
}