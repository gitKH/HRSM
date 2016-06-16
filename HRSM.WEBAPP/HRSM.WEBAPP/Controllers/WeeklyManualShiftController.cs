using HRSM.DATAMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRSM.WEBAPP.Controllers
{
    public class WeeklyManualShiftController : Controller
    {
        private HRSMContextContainer database;

        public WeeklyManualShiftController()
        {
            database = new HRSMContextContainer(Properties.Settings.Default.HRSMConnectionString);
        }
        //
        // GET: /WeeklyManualShift/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateForm(DateTime from)
        {

            while (true)
            {
                if (from.DayOfWeek == DayOfWeek.Sunday)
                    break;

                from = from.AddDays(-1);
            }

            List<string> week = new List<string>();
            week.Add(from.ToShortDateString());

            for (int i = 0; i < 6; i++)
            {
                from = from.AddDays(1);
                week.Add(from.ToShortDateString());
            }

            return View(week);
        }

        [HttpPost]
        public ActionResult Create(IEnumerable<Shift> shifts, Guid employeeGuid)
        {
            EMPLOYEE employe = database.EMPLOYEES.Where(x => x.RGUID == employeeGuid).Single();

            List<SHIFT> lst = new List<SHIFT>();

            foreach (var item in shifts)
            {
                if (item.From == item.To)
                    continue;

                var from = item.Date.Add(item.From);

                TimeSpan result = TimeSpan.Zero;
                if (item.From < item.To)
                {
                    result = item.From.Subtract(item.To);
                    result = new TimeSpan(Math.Abs(result.Hours), Math.Abs(result.Minutes), 0);
                }

                if (item.From > item.To)
                {
                    result = item.From.Subtract(item.To);
                    result = new TimeSpan(24, 00, 00).Subtract(result);
                }

                var to = from.Add(result);

                lst.Add(new SHIFT()
                {
                    EMPLOYEE = employe,
                    GUARDSITE = database.GUARDSITES.Where(x => x.RGUID == item.GsRGUID).Single(),
                    FROM = from,
                    TO = to
                });
            }

            database.SHIFTS.AddRange(lst);
            database.SaveChanges();

            return View();
        }


        public JsonResult AutoCompleteEmployee(string term)
        {
            var query = database.EMPLOYEES
                .Where(x => x.FIRSTNAME.Contains(term) || x.LASTNAME.Contains(term) || x.RCODE.Contains(term))
                .Select(x => new
                {
                    label = x.RCODE + " - " + x.LASTNAME + " " + x.FIRSTNAME,
                    RGUID = x.RGUID,
                    RCODE = x.RCODE,
                    FIRSTNAME = x.FIRSTNAME
                    ,
                    LASTNAME = x.LASTNAME
                });



            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutoCompleteGuardSite(string term)
        {
            var query = database.GUARDSITES
                .Where(x => x.RCODE.Contains(term) || x.SITENAME.Contains(term))
                .Select(x => new
                {
                    label = x.RCODE + " - " + x.SITENAME,
                    RGUID = x.RGUID,
                    RCODE = x.RCODE,
                    SITENAME = x.SITENAME
                });

            return Json(query, JsonRequestBehavior.AllowGet);
        }

    }

    public class Shift
    {
        public DateTime Date { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public Guid GsRGUID { get; set; }
    }
}
