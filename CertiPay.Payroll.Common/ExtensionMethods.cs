using System;
using System.ComponentModel;
using System.Reflection;

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

        /// <summary>
        /// Returns the display name from the description attribute on the enumeration, if available.
        /// Otherwise returns the ToString() value.
        /// </summary>
        public static string DisplayName(this Enum val)
        {
            FieldInfo fi = val.GetType().GetField(val.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return val.ToString();
        }
    }
}