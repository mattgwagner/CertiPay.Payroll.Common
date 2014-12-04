using NUnit.Framework;
using System;

namespace CertiPay.Payroll.Common.Tests
{
    public class PayrollFrequencyTests
    {
        [Test]
        [TestCase(PayrollFrequency.Monthly, 12)]
        [TestCase(PayrollFrequency.SemiMonthly, 24)]
        [TestCase(PayrollFrequency.Weekly, 52)]
        [TestCase(PayrollFrequency.Daily, 260)]
        [TestCase(PayrollFrequency.BiWeekly, 26)]
        public void Should_Return_Correct_Annualized_PayPeriods(PayrollFrequency freq, int expectedPeriods)
        {
            Assert.AreEqual(expectedPeriods, freq.AnnualizedPayPeriods());
        }

        [Test]
        [TestCase(PayrollFrequency.Monthly, 1000, 12000)]
        [TestCase(PayrollFrequency.BiWeekly, 1000, 26000)]
        [TestCase(PayrollFrequency.Weekly, 1000, 52000)]
        [TestCase(PayrollFrequency.SemiMonthly, 1000, 24000)]
        [TestCase(PayrollFrequency.Daily, 1000, 260000)]
        [TestCase(PayrollFrequency.BiWeekly, 1234.56, 32098.56)]
        public void Should_Calculate_Annualized_Pay(PayrollFrequency freq, Decimal payPeriod, Decimal expected)
        {
            Assert.AreEqual(expected, freq.CalculateAnnualized(payPeriod));
        }

        [Test]
        [TestCase(PayrollFrequency.Monthly, 1000, 12000)]
        [TestCase(PayrollFrequency.BiWeekly, 1000, 26000)]
        [TestCase(PayrollFrequency.Weekly, 1000, 52000)]
        [TestCase(PayrollFrequency.SemiMonthly, 1000, 24000)]
        [TestCase(PayrollFrequency.Daily, 1000, 260000)]
        [TestCase(PayrollFrequency.BiWeekly, 1234.56, 32098.56)]
        public void Should_Calculate_DeAnnualized_Pay(PayrollFrequency freq, Decimal expected, Decimal perYear)
        {
            Assert.AreEqual(expected, freq.CalculateDeannualized(perYear));
        }
    }
}