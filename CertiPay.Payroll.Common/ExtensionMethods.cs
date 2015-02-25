using System;

namespace CertiPay.Payroll.Common
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Round the decimal to the given number of decimal places using the given method of rounding.
        /// By default, this is 2 decimal places to the nearest even for middle values
        /// i.e. 1.455 -> 1.46
        /// </summary>
        public static Decimal Round(this Decimal val, int decimals = 2, MidpointRounding rounding = MidpointRounding.ToEven)
        {
            return Math.Round(val, decimals, rounding);
        }
    }
}