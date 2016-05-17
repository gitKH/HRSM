using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRSM.DATAMODEL;

namespace HRSM.WEBAPP.Controllers
{
    public class EmployeeController : Controller
    {
        private HRSMContextContainer database;

        public EmployeeController()
        {
            database = new HRSMContextContainer(Properties.Settings.Default.HRSMConnectionString);
        }
        
        //
        // GET: /Employee/Index
        public ActionResult Index()
        {
            return View(database.EMPLOYEES.ToList());
        }

        [HttpPost]
        public string Delete(string GUID)
        {
            Guid  employeeGuid = new Guid(GUID);
            EMPLOYEE emp = database.EMPLOYEES.FirstOrDefault(x => x.RGUID == employeeGuid);
            database.EMPLOYEES.Remove(emp);
            database.EMPLOYEEDETAILS.Remove(emp.EMPLOYEEDETAIL);
            database.SaveChangesAsync();
            return string.Format("Ο Χρήστης {0} {1}", emp.LASTNAME, emp.FIRSTNAME);
        }
    }
}
