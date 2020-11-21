using System;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace WebUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RolesManager dal = new RolesManager();
           
            //断言
            Assert.IsTrue(dal.GetAll().Count < 0);
        }
    }
}
