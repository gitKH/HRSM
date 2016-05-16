using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class DailySchedule
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}