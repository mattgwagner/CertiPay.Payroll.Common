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

        [Theory]
        public void Should_Calculate_Annualized_Pay(PayrollFrequency freq, [Random(0, 10000.00, 50)]Decimal payPeriod)
        {
            Assert.That(freq.CalculateAnnualized(payPeriod), Is.EqualTo(freq.AnnualizedPayPeriods() * payPeriod));
        }

        [Theory]
        public void Should_Calculate_DeAnnualized_Pay(PayrollFrequency freq, [Random(0, 300000.00, 50)]Decimal perYear)
        {
            Assert.That(freq.CalculateDeannualized(perYear), Is.EqualTo(perYear / freq.AnnualizedPayPeriods()).Within(0.01));
        }
    }
}