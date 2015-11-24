using NUnit.Framework;
using System;

namespace CertiPay.Payroll.Common.Tests
{
    public class MonthTests
    {
        private const int year = 2015;

        [Test]
        [TestCase("JANUARY", Month.January)]
        [TestCase("february", Month.February)]
        [TestCase("maRcH", Month.March)]
        [TestCase("April", Month.April)]
        [TestCase("May", Month.May)]
        [TestCase("June", Month.June)]
        [TestCase("July", Month.July)]
        [TestCase("August", Month.August)]
        [TestCase("September", Month.September)]
        [TestCase("October", Month.October)]
        [TestCase("November", Month.November)]
        [TestCase("December", Month.December)]
        public void Parse(String month, Month expected)
        {
            Assert.AreEqual(expected, Months.Parse(month));
        }

        [Test]
        [TestCase(Month.January, "1/1/2015")]
        [TestCase(Month.December, "12/1/2015")]
        public void FirstDayOfMonth(Month month, String expected)
        {
            Assert.AreEqual(DateTime.Parse(expected), month.FirstDayOfMonth(year));
        }

        [Test]
        [TestCase(Month.January, "1/31/2015")]
        [TestCase(Month.June, "6/30/2015")]
        [TestCase(Month.December, "12/31/2015")]
        public void LastDayOfMonth(Month month, String expected)
        {
            Assert.AreEqual(DateTime.Parse(expected), month.LastDayOfMonth(year));
        }
    }
}