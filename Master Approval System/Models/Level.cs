using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Approval_System.Models
{
    public class Level
    {
        public int Id { get; set; }
        public String Approvers { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}