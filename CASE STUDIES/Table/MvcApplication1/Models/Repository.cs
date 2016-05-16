using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Repository
    {
        private static Repository database;
        public List<Employee> Employees { get; private set; }
        public List<Customer> Customers { get; private set; }

        public List<DailySchedule> Schedule { get; private set; }

        private Repository()
        {
            this.Employees = new List<Employee>()
            {
                new Employee() { EmployeeID = 1015 , Name = "Stathis Chrysikos" },
                new Employee() { EmployeeID = 1005 , Name = "Chris Spanoudakis" },
                new Employee() { EmployeeID = 1060 , Name = "Pavlos Mosidis" },
                new Employee() { EmployeeID = 1003 , Name = "Dimitris Daskalopoulos" },
                new Employee() { EmployeeID = 1002 , Name = "Evita Diakaki" },
            };

            this.Customers = new List<Customer>()
            {
               new  Customer() { CustomerID = 1 , CompanyName = "BMW"},
               new  Customer() { CustomerID = 2 , CompanyName = "THALES"},
               new  Customer() { CustomerID = 3 , CompanyName = "EUROBANK"},
               new  Customer() { CustomerID = 4 , CompanyName = "ALPHA BANK"},
            };

            this.Schedule = new List<DailySchedule>();
        }

        public static Repository GetInstance()
        {
            if (database == null)
                database = new Repository();



            return database;
        }
    }
}