using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DATAMODEL
{
    public class SiteManagersMetaData
    {
        [Required]
        [Display(Name = "Εκπρόσωπος")]
        public string NAME { get; set; }
    }
}
