using System;
using System.Collections.Generic;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Represents the months of the calendar year.
    /// </summary>
    public enum Month : byte
    {
        January = 1,

        February = 2,

        March = 3,

        April = 4,

        May = 5,

        June = 6,

        July = 7,

        August = 8,

        September = 9,

        October = 10,

        November = 11,

        December = 12
    }

    public static class Months
    {
        /// <summary>
        /// Returns the months of the year
        /// </summary>
        public static IEnumerable<Month> Values()
        {
            foreach (Month month in Enum.GetValues(typeof(Month)))
            {
                yield return month;
            }
        }

        /// <summary>
        /// Parses the case-insensitive string representation of the month (i.e. January, March...)
        /// </summary>
        public static Month Parse(String value)
        {
            return (Month)Enum.Parse(typeof(Month), value, ignoreCase: true);
        }

        /// <summary>
        /// Returns the date time of the first day of the given month and optional year.
        ///
        /// If no year is provided, the current calendar year is used.
        /// </summary>
        public static DateTime FirstDayOfMonth(this Month month, int? year = null)
        {
            return new DateTime(year ?? DateTime.Today.Year, (int)month, 1);
        }

        /// <summary>
        /// Returns the date time of the last day of the given month and optional year.
        ///
        /// If no year is provided, the current calendar year is used.
        /// </summary>
        public static DateTime LastDayOfMonth(this Month month, int? year = null)
        {
            return
                FirstDayOfMonth(month, year)
                .AddMonths(1)
                .AddDays(-1);
        }
    }
}