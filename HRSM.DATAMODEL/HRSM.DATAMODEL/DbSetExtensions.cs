using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HRSM.DATAMODEL
{
    public static class DbSetExtensions
    {
        public static IQueryable<EMPLOYEE> IncludeAll(this DbSet<EMPLOYEE> dbset)
        {
            return dbset.Include(x => x.EMPLOYEEDETAIL).Include(x => x.CONTACTINFO).Include(x => x.ADDRESS);
        }
    }
}
