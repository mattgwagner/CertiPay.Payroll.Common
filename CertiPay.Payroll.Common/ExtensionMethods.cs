using System;
using System.ComponentModel;
using System.Reflection;

namespace CertiPay.Payroll.Common
{
    public static class ExtensionMethods
    {
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