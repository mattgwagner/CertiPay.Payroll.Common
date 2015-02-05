using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Identifies the method to calculate the result
    /// </summary>
    public enum CalculationType : byte
    {
        // TODO: We might implement some other calculation methods as needed?
        // Percent of Special Earnings: Select to calculate the deduction as a percent of a special accumulator, such as 401(k).

        /// <summary>
        /// Deduction is taken as a percentage of the gross pay
        /// </summary>
        [Display(Name = "Percent of Gross Pay")]
        PercentOfGrossPay = 1,

        /// <summary>
        /// Deduction is taken as a percentage of the net pay
        /// </summary>
        [Display(Name = "Percent of Net Pay")]
        PercentOfNetPay = 2,

        /// <summary>
        /// Deduction is taken as a flat, fixed amount
        /// </summary>
        [Display(Name = "Fixed Amount")]
        FixedAmount = 3,

        /// <summary>
        /// Deduction is taken as a fixed amount per hour of work
        /// </summary>
        [Display(Name = "Fixed Hourly Amount")]
        FixedHourlyAmount = 4
    }

    public static class CalculationTypes
    {
        public static IEnumerable<CalculationType> Values()
        {
            yield return CalculationType.PercentOfGrossPay;
            yield return CalculationType.PercentOfNetPay;
            yield return CalculationType.FixedAmount;
            yield return CalculationType.FixedHourlyAmount;
        }
    }
}