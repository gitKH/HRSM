using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSRM.GALAXYERP
{
    public class GalaxtErpContext
    {
        public void HRSMEMPLOYEES()
        {

        }

        public GalaxyEMPLOYEE GetEmployeeById(string RCODE)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = @"srv-gsto\galaxydb",
                InitialCatalog = "GlxPower",
                UserID = "sa",
                Password = "infosupport"
            };

            string query = "select * from HRSMEMPLOYEES where PLCODE = @PLCODE";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@PLCODE", RCODE);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return new GalaxyEMPLOYEE()
                            {
                                RCODE = Convert.ToString(dr["PLCODE"]),
                                FIRSTNAME = Convert.ToString(dr["PLNAME"]),
                                LASTNAME = Convert.ToString(dr["PLSURNAME"]),
                                STREET  = Convert.ToString(dr["PLSTREET"]),
                                STREETNUMBER = Convert.ToString(dr["PLSTREETNUMBER"]),
                                POSTALCODE = Convert.ToString(dr["PLPOSTALCODE"]),
                                PHONE1 = Convert.ToString(dr["PLPHONE1"]),
                                PHONE2 = Convert.ToString(dr["PLCELLPHONE"]),
                                EMAIL = Convert.ToString(dr["PLEMAIL"]),
                                AT = Convert.ToString(dr["PLIDENTITYCARDID"]),
                                AFM = Convert.ToString(dr["PLTIN"]),
                                GENDER = Convert.ToInt32(dr["PLGENDER"]),
                                BIRTHDATE = Convert.ToDateTime(dr["PLBIRTHDAY"]),
                                MARITALSTATUS = Convert.ToInt32(dr["PLMARITALSTATUS"])
                            };
                        }
                    }
                } 
            }
            return null;
        }
    }
}
