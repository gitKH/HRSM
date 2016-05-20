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
        [StringLength(10,MinimumLength=10,ErrorMessage="O Kodikos prepei na einai ths morfhs 00-00-0000")]
        public string RCODE { get; set; }
        [Required]
        public string LASTNAME { get; set; }
        [Required]
        public string FIRSTNAME { get; set; }
    }
}
