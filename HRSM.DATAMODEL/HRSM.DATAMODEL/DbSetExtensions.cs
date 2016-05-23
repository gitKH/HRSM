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

        public static IQueryable<GUARDSITE> IncludeAll(this DbSet<GUARDSITE> dbset)
        {
            return dbset.Include(x => x.ADDRESS).Include(x => x.SITEMANAGER).Include(x => x.SITEMANAGER.CONTACTINFO);
        }

        public static void UpdateEmployee(this HRSMContextContainer context, EMPLOYEE employee)
        {
            EMPLOYEE originalEmployee = context.EMPLOYEES.IncludeAll().Single(x => x.RGUID == employee.RGUID);
            employee.Copy(originalEmployee);  
        }

    }
}
