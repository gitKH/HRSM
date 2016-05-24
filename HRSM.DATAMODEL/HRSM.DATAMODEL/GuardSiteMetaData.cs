using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DATAMODEL
{
    public class GuardSitesMetaData
    {
        [Required]
        [Display(Name = "Κωδικός Φύλαξης")]
        public string RCODE { get; set; }

        [Required]
        [Display(Name = "Επιχείριση")]
        public string SITENAME { get; set; }

        [Required]
        [Display(Name = "Κατάσταση")]
        public STATUS ISACTIVE { get; set; }
    }
}
