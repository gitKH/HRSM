using AutoCompleteJqueryUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCompleteJqueryUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Emp(string term)
        {
            EmployeesRepo data = new EmployeesRepo();

            var result = data.Query().Where(x => x.Contains(term)).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
