using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class SalesReportTests
    {
        private SalesReport TestSalesReport = new SalesReport();
        [TestMethod]
        public void FeedMoneyReportHappyPathTest()
        {
            decimal moneyFed = 5;
            decimal totalMoney = 10;
            Assert.IsTrue(TestSalesReport.FeedMoneyReport(moneyFed, totalMoney));
        }
        [TestMethod]
        public void BoughtProductReportHappyPathTest()
        {

        }
        [TestMethod]
        public void DispensedChangeReportHappyPathTest()
        {

        }
    }
}
