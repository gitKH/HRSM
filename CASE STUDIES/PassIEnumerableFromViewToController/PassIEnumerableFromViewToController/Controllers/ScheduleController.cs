using PassIEnumerableFromViewToController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassIEnumerableFromViewToController.Controllers
{
    public class ScheduleController : Controller
    {
        //
        // GET: /Schedule/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<DailySchedule> data)
        {
            return RedirectToAction("Index"); 
        }

    }
}
