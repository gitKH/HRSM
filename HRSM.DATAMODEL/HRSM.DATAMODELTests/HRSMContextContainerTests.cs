using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSM.DATAMODEL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRSM.DATAMODEL;
using System.Data;
using System.Configuration;



namespace HRSM.DATAMODEL.Tests
{
    [TestClass()]
    public class HRSMContextContainerTests
    {
        [TestMethod()]
        public void HRSMContextContainerTest()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


            HRSMContextContainer db = new HRSMContextContainer(connectionString);

            EMPLOYEE emp = new EMPLOYEE();
            emp.FIRSTNAME = "Efstathios";
            emp.LASTNAME = "Chrysikos";
            emp.RCODE = "30-00-5000";

            emp.EMPLOYEEDETAIL = new EMPLOYEEDETAIL();
            emp.ADDRESS = new ADDRESS();
            emp.CONTACTINFO = new CONTACTINFO();

            db.EMPLOYEES.Add(emp);
            db.SaveChanges();
        }


        [TestMethod()]
        public void HRSMEmployeeDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


            HRSMContextContainer db = new HRSMContextContainer(connectionString);

            int actual = db.EMPLOYEEDETAILS.ToList().Count;
            int notExcpected = 0;

            Assert.AreNotEqual(notExcpected, actual);
        }
        [TestMethod()]
        public void DeleteEmployee()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


            HRSMContextContainer db = new HRSMContextContainer(connectionString);

            EMPLOYEE emp = db.EMPLOYEES.FirstOrDefault(x => x.RGUID == new Guid("50F8AF77-1B1C-E611-93D3-485B39702B1D"));
            db.EMPLOYEEDETAILS.Remove(emp.EMPLOYEEDETAIL);
            db.CONTACTINFOS.Remove(emp.CONTACTINFO);
            db.ADDRESSES.Remove(emp.ADDRESS);

            db.EMPLOYEES.Remove(emp);
            db.SaveChanges();

        }

    }
}
