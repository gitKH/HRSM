using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        [DisplayFormat(DataFormatString="{dd/MM/yyyy HH:mm}")]
        public DateTime Released { get; set; }
    }
}