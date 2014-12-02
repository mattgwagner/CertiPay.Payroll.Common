using System;
using System.Collections.Generic;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// How often payroll is run for a company / group of employees
    /// </summary>
    public enum PayrollFrequency
    {
        /// <summary>
        /// Every day of work
        /// </summary>
        Daily = 1,

        /// <summary>
        /// Every week, i.e. every Friday
        /// </summary>
        Weekly = 2,

        /// <summary>
        /// Every second week, i.e. every other Friday
        /// </summary>
        BiWeekly = 3,

        /// <summary>
        /// Twice per month, i.e. 1st and 15th
        /// </summary>
        SemiMonthly = 4,

        /// <summary>
        /// Once per month, i.e. 1st of the month
        /// </summary>
        Monthly = 5
    }

    public static class PayrollFrequencies
    {
        public static IEnumerable<PayrollFrequency> Values()
        {
            yield return PayrollFrequency.Daily;
            yield return PayrollFrequency.Weekly;
            yield return PayrollFrequency.BiWeekly;
            yield return PayrollFrequency.SemiMonthly;
            yield return PayrollFrequency.Monthly;
        }

        /// <summary>
        /// Returns the number of times payroll should run for the given configured frequency
        /// in a calendar year, i.e. monthly pay => 12 pay periods
        /// </summary>
        public static int AnnualizedPayPeriods(this PayrollFrequency payroll)
        {
            switch (payroll)
            {
                case PayrollFrequency.Daily:
                    // 5 days per week x 52 weeks = 260
                    return 260;

                case PayrollFrequency.Weekly:
                    return 52;

                case PayrollFrequency.BiWeekly:
                    return 26;

                case PayrollFrequency.SemiMonthly:
                    return 24;

                case PayrollFrequency.Monthly:
                    return 12;

                default:
                    throw new Exception("Invalid payroll frequency!");
            }
        }

        public static Decimal CalculateAnnualized(this PayrollFrequency frequency, Decimal perPayPeriodIncome)
        {
            if (perPayPeriodIncome < 0) throw new ArgumentOutOfRangeException("Cannot have negative income");

            return frequency.AnnualizedPayPeriods() * perPayPeriodIncome;
        }
    }
}