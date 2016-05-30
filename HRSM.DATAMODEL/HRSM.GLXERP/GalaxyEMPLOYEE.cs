using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.GLXERP
{
    public class GalaxyEMPLOYEE
    {
        public string RCODE { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string STREET { get; set; }
        public string STREETNUMBER { get; set; }
        public string POSTALCODE { get; set; }
        public string PHONE1 { get; set; }
        public string PHONE2 { get; set; }
        public string EMAIL { get; set; }

        public string AT { get; set; }
        public string AFM { get; set; }
        public int GENDER { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public int MARITALSTATUS { get; set; }
    }
}
