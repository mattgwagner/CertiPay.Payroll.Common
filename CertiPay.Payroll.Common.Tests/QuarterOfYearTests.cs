using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertiPay.Payroll.Common.Tests
{
    public class QuarterOfYearTests
    {
        const int year = 2015;

        [Test]
        [TestCase(QuarterOfYear.Q1, "1/1/2015")]
        [TestCase(QuarterOfYear.Q2, "4/1/2015")]
        [TestCase(QuarterOfYear.Q3, "7/1/2015")]
        [TestCase(QuarterOfYear.Q4, "10/1/2015")]
        public void Returns_Start_Of_Quarter(QuarterOfYear quarter, String expected)
        {
            Assert.AreEqual(DateTime.Parse(expected), quarter.Start(year));
        }

        [Test]
        [TestCase(QuarterOfYear.Q1, "3/31/2015")]
        [TestCase(QuarterOfYear.Q2, "6/30/2015")]
        [TestCase(QuarterOfYear.Q3, "9/30/2015")]
        [TestCase(QuarterOfYear.Q4, "12/31/2015")]
        public void Returns_End_of_Quarter(QuarterOfYear quarter, String expected)
        {
            Assert.AreEqual(DateTime.Parse(expected), quarter.End(year));
        }

        [Test]
        [TestCase("1/10/2015", QuarterOfYear.Q1)]
        [TestCase("10/1/2015", QuarterOfYear.Q4)]
        [TestCase("3/15/2015", QuarterOfYear.Q1)]
        [TestCase("9/30/2015", QuarterOfYear.Q3)]
        public void Returns_Expected_Quarter(String date, QuarterOfYear expected)
        {
            Assert.AreEqual(expected, DateTime.Parse(date).GetQuarter());
        }
    }
}
