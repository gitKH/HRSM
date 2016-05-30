using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRSM.DATAMODEL;
using HRSM.GLXERP;

namespace HRSM.WEBAPP.Controllers
{
    public class EmployeeController : Controller
    {
        private HRSMContextContainer database;
        private GalaxtErpContext erpContext;

        public EmployeeController()
        {
            database = new HRSMContextContainer(Properties.Settings.Default.HRSMConnectionString);
            erpContext = new GalaxtErpContext();
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

        [HttpPost]
        public JsonResult GetEmployeeByID(string RCODE)
        {
            GalaxyEMPLOYEE empGalaxy = erpContext.GetEmployeeById(RCODE);

            return Json(new
            {
                RCODE = empGalaxy.RCODE,
                FIRSTNAME = empGalaxy.FIRSTNAME,
                LASTNAME = empGalaxy.LASTNAME,
                ADDRESS = new
                {
                    CITY = string.Empty,
                    STREET = empGalaxy.STREET + " " + empGalaxy.STREETNUMBER,
                    STATE = string.Empty,
                    POSTALCODE = empGalaxy.POSTALCODE
                },
                CONTACTINFO = new
                {
                    PHONE1 = empGalaxy.PHONE1,
                    PHONE2 = empGalaxy.PHONE2,
                    EMAIL = empGalaxy.EMAIL
                },
                EMPLOYEEDETAIL = new
                {
                    AFM = empGalaxy.AFM,
                    AT = empGalaxy.AT,
                    BIRTHDATE = (empGalaxy.BIRTHDATE != null) ? empGalaxy.BIRTHDATE.Value.ToShortDateString() : "",
                    GENDER = empGalaxy.GENDER,
                    MARITALSTATUS = empGalaxy.MARITALSTATUS,
                    SECLICEXPDATE = string.Empty,
                }

            }, JsonRequestBehavior.AllowGet);
        }
    }
}
