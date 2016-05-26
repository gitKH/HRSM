using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
                

namespace HRSM.DATAMODEL
{
    public class EmployeeMetaData
    {
        public System.Guid RGUID { get; set; }

        [Required]
        [Display(Name = "Κωδικός")]
        [StringLength(5,MinimumLength=5,ErrorMessage="Ο Κωδικός πρέπει να είναι πενταψήφιος")]
        public string RCODE { get; set; }
        [Required]
        [Display(Name = "Επώνυμο")]
        public string LASTNAME { get; set; }
        [Required]
        [Display(Name = "Όνομα")]
        public string FIRSTNAME { get; set; }
    }
}
