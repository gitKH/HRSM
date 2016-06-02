using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteJqueryUI.Models
{
    public class EmployeesRepo
    {
        public List<string> Query()
        {
            return new List<string>()
            {
                "stathis",
                "giannis",
                "kostas",
                "dimitris",
                "chris",
                "vassiliki",
                "thanasis",
                "eleni",
                "gamata"
            };
        }
    }
}