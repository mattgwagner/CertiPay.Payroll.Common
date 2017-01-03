using NUnit.Framework;
using System;


namespace CertiPay.Payroll.Common.Tests
{
    public class AddressTest
    {
        [Test]
        public void TestAddressEqual()
        {
            var address1 = new Address()
            {
                Address1 = "604 Ralph Street",
                Address2 = "",
                Address3 = "",
                City = "Auburndale",
                State = StateOrProvince.FL,
                PostalCode = "8823"
            };

            var address2 = new Address()
            {
                Address1 = "604 Ralph Street",
                Address2 = "",
                Address3 = "",
                City = "Auburndale",
                State = StateOrProvince.FL,
                PostalCode = "8823"
            };

            Assert.IsTrue(address1.Equals(address2));
            Assert.IsTrue(address1 == address2);            
        }

        [Test]
        public void TestAddressNotEqual()
        {
            var address1 = new Address()
            {
                Address1 = "604 Ralph Street",
                Address2 = "",
                Address3 = "",
                City = "Auburndale",
                State = StateOrProvince.FL,
                PostalCode = "8823"
            };

            var address2 = new Address()
            {
                Address1 = "603 Ralph Street",
                Address2 = "",
                Address3 = "",
                City = "Auburndale",
                State = StateOrProvince.FL,
                PostalCode = "8823"
            };

            Assert.IsFalse(address1.Equals(address2));
            Assert.IsFalse(address1 == address2);
            Assert.IsFalse(address1.Equals(null));
            Object o = new object();
            Assert.IsFalse(address1.Equals(o));
        }
    }
}
