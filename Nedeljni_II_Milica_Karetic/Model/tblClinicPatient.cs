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
    
    public partial class tblClinicPatient
    {
        public int PatientID { get; set; }
        public int HealthCareNumber { get; set; }
        public System.DateTime ExperationDate { get; set; }
        public int UniqueNumber { get; set; }
        public int UserID { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}
