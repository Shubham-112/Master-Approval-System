using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Approval_System.Models
{
    public class ApprovalProcess
    {
        public int Id { get; set; }
        public IEnumerable<int> Level { get; set; }
        public String UserId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}