using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSM.GLXERP;
using HRSM.DATAMODEL;

namespace HRSM.MIGRATION
{
    public class Migration
    {
        public HRSMContextContainer hrsmDatabase { get; private set; }
        public GalaxtErpContext glxDatabase { get; private set; }

        public Migration()
        {
            this.hrsmDatabase = new HRSMContextContainer(Properties.Settings.Default.HRSMConnectionString);
            this.glxDatabase = new GalaxtErpContext();
        }


        public void CopyAllEmployeesFromGalaxyToHRSM()
        {
           var glxEmployees = glxDatabase.GetAll();

           List<EMPLOYEE> hrsmEmployees = new List<EMPLOYEE>();

           foreach (GalaxyEMPLOYEE item in glxEmployees)
           {
               hrsmEmployees.Add(new EMPLOYEE()
                   {
                      RCODE = item.RCODE,
                      FIRSTNAME = item.FIRSTNAME,
                      LASTNAME = item.LASTNAME,
                      ADDRESS = new ADDRESS()
                      {
                        STREET = item.STREET + " " + item.STREETNUMBER,
                        POSTALCODE = item.POSTALCODE,
                      },
                      CONTACTINFO = new CONTACTINFO() 
                      {
                         PHONE1 = item.PHONE1,
                         PHONE2 = item.PHONE2,
                         EMAIL = item.EMAIL,
                      },
                      EMPLOYEEDETAIL = new EMPLOYEEDETAIL()
                      {
                        AT = item.AT,
                        AFM = item.AFM,
                        GENDER = (Gender)item.GENDER,
                        BIRTHDATE = item.BIRTHDATE,
                        MARITALSTATUS = (Marital)item.MARITALSTATUS
                      }
                   });
           }

           hrsmDatabase.EMPLOYEES.AddRange(hrsmEmployees);
           hrsmDatabase.SaveChanges();
           
        }
    }
}
