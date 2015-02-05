using System;
using System.ComponentModel.DataAnnotations;
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
        /// Returns the display name from the display attribute on the enumeration, if available.
        /// Otherwise returns the ToString() value.
        /// </summary>
        public static string DisplayName(this Enum val)
        {
            return val.Display(e => e.Name);
        }

        /// <summary>
        /// Returns the short name from the display attribute on the enumeration, if available.
        /// Otherwise returns the ToString() value.
        /// </summary>
        public static string ShortName(this Enum val)
        {
            return val.Display(e => e.ShortName);
        }

        /// <summary>
        /// Returns the description from the display attribute on the enumeration, if available.
        /// Otherwise returns the ToString() value.
        /// </summary>
        public static string Description(this Enum val)
        {
            return val.Display(e => e.Description);
        }

        private static String Display(this Enum val, Func<DisplayAttribute, String> selector)
        {
            FieldInfo fi = val.GetType().GetField(val.ToString());

            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return selector.Invoke(attributes[0]);
            }

            return val.ToString();
        }
    }
}