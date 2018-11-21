using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Master_Approval_System.Models;

namespace Master_Approval_System.ViewModels
{
    public class ApprovalProcessViewModel
    {
        public IEnumerable<Level> Levels{ get; set; }
    }
}