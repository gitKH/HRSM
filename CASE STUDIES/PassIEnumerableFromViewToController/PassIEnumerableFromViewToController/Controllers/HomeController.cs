using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassIEnumerableFromViewToController.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<string> data)
        {
            List<string> strs = new List<string>();
            foreach (var item in data)
            {
                strs.Add(item);
            }

            return RedirectToAction("Index");
        }

    }
}
