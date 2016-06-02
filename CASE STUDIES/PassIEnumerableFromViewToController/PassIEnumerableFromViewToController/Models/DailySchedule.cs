using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassIEnumerableFromViewToController.Models
{
    public class DailySchedule
    {
        public string EMID { get; set; }
        public string GSID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}