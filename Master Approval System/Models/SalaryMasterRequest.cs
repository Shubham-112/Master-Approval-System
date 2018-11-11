using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Approval_System.Models
{
    public class SalaryMasterRequest : Request
    {
        public float ActualBasic { get; set; }
        public float HRA { get; set; }
        public float TransportAllowance { get; set; }
        public float SpecialAllowance { get; set; }
        public float MedicalAllowance { get; set; }
        public int CCA { get; set; }
        public float OtherAllowance { get; set; }
        public float BonusFixed { get; set; }
        public float Incentive { get; set; }
        public float OtherEarnings { get; set; }
        public int EmpPF { get; set; }
        public int EmprPF { get; set; }
        public int EmpESI { get; set; }
        public int EmprESI { get; set; }
        public float PT { get; set; }
        public float ITDeduction { get; set; }
        public float LWF { get; set; }
        public float OtherDeduction { get; set; }
        public float GrossDeduction { get; set; }
        public float OtherAdvance { get; set; }
        public float FesAdb { get; set; }
        public float Total { get; set; }
        public float NetEarning { get; set; }
        public float Gratuity { get; set; }
    }
}