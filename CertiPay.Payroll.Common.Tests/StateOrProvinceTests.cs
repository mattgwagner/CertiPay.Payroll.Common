using CertiPay.Common;
using NUnit.Framework;
using System;
using System.Linq;

namespace CertiPay.Payroll.Common.Tests
{
    public class StateOrProvinceTest
    {
        [Test]
        [TestCase(StateOrProvince.FL, "Florida", "FL")]
        [TestCase(StateOrProvince.WA, "Washington", "WA")]
        [TestCase(StateOrProvince.FL, "Florida", "FL")]
        public void Should_Display_Description_Attribute(StateOrProvince state, String should_display, String short_code)
        {
            var display_value = state.DisplayName();

            Assert.AreEqual(should_display, state.DisplayName());

            Assert.AreEqual(short_code, state.ToString());
        }

        [Test]
        public void Should_Include_Important_States()
        {
            var states = States.Values();

            Assert.IsTrue(states.Contains(StateOrProvince.FL));
            Assert.IsTrue(states.Contains(StateOrProvince.GA));
            Assert.IsTrue(states.Contains(StateOrProvince.AL));
            Assert.IsTrue(states.Contains(StateOrProvince.SC));
        }

        [Test]
        [TestCase("Florida", StateOrProvince.FL)]
        [TestCase("North Carolina", StateOrProvince.NC)]
        [TestCase("Texas", StateOrProvince.TX)]
        [TestCase("New Jersey", StateOrProvince.NJ)]
        public void Should_Find_State_By_Name(String name, StateOrProvince state)
        {
            var find_by_name = States.GetStateByName(name);

            Assert.AreEqual(state, find_by_name);
        }
    }
}