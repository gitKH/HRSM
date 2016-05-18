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
            return View(database.EMPLOYEES.IncludeAll().ToList());
        }


        [HttpPost]
        public string Delete(string GUID)
        {
            Guid employeeGuid = new Guid(GUID);
            EMPLOYEE emp = database.EMPLOYEES.IncludeAll().Single(x => x.RGUID == employeeGuid);
            database.EMPLOYEES.Remove(emp);
            database.SaveChanges();
            return string.Format("Ο Χρήστης {0} {1} έχει διαγραφεί απο την βάση.", emp.LASTNAME, emp.FIRSTNAME);
        }
        [HttpPost]
        public JsonResult Details(string GUID)
        {
            Guid employeeGuid = new Guid(GUID);
            EMPLOYEE emp = database.EMPLOYEES.IncludeAll().Single(x => x.RGUID == employeeGuid);


            return Json(new
            {
                RGUID = emp.RGUID,
                RCODE = emp.RCODE,
                FIRSTNAME = emp.FIRSTNAME,
                LASTNAME = emp.LASTNAME,
                ADDRESS = new
                {
                    CITY = emp.ADDRESS.CITY,
                    STREET = emp.ADDRESS.STREET,
                    STATE = emp.ADDRESS.STATE,
                    POSTALCODE = emp.ADDRESS.POSTALCODE
                },
                CONTACTINFO = new
                {
                    PHONE1 = emp.CONTACTINFO.PHONE1,
                    PHONE2 = emp.CONTACTINFO.PHONE2,
                    EMAIL = emp.CONTACTINFO.EMAIL
                },
                EMPLOYEEDETAIL = new
                {
                    AFM = emp.EMPLOYEEDETAIL.AFM,
                    AT = emp.EMPLOYEEDETAIL.AT,
                    BIRTHDATE = emp.EMPLOYEEDETAIL.BIRTHDATE,
                    GENDER = emp.EMPLOYEEDETAIL.GENDER,
                    MARITALSTATUS = emp.EMPLOYEEDETAIL.MARITALSTATUS,
                    SECLICEXPDATE = emp.EMPLOYEEDETAIL.SECLICEXPDATE.Value.ToLongDateString(),
                }

            }, JsonRequestBehavior.AllowGet);
        }

        
    }
}
