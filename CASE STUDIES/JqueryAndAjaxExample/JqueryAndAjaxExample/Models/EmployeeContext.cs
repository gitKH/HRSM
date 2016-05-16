using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JqueryAndAjaxExample.Models
{
    public class EmployeeContext
    {
        private List<Employee> employees;
        public EmployeeContext()
        {
            this.employees = new List<Employee>()
            {
              new   Employee() { ID = 1, Name = "Chrysikos1" },
              new   Employee() { ID = 2, Name = "Chrysikos2" },
              new   Employee() { ID = 3, Name = "Chrysikos3" },
              new   Employee() { ID = 4, Name = "Chrysikos4" },
            };
        }


        public void Add(Employee emp)
        {
            this.employees.Add(emp);
        }

        public void Remove(Employee emp)
        {
            this.employees.Remove(emp);
        }

        public List<Employee> GetAll
        {
            get
            {
                return this.employees;
            }
        }
    }
}