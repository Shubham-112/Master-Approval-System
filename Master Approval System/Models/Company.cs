using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Approval_System.Models
{
    public class Company
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}