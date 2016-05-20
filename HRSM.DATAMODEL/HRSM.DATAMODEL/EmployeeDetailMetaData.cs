using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DATAMODEL
{
    public class EmployeeDetailMetaData
    {
        [Display(Name = "ΑΤ")]
        public string AT { get; set; }
        [Display(Name = "ΑΦΜ")]
        public string AFM { get; set; }
        [Display(Name = "Φύλο")]
        public Nullable<Gender> GENDER { get; set; }
        [Display(Name = "Ημερομηνία Γέννησης")]
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        [Display(Name = "Έγγαμος")]
        public Nullable<Marital> MARITALSTATUS { get; set; }
        [Display(Name = "Ημερομηνία Λήξης Αδείας")]
        public Nullable<System.DateTime> SECLICEXPDATE { get; set; }
    }
}
