using NUnit.Framework;
using System;

namespace CertiPay.Payroll.Common.Tests
{
    public class TaxpayerIdentificationNumberTests
    {
        [Test]
        [TestCase("123456789", "123-45-6789 (SSN)")]
        [TestCase("878889898", "878-88-9898 (SSN)")]
        public void Should_Strip_Non_Digits(String input, String expected)
        {
            var tin = new TaxpayerIdentificationNumber
            {
                Value = expected,
                Type = TaxpayerIdentificationNumber.TINType.SSN
            };

            Assert.AreNotEqual(expected, tin.Value);

            Assert.AreEqual(expected, tin.ToString());
        }

        [Test]
        [TestCase("123456789", "123-45-6789 (SSN)")]
        [TestCase("878889898", "878-88-9898 (SSN)")]
        public void Should_Format_SSN(String input, String expected)
        {
            var tin = new TaxpayerIdentificationNumber
            {
                Value = input,
                Type = TaxpayerIdentificationNumber.TINType.SSN
            };

            Assert.AreEqual(expected, tin.ToString());
        }

        [Test]
        [TestCase("123456789", "123-45-6789 (ITIN)")]
        [TestCase("878889898", "878-88-9898 (ITIN)")]
        public void Should_Format_ITIN(String input, String expected)
        {
            var tin = new TaxpayerIdentificationNumber
            {
                Value = input,
                Type = TaxpayerIdentificationNumber.TINType.ITIN
            };

            Assert.AreEqual(expected, tin.ToString());
        }

        [Test]
        [TestCase("123456789", "12-3456789 (EIN)")]
        [TestCase("878889898", "87-8889898 (EIN)")]
        public void Should_Format_EIN(String input, String expected)
        {
            var tin = new TaxpayerIdentificationNumber
            {
                Value = input,
                Type = TaxpayerIdentificationNumber.TINType.EIN
            };

            Assert.AreEqual(expected, tin.ToString());
        }
    }
}