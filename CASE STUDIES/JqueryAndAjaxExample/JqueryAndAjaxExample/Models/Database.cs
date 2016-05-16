using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JqueryAndAjaxExample.Models
{
    public class Database
    {
        private static Database db;

        public EmployeeContext Employees { get; private set; }

        private Database()
        {
            this.Employees = new EmployeeContext();
        }

        public static Database Instance
        {
            get
            {

                if (db == null)
                    db = new Database();


                return db;
            }
        }
    }
}