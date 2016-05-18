using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSM.DATAMODEL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data.Entity;


namespace HRSM.DATAMODEL.Tests
{
    [TestClass()]
    public class EMPLOYEESTests
    {
        private HRSMContextContainer database;
        public EMPLOYEESTests()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            database = new HRSMContextContainer(connectionString);
        }

        [TestMethod()]
        public void EmployeesSeed()
        {
            List<EMPLOYEE> employees = new List<EMPLOYEE>()
            {
                 new EMPLOYEE()
                {
                    FIRSTNAME = "ΧΡΥΣΙΚΟΣ",
                    LASTNAME = "ΕΥΣΤΑΘΙΟΣ",
                    RCODE = "30-00-1000",
                    ADDRESS = new ADDRESS()
                    {
                        CITY = "ΝΕΟ ΗΡΑΚΛΕΙΟ",
                        STREET = "ΠΟΛΥΤΕΧΝΕΙΟΥ 11",
                        STATE = "ΑΤΤΙΚΗ",
                        POSTALCODE = "14122"
                    },
                    EMPLOYEEDETAIL = new EMPLOYEEDETAIL()
                    {
                        AT = "Χ779470",
                        AFM = "1857392879",
                        BIRTHDATE = new DateTime(1986, 10, 22),
                        GENDER = Gender.Male,
                        MARITALSTATUS = true,
                        SECLICEXPDATE = new DateTime(2022, 12, 31)
                    },
                    CONTACTINFO = new CONTACTINFO()
                    {
                        PHONE1 = "2102910336",
                        PHONE2 = "6985555209",
                        EMAIL = "stathis@chrysikos.gr"
                    }
                },
                 new EMPLOYEE()
                {
                    FIRSTNAME = "ΔΑΣΚΑΛΟΠΟΥΛΟΣ",
                    LASTNAME = "ΔΗΜΗΤΡΙΟΣ",
                    RCODE = "30-00-2015",
                    ADDRESS = new ADDRESS()
                    {
                        CITY = "ΚΑΛΥΒΙΑ",
                        STREET = "ΚΑΛΥΒΙΑ ΑΓΡΙΝΙΟΥ",
                        STATE = "ΑΙΤ",
                        POSTALCODE = "30100"
                    },
                    EMPLOYEEDETAIL = new EMPLOYEEDETAIL()
                    {
                        AT = "Χ88Ε4ΑΣ",
                        AFM = "123456789",
                        BIRTHDATE = new DateTime(1981, 01, 06),
                        GENDER = Gender.Male,
                        MARITALSTATUS = false,
                        SECLICEXPDATE = new DateTime(2018, 12, 31)
                    },
                    CONTACTINFO = new CONTACTINFO()
                    {
                        PHONE1 = "2641095073",
                        PHONE2 = "2641095251",
                        EMAIL = "dasklopoulos@gmail.gr"
                    }
                },
            };


            database.EMPLOYEES.AddRange(employees);
            database.SaveChanges();
        }

        [TestMethod()]
        public void EmployeeRemoveTest()
        {
            EMPLOYEE employee = database.EMPLOYEES.IncludeAll().First();
            database.EMPLOYEES.Remove(employee);
            database.SaveChanges();
        }
    }
}
