using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Identifies the method to calculate the result
    /// </summary>
    public enum CalculationType : byte
    {
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
        FixedHourlyAmount = 4,

        /// <summary>
        /// Deduction is taken as a percentage of the disposable income (gross pay - payroll taxes)
        /// </summary>
        [Display(Name = "Percent of Disposable Income")]
        PercentOfDisposableIncome = 5
    }

    public static class CalculationTypes
    {
        /// <summary>
        /// Returns a list of the available calculation types
        /// </summary>
        public static IEnumerable<CalculationType> Values()
        {
            yield return CalculationType.PercentOfGrossPay;
            yield return CalculationType.PercentOfNetPay;
            yield return CalculationType.FixedAmount;
            yield return CalculationType.FixedHourlyAmount;
            yield return CalculationType.PercentOfDisposableIncome;
        }
    }
}