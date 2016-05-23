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
            List<EMPLOYEE> employees = new List<EMPLOYEE>();
            for (int i = 0; i < 4; i++)
            {

                employees.Add(new EMPLOYEE()
                {
                    FIRSTNAME = "ΕΥΣΤΑΘΙΟΣ",
                    LASTNAME = "ΧΡΥΣΙΚΟΣ",
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
                        MARITALSTATUS = Marital.Yes,
                        SECLICEXPDATE = new DateTime(2022, 12, 31)
                    },
                    CONTACTINFO = new CONTACTINFO()
                    {
                        PHONE1 = "2102910336",
                        PHONE2 = "6985555209",
                        EMAIL = "stathis@chrysikos.gr"
                    }
                });

                employees.Add(new EMPLOYEE()
               {
                   FIRSTNAME = "ΔΗΜΗΤΡΙΟΣ",
                   LASTNAME = "ΔΑΣΚΑΛΟΠΟΥΛΟΣ",
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
                       MARITALSTATUS = Marital.No,
                       SECLICEXPDATE = new DateTime(2018, 12, 31)
                   },
                   CONTACTINFO = new CONTACTINFO()
                   {
                       PHONE1 = "2641095073",
                       PHONE2 = "2641095251",
                       EMAIL = "dasklopoulos@gmail.gr"
                   }
               });
                employees.Add(new EMPLOYEE()
                {
                    FIRSTNAME = "ΓΙΑΝΝΗΣ",
                    LASTNAME = "ΧΑΙΝΤΑΡΗΣ",
                    RCODE = "30-00-1100",
                    ADDRESS = new ADDRESS()
                    {
                        CITY = "ΖΩΓΡΑΦΟΥ",
                        STREET = "ΑΜΦΙΤΡΙΤΗΣ 8",
                        STATE = "ΑΤΤΙΚΗ",
                        POSTALCODE = "15172"
                    },
                    EMPLOYEEDETAIL = new EMPLOYEEDETAIL()
                    {
                        AT = "ΑΜ 958755",
                        AFM = "1857354479",
                        BIRTHDATE = new DateTime(1993, 03, 03),
                        GENDER = Gender.Male,
                        MARITALSTATUS = Marital.No,
                        SECLICEXPDATE = new DateTime(2012, 12, 31)
                    },
                    CONTACTINFO = new CONTACTINFO()
                    {
                        PHONE1 = "2107777754",
                        PHONE2 = "6922555209",
                        EMAIL = "giannis@javas.gr"
                    }
                });
                employees.Add(new EMPLOYEE()
                {
                    FIRSTNAME = "ΚΩΣΤΑΣ",
                    LASTNAME = "ΠΡΊΦΤΗΣ",
                    RCODE = "30-00-1002",
                    ADDRESS = new ADDRESS()
                    {
                        CITY = "ΝΕΟΣ ΚΟΣΜΟΣ",
                        STREET = "ΠΥΡΡΑΣ 38",
                        STATE = "ΑΤΤΙΚΗ",
                        POSTALCODE = "11745"
                    },
                    EMPLOYEEDETAIL = new EMPLOYEEDETAIL()
                    {
                        AT = "ΒΕ567465",
                        AFM = "151651651",
                        BIRTHDATE = new DateTime(1992, 02, 09),
                        GENDER = Gender.Male,
                        MARITALSTATUS = Marital.Yes,
                        SECLICEXPDATE = new DateTime(2022, 08, 25)
                    },
                    CONTACTINFO = new CONTACTINFO()
                    {
                        PHONE1 = "2109229116",
                        PHONE2 = "6977043389",
                        EMAIL = "priftiskonstantinos@ymail.com"
                    }
                });




            }
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
