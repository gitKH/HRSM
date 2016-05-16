using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JqueryAndAjaxExample.Models;

namespace JqueryAndAjaxExample.Controllers
{
    public class HomeController : Controller
    {
        private Database db;

        public HomeController()
        {
            db = Database.Instance;
        }
        //
        // GET: /Home/

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Employees.GetAll);
        }


        [HttpPost]
        public string Remove(int id)
        {
            Employee emp = db.Employees.GetAll.Single(x => x.ID == id);
            db.Employees.Remove(emp);
            return "Removed";
        }

    }
}
