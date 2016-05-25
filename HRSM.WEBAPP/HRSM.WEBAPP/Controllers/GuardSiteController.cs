using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRSM.DATAMODEL;

namespace HRSM.WEBAPP.Controllers
{
    public class GuardSiteController : Controller
    {

        private HRSMContextContainer database;
        //
        // GET: /GuardSite/
        public GuardSiteController()
        {
            database = new HRSMContextContainer(Properties.Settings.Default.HRSMConnectionString);
        }

        public ActionResult Index()
        {
            return View(database.GUARDSITES.IncludeAll().ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GUARDSITE newGUARDSITE)
        {
            if (ModelState.IsValid)
            {
                database.GUARDSITES.Add(newGUARDSITE);
                database.SaveChanges();
            }
            else
            {
                return View(newGUARDSITE);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Delete(string RID)
        {
            Guid guardSiteGuid = new Guid(RID);
            GUARDSITE delGuardSite = database.GUARDSITES.IncludeAll().Single(id => id.RID == guardSiteGuid);

            database.GUARDSITES.Remove(delGuardSite);

            database.SaveChanges();
            return string.Format("Η Φύλαξη της επιχείρισης {0} έχει διαγραφή!", delGuardSite.SITENAME);
        }

        [HttpPost]
        public JsonResult Edit(GUARDSITE editedGuardSite)
        {
            GUARDSITE guardSite = database.GUARDSITES.IncludeAll().Single(x => x.RID == editedGuardSite.RID);

            try
            {
                TryUpdateModel<GUARDSITE>(guardSite);
            }
            catch (Exception)
            {

                throw;
            }

            database.SaveChanges();

            return Json(new
            {
                RID = guardSite.RID,
                RCODE = guardSite.RCODE,
                SITENAME = guardSite.SITENAME,
                ISACTIVE = guardSite.ISACTIVE,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Details(string RID)
        {
            Guid guardSiteGuid = new Guid(RID);
            GUARDSITE detGuardSite = database.GUARDSITES.IncludeAll().Single(x => x.RID == guardSiteGuid);


            return Json(new
            {
                RID = detGuardSite.RID,
                RCODE = detGuardSite.RCODE,
                SITENAME = detGuardSite.SITENAME,
                ISACTIVE = detGuardSite.ISACTIVE,
                SITEMANAGER = new
                {
                    RID = detGuardSite.SITEMANAGER.RID,
                    NAME = detGuardSite.SITEMANAGER.NAME,
     
                    CONTACTINFO = new 
                    { 
                        RGUID = detGuardSite.SITEMANAGER.CONTACTINFO.RGUID,
                        PHONE1 = detGuardSite.SITEMANAGER.CONTACTINFO.PHONE1,
                        PHONE2 = detGuardSite.SITEMANAGER.CONTACTINFO.PHONE2,
                        EMAIL = detGuardSite.SITEMANAGER.CONTACTINFO.EMAIL
                    }
                },
                ADDRESS = new
                {
                    RGUID = detGuardSite.ADDRESS.RGUID,
                    CITY = detGuardSite.ADDRESS.CITY,
                    STREET = detGuardSite.ADDRESS.STREET,
                    STATE = detGuardSite.ADDRESS.STATE,
                    POSTALCODE = detGuardSite.ADDRESS.POSTALCODE
                }
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
