using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSM.GLXERP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HRSM.GLXERP.Tests
{
    [TestClass()]
    public class GalaxtErpContextTests
    {
        [TestMethod()]
        public void GetEmployeeByIdTest()
        {
            //Arrange

            GalaxtErpContext emp = new GalaxtErpContext();
            //Act
            string expected = "ΑΝΔΡΕΑΣ";
            string actual = emp.GetEmployeeById("01040").FIRSTNAME;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
