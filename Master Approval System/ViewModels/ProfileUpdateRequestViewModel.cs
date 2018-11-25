using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Approval_System.ViewModels
{
    public class ProfileUpdateRequestViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int JoiningAge { get; set; }
        public string Gender { get; set; }
        public int RetirementAge { get; set; }
        public string IndustryType { get; set; }
        public string BloodGroup { get; set; }
        public string Client { get; set; }
        public string ClientSub { get; set; }
        public string AgreementType { get; set; }
        public string JobLocation { get; set; }
        public string Division { get; set; }
        public Boolean MaritalStatus { get; set; }
        public string ContractType { get; set; }
        public string PTState { get; set; }
        public string AssociationType { get; set; }
    }
}