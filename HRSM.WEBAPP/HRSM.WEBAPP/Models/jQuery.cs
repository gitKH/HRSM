﻿using System;
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
                builder.AppendLine("$(\"#RCODE\").mask('00-00-0000');");
                builder.AppendLine("$(\"#ADDRESS_POSTALCODE\").mask('00 000');");
                builder.AppendLine("$(\"#CONTACTINFO_PHONE1\").mask('000 0000000');");
                builder.AppendLine("$(\"#CONTACTINFO_PHONE2\").mask('0000000000');");
                builder.AppendLine("});");
                builder.Append("</script>");
                return new HtmlString(builder.ToString());
            }
        }
    }
}