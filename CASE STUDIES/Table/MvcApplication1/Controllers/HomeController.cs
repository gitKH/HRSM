using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        private Repository database;

        public HomeController()
        {
            database = Repository.GetInstance();
        }
        //
        // GET: /Home/

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            return View();
        }
         [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(WeeklySchedule weekly)
        {
            if (!ModelState.IsValid)
                return View();

            database.Schedule.AddRange(weekly.ParseToList());
            return RedirectToAction("Daily");

        }


        public ActionResult Daily()
        {
            var items = database.Schedule; 
            
            return View(items);
        }


        public JsonResult GetEmployees()
        {
            return Json(database.Employees, JsonRequestBehavior.AllowGet);
        }

    }
}
