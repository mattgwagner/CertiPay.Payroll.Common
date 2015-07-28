using NUnit.Framework;
using System;

namespace CertiPay.Payroll.Common.Tests
{
    public class BankAccountTests
    {
        [Theory]
        [TestCase("111000025", true)] // BoA in Virginia
        [TestCase("021000021", true)] // JPMorgan
        [TestCase("053100465", true)] // SunTrust
        [TestCase("263177563", true)] // MIDFLORIDA
        [TestCase("314074269", true)] // USAA

        [TestCase("000000001", false)]
        [TestCase("123456789", false)]
        [TestCase("111111117", false)]
        [TestCase("100000009", false)]
        [TestCase("101010101", false)]
        public void Validate_Routing_Number(String routingNumber, Boolean is_valid)
        {
            Assert.AreEqual(is_valid, BankAccount.IsValidRoutingNumber(routingNumber), "Routing # validation failed");
        }
    }
}