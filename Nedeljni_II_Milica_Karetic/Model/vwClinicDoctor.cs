//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nedeljni_II_Milica_Karetic.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwClinicDoctor
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationCard { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Citizenship { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public int UniqueNumber { get; set; }
        public int BankAccount { get; set; }
        public string Department { get; set; }
        public string WorkingShift { get; set; }
        public bool ReceivingPatient { get; set; }
        public int ManagerID { get; set; }
        public int DoctorID { get; set; }
    }
}
