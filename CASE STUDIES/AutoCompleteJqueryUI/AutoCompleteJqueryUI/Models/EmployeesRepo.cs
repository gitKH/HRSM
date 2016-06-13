using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteJqueryUI.Models
{
    public class EmployeesRepo
    {
        public List<Employee> Query()
        {
            return new List<Employee>()
            {
                new Employee() { RCODE = "1" , Name = "Chrysikos" },
                new Employee() { RCODE = "2" , Name = "Spanoudakis" },
                new Employee() { RCODE = "3" , Name = "Haidari" },
                new Employee() { RCODE = "4" , Name = "Priftis" },
                new Employee() { RCODE = "5" , Name = "Dimtrio" },
                new Employee() { RCODE = "6" , Name = "Piou" },
                new Employee() { RCODE = "7" , Name = "Naaaaa" },
            };
        }
    }

    public class Employee
    {
        public string RCODE { get; set; }
        public string Name { get; set; }
    }
}