using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DATAMODEL
{
    public partial class EMPLOYEE
    {
        public EMPLOYEE()
        {

        }

        public void Copy(EMPLOYEE copyOjbect)
        {
            copyOjbect.FIRSTNAME = this.FIRSTNAME;
            copyOjbect.LASTNAME = this.LASTNAME;
            copyOjbect.RCODE = this.RCODE;
            copyOjbect.ADDRESS.CITY = this.ADDRESS.CITY;
            copyOjbect.ADDRESS.STATE = this.ADDRESS.STATE;
            copyOjbect.ADDRESS.STREET = this.ADDRESS.STREET;
            copyOjbect.ADDRESS.POSTALCODE = this.ADDRESS.POSTALCODE;
            copyOjbect.CONTACTINFO.PHONE1 = this.CONTACTINFO.PHONE1;
            copyOjbect.CONTACTINFO.PHONE2 = this.CONTACTINFO.PHONE2;
            copyOjbect.CONTACTINFO.EMAIL = this.CONTACTINFO.EMAIL;
            copyOjbect.EMPLOYEEDETAIL.AFM = this.EMPLOYEEDETAIL.AFM;
            copyOjbect.EMPLOYEEDETAIL.AT = this.EMPLOYEEDETAIL.AT;
            copyOjbect.EMPLOYEEDETAIL.BIRTHDATE = this.EMPLOYEEDETAIL.BIRTHDATE;
            copyOjbect.EMPLOYEEDETAIL.GENDER = this.EMPLOYEEDETAIL.GENDER;
            copyOjbect.EMPLOYEEDETAIL.MARITALSTATUS = this.EMPLOYEEDETAIL.MARITALSTATUS;
            copyOjbect.EMPLOYEEDETAIL.SECLICEXPDATE = this.EMPLOYEEDETAIL.SECLICEXPDATE;

            //This Doen't work
            //copyOjbect.ADDRESS = this.ADDRESS;
            //copyOjbect.CONTACTINFO = this.CONTACTINFO;
            //copyOjbect.EMPLOYEEDETAIL = this.EMPLOYEEDETAIL;
        }
    }
}
