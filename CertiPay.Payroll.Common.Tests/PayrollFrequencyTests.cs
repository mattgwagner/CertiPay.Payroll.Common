using NUnit.Framework;

namespace CertiPay.Payroll.Common.Tests
{
    public class PayrollFrequencyTests
    {
        [Test]
        [TestCase(PayrollFrequency.Monthly, 12)]
        [TestCase(PayrollFrequency.SemiMonthly, 24)]
        [TestCase(PayrollFrequency.Weekly, 52)]
        public void Should_Return_Correct_Annualized_PayPeriods(PayrollFrequency freq, int expectedPeriods)
        {
            Assert.AreEqual(expectedPeriods, freq.AnnualizedPayPeriods());
        }
    }
}