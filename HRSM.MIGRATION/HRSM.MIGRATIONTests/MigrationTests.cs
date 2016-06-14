using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSM.MIGRATION;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HRSM.MIGRATION.Tests
{
    [TestClass()]
    public class MigrationTests
    {
        [TestMethod()]
        public void CopyAllEmployeesFromGalaxyToHRSMTest()
        {
            Migration migration = new Migration();

            migration.CopyAllEmployeesFromGalaxyToHRSM();
        }
    }
}
