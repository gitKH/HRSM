using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSM.DATAMODEL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace HRSM.DATAMODEL.Tests
{
    [TestClass()]
    public class GUARDSITESTests
    {

        private HRSMContextContainer database;
        public GUARDSITESTests()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            database = new HRSMContextContainer(connectionString);
        }

        [TestMethod()]
        public void GuardSiteSeed()
        {
            List<GUARDSITE> list = new List<GUARDSITE>();

            list.Add(new GUARDSITE()
            {
                RCODE = "30-00-1500",
                SITENAME = "ALPHA BANK",
                ISACTIVE = STATUS.ACTIVE,
                SITEMANAGER = new SITEMANAGER()
                {
                    NAME = "ΣΠΑΝΟΥΔΑΚΗΣ ΧΡΗΣΤΟΣ",
                    CONTACTINFO = new CONTACTINFO()
                    {
                        PHONE1 = "2106728890",
                        PHONE2 = "6985555202",
                        EMAIL = "info@alphabank.com"
                    }
                },
                ADDRESS = new ADDRESS()
                {
                    CITY = "ΑΘΗΝΑ",
                    STREET = "ΣΤΑΔΙΟΥ 47",
                    STATE = "ΑΤΤΙΚΗ",
                    POSTALCODE = "11845"
                }
            });
            list.Add(new GUARDSITE()
            {
                RCODE = "30-00-1602",
                SITENAME = "EUROBANK",
                ISACTIVE = STATUS.INACTIVE,
                SITEMANAGER = new SITEMANAGER()
                {
                    NAME = "ΔΗΜΗΤΡΑΚΟΠΟΥΛΟΣ ΓΙΑΝΝΗΣ",
                    CONTACTINFO = new CONTACTINFO()
                    {
                        PHONE1 = "2106728890",
                        PHONE2 = "6985555202",
                        EMAIL = "dm@eurobank.gr"
                    }
                },
                ADDRESS = new ADDRESS()
                {
                    CITY = "ΑΘΗΝΑ",
                    STREET = "ΑΜΑΛΙΑΣ 32",
                    STATE = "ΑΤΤΙΚΗ",
                    POSTALCODE = "11845"
                }
            });

            database.GUARDSITES.AddRange(list);
            database.SaveChanges();
        }

        [TestMethod()]
        public void GuardSiteRemove()
        {
            GUARDSITE guardSite = database.GUARDSITES.IncludeAll().First();
            database.GUARDSITES.Remove(guardSite);
            database.SaveChanges();
        }
    }
}
