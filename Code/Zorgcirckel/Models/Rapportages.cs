//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zorgcirckel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rapportages
    {
        public int RapportageID { get; set; }
        public string AspNetUsersID { get; set; }
        public string Rapportage { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public string PatientID { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
    }
}