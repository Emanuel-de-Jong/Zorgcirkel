using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zorgcirckel.Models
{
    public class LijstViewModel
    {
        [Key]
        public int Id { get; set; }
        public int LijstID { get; set; }
        public int VraagID { get; set; }
        public string Onderwerp { get; set; }
        public string Vraag { get; set; }
        public string VraagType { get; set; }
        [Display(Name = "Antwoord")]
        public string Antwoord1 { get; set; }
        public DateTime Datum { get; set; }
        public string AspNetUsersID { get; set; }
    }
}