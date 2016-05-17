using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DATAMODEL
{
    public partial class HRSMContextContainer
    {
        public HRSMContextContainer(string connectionString)
            : base(connectionString)
        {

        }
    }
}
