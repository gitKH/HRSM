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

            var result = data.Query().Where(x => x.RCODE.Contains(term) || x.Name.Contains(term)).ToList();

            //object[] s = { new { label = result[0], value = "1" }, new { label = result[2], value = "2" } };

            List<AutoCompleteData> d = new List<AutoCompleteData>();

            foreach (var item in result)
            {
                d.Add(new AutoCompleteData() { label = item.RCODE + " - " + item.Name, value = item.RCODE , test= "testvalut"});
            }

            return Json(d.ToArray(), JsonRequestBehavior.AllowGet);
        }


        public string Create(string empid)
        {
            return empid.ToString();
        }

    }

    public class AutoCompleteData
    {
        public string label { get; set; }
        public string value { get; set; }
        public string test { get; set; }
    }
}
