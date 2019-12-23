using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zorgcirckel.Models
{
    public class ToestemmingenViewModel
    {
        public AspNetUsers Contactpersoon { get; set; }
        public Dictionary<string, bool> Toestemmingen { get; set; }

        public ToestemmingenViewModel()
        {
            Toestemmingen = new Dictionary<string, bool>();
        }

        public bool this[string key]
        {
            get
            {
                return Toestemmingen[key];
            }
            set
            {
                Toestemmingen.Add(key, value);
            }
        }
    }
}