using System;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Represents the year broken into four quarters, commonly for tax or reporting purposes
    /// </summary>
    public enum QuarterOfYear : byte
    {
        /// <summary>
        /// January, February, March
        /// </summary>
        [Display(Name = "Q1 (January, February, March)")]
        Q1 = 1,

        /// <summary>
        /// April, May, June
        /// </summary>
        [Display(Name = "Q2 (April, May, June)")]
        Q2 = 2,

        /// <summary>
        /// July, August, September
        /// </summary>
        [Display(Name = "Q3 (July, August, September)")]
        Q3 = 3,

        /// <summary>
        /// October, November, December
        /// </summary>
        [Display(Name = "Q4 (October, November, December)")]
        Q4 = 4
    }

    public static class QuarterOfYearExtensions
    {
        /// <summary>
        /// Returns the first day of the quarter.
        ///
        /// If no year is provided, it will return for the current year
        /// </summary>
        public static DateTime Start(this QuarterOfYear quarter, int? year = null)
        {
            switch (quarter)
            {
                case QuarterOfYear.Q1:
                    return new DateTime(year ?? DateTime.Today.Year, 1, 1);

                case QuarterOfYear.Q2:
                    return new DateTime(year ?? DateTime.Today.Year, 4, 1);

                case QuarterOfYear.Q3:
                    return new DateTime(year ?? DateTime.Today.Year, 7, 1);

                case QuarterOfYear.Q4:
                    return new DateTime(year ?? DateTime.Today.Year, 10, 1);

                default:
                    throw new ArgumentOutOfRangeException("There's only four quarters?");
            }
        }

        /// <summary>
        /// Returns the last day of the quarter.
        ///
        /// If no year is provided, it will return for the current year
        /// </summary>
        public static DateTime End(this QuarterOfYear quarter, int? year = null)
        {
            switch (quarter)
            {
                case QuarterOfYear.Q1:
                    return new DateTime(year ?? DateTime.Today.Year, 3, 31);

                case QuarterOfYear.Q2:
                    return new DateTime(year ?? DateTime.Today.Year, 6, 30);

                case QuarterOfYear.Q3:
                    return new DateTime(year ?? DateTime.Today.Year, 9, 30);

                case QuarterOfYear.Q4:
                    return new DateTime(year ?? DateTime.Today.Year, 12, 31);

                default:
                    throw new ArgumentOutOfRangeException("There's only four quarters?");
            }
        }

        /// <summary>
        /// Returns the QuarterOfYear that the date falls into
        /// </summary>
        public static QuarterOfYear GetQuarter(this DateTime date)
        {
            if (date < QuarterOfYear.Q2.Start(date.Year))
                return QuarterOfYear.Q1;

            if (date < QuarterOfYear.Q3.Start(date.Year))
                return QuarterOfYear.Q2;

            if (date < QuarterOfYear.Q4.Start(date.Year))
                return QuarterOfYear.Q3;

            return QuarterOfYear.Q4;
        }
    }
}