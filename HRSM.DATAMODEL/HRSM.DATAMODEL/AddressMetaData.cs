using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DATAMODEL
{
    public class AddressMetaData
    {
        [Display(Name = "Πόλη")]
        public string CITY { get; set; }
        [Display(Name = "Οδός")]
        public string STREET { get; set; }
        [Display(Name = "Νομός")]
        public string STATE { get; set; }
        [Display(Name = "Τ.Κ.")]
        public string POSTALCODE { get; set; }
    }
}
