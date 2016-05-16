using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class WeeklySchedule
    {
        public int EmployeeID { get; set; }
        public DailySchedule Sunday { get; set; }
        public DailySchedule Monday { get; set; }
        public DailySchedule Tuesday { get; set; }
        public DailySchedule Wednesday { get; set; }
        public DailySchedule Thursday { get; set; }
        public DailySchedule Friday { get; set; }
        public DailySchedule Saturday { get; set; }

    }

    public static class WeeklyScheduleExtension
    {
        public static List<DailySchedule> ParseToList(this WeeklySchedule model)
        {

            Repository db = Repository.GetInstance();
            var employee = db.Employees.Where(x => x.EmployeeID == model.EmployeeID).Single();
           

            model.Sunday.Employee = employee;
            model.Monday.Employee = employee;
            model.Tuesday.Employee = employee;
            model.Wednesday.Employee = employee;
            model.Thursday.Employee = employee;
            model.Friday.Employee = employee;
            model.Saturday.Employee = employee;

            return new List<DailySchedule>() {
                model.Sunday,
                model.Monday,
                model.Tuesday,
                model.Wednesday,
                model.Thursday,
                model.Friday,
                model.Saturday
            };
        }
    }
}