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
        [HttpGet]
        public ActionResult Index()
        {
            return View(database.EMPLOYEES.IncludeAll().ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EMPLOYEE newEmployee)
        {
            if (ModelState.IsValid)
            {
                database.EMPLOYEES.Add(newEmployee);
                database.SaveChanges();
            }
            else
            {
                return View(newEmployee);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Edit(EMPLOYEE editedEmployee)
        {
            EMPLOYEE emp = database.EMPLOYEES.IncludeAll().Single(x => x.RGUID == editedEmployee.RGUID);
            try
            {
                TryUpdateModel<EMPLOYEE>(emp);
            }
            catch (Exception)
            {

                throw;
            }

            database.SaveChanges();

            return Json(new
            {
                RGUID = emp.RGUID,
                RCODE = emp.RCODE,
                FIRSTNAME = emp.FIRSTNAME,
                LASTNAME = emp.LASTNAME,
                PHONE1 = emp.CONTACTINFO.PHONE1,
                EMAIL = emp.CONTACTINFO.EMAIL,
                SECLICEXPDATE = (emp.EMPLOYEEDETAIL.SECLICEXPDATE != null) ? emp.EMPLOYEEDETAIL.SECLICEXPDATE.Value.ToShortDateString() : "",
            }, JsonRequestBehavior.AllowGet);
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
                    RGUID = emp.ADDRESS.RGUID,
                    CITY = emp.ADDRESS.CITY,
                    STREET = emp.ADDRESS.STREET,
                    STATE = emp.ADDRESS.STATE,
                    POSTALCODE = emp.ADDRESS.POSTALCODE
                },
                CONTACTINFO = new
                {
                    RGUID = emp.CONTACTINFO.RGUID,
                    PHONE1 = emp.CONTACTINFO.PHONE1,
                    PHONE2 = emp.CONTACTINFO.PHONE2,
                    EMAIL = emp.CONTACTINFO.EMAIL
                },
                EMPLOYEEDETAIL = new
                {
                    RGUID = emp.EMPLOYEEDETAIL.RGUID,
                    AFM = emp.EMPLOYEEDETAIL.AFM,
                    AT = emp.EMPLOYEEDETAIL.AT,
                    BIRTHDATE = (emp.EMPLOYEEDETAIL.BIRTHDATE != null) ? emp.EMPLOYEEDETAIL.BIRTHDATE.Value.ToShortDateString() : "",
                    GENDER = emp.EMPLOYEEDETAIL.GENDER,
                    MARITALSTATUS = emp.EMPLOYEEDETAIL.MARITALSTATUS,
                    SECLICEXPDATE = (emp.EMPLOYEEDETAIL.SECLICEXPDATE != null) ? emp.EMPLOYEEDETAIL.SECLICEXPDATE.Value.ToShortDateString() : "",
                }

            }, JsonRequestBehavior.AllowGet);
        }


    }
}
