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
    
    public partial class Contacten
    {
        public string PatientID { get; set; }
        public string ContactpersoonID { get; set; }
        public string Relatie { get; set; }
        public string Contactpersoon { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
    }
}