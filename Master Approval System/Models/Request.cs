using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Approval_System.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int State { get; set; }

        public static readonly byte completed = 1;
        public static readonly byte rejected = 0;
        public static readonly byte pending = 2;
    }
}