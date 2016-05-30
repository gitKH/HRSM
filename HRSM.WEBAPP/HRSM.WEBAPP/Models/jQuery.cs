using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HRSM.WEBAPP.Models
{
    public class jQuery
    {
        public static class Mask
        {
            public static HtmlString Employee()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<script>");
                builder.AppendLine("$(document).ready(function () {");
                builder.AppendLine("$(\"#EMPLOYEEDETAIL_SECLICEXPDATE\").mask('00/00/0000');");
                builder.AppendLine("$(\"#EMPLOYEEDETAIL_BIRTHDATE\").mask('00/00/0000');");
                builder.AppendLine("$(\"#RCODE\").mask('00000');");
                builder.AppendLine("$(\"#ADDRESS_POSTALCODE\").mask('00 000');");
                builder.AppendLine("$(\"#CONTACTINFO_PHONE1\").mask('000 0000000');");
                builder.AppendLine("$(\"#CONTACTINFO_PHONE2\").mask('0000000000');");
                builder.AppendLine("});");
                builder.AppendLine("</script>");
                return new HtmlString(builder.ToString());
            }

            public static HtmlString GuardSite()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<script>");
                builder.AppendLine("$(document).ready(function () {");
                builder.AppendLine("$(\"#RCODE\").mask('00-00-0000');");
                builder.AppendLine("$(\"#ADDRESS_POSTALCODE\").mask('00 000');");
                builder.AppendLine("$(\"#SITEMANAGER_CONTACTINFO_PHONE1\").mask('000 0000000');");
                builder.AppendLine("$(\"#SITEMANAGER_CONTACTINFO_PHONE2\").mask('0000000000');");
                builder.AppendLine("});");
                builder.AppendLine("</script>");
                return new HtmlString(builder.ToString());
            }
        }

        public static class Ajax
        {
            public static HtmlString EmployeeFormWithOutIDs()
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("$(\"#RCODE\").val(data.RCODE);");
                builder.AppendLine("$(\"#FIRSTNAME\").val(data.FIRSTNAME);");
                builder.AppendLine("$(\"#LASTNAME\").val(data.LASTNAME);");
                builder.AppendLine("$(\"#ADDRESS_CITY\").val(data.ADDRESS.CITY);");
                builder.AppendLine("$(\"#ADDRESS_STREET\").val(data.ADDRESS.STREET);");
                builder.AppendLine("$(\"#ADDRESS_STATE\").val(data.ADDRESS.STATE);");
                builder.AppendLine("$(\"#ADDRESS_POSTALCODE\").val(data.ADDRESS.POSTALCODE);");
                builder.AppendLine("$(\"#CONTACTINFO_PHONE1\").val(data.CONTACTINFO.PHONE1);");
                builder.AppendLine("$(\"#CONTACTINFO_PHONE2\").val(data.CONTACTINFO.PHONE2);");
                builder.AppendLine("$(\"#CONTACTINFO_EMAIL\").val(data.CONTACTINFO.EMAIL);");
                builder.AppendLine("$(\"#EMPLOYEEDETAIL_AT\").val(data.EMPLOYEEDETAIL.AT);");
                builder.AppendLine("$(\"#EMPLOYEEDETAIL_AFM\").val(data.EMPLOYEEDETAIL.AFM);");
                builder.AppendLine("$(\"#EMPLOYEEDETAIL_GENDER\").val(data.EMPLOYEEDETAIL.GENDER);");
                builder.AppendLine("$(\"#EMPLOYEEDETAIL_BIRTHDATE\").val(data.EMPLOYEEDETAIL.BIRTHDATE);");
                builder.AppendLine("$(\"#EMPLOYEEDETAIL_MARITALSTATUS\").val(data.EMPLOYEEDETAIL.MARITALSTATUS);");
                builder.AppendLine("$(\"#EMPLOYEEDETAIL_SECLICEXPDATE\").val(data.EMPLOYEEDETAIL.SECLICEXPDATE);");

                return new HtmlString(builder.ToString());
            }
        }
    }
}