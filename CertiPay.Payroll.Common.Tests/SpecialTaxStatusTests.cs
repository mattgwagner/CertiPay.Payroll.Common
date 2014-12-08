using NUnit.Framework;

namespace CertiPay.Payroll.Common.Tests
{
    public class SpecialTaxStatusTests
    {
        [Test]
        [TestCase(SpecialTaxStatus.ExemptFromLocalTax | SpecialTaxStatus.ExemptFromFederalTax, SpecialTaxStatus.ExemptFromLocalTax)]
        [TestCase(SpecialTaxStatus.None, SpecialTaxStatus.None)]
        [TestCase(SpecialTaxStatus.ExemptFromMedicare | SpecialTaxStatus.ExemptFromSocialSecurity, SpecialTaxStatus.ExemptFromSocialSecurity)]
        [TestCase(SpecialTaxStatus.ExemptFromLocalTax | SpecialTaxStatus.ExemptFromStateTax, SpecialTaxStatus.ExemptFromStateTax)]
        [TestCase(SpecialTaxStatus.ExemptFromFICA, SpecialTaxStatus.ExemptFromMedicare)]
        [TestCase(SpecialTaxStatus.ExemptFromFICA, SpecialTaxStatus.ExemptFromSocialSecurity)]
        [TestCase(SpecialTaxStatus.ExemptFromFICA, SpecialTaxStatus.ExemptFromMedicare & SpecialTaxStatus.ExemptFromSocialSecurity)]
        [TestCase(SpecialTaxStatus.ExemptFromFICA, SpecialTaxStatus.ExemptFromMedicare | SpecialTaxStatus.ExemptFromSocialSecurity)]
        public void Should_Have_Flags(SpecialTaxStatus flags, SpecialTaxStatus should_have)
        {
            Assert.IsTrue(flags.HasFlag(should_have));
        }

        [Test]
        [TestCase(SpecialTaxStatus.ExemptFromSocialSecurity | SpecialTaxStatus.ExemptFromFederalTax, SpecialTaxStatus.ExemptFromStateTax)]
        [TestCase(SpecialTaxStatus.ExemptFromFederalTax, SpecialTaxStatus.ExemptFromStateTax)]
        [TestCase(SpecialTaxStatus.ExemptFromSocialSecurity, SpecialTaxStatus.ExemptFromStateTax)]
        [TestCase(SpecialTaxStatus.None, SpecialTaxStatus.ExemptFromStateTax)]
        [TestCase(SpecialTaxStatus.ExemptFromMedicare, SpecialTaxStatus.ExemptFromFICA)]
        [TestCase(SpecialTaxStatus.ExemptFromSocialSecurity, SpecialTaxStatus.ExemptFromFICA)]
        public void Should_Not_Have_Flags(SpecialTaxStatus flags, SpecialTaxStatus should_not_have)
        {
            Assert.IsFalse(flags.HasFlag(should_not_have));
        }
    }
}