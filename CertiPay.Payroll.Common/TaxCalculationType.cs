using System.Collections.Generic;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// The tax method indicates the tax calculation method to be used for the pay.
    /// </summary>
    public enum TaxCalculationType
    {
        /// <summary>
        /// Annualized: Select to annualize the earnings, calculate the tax on the annualized amount, and divide the tax by the number of pay periods in the year.
        /// The result is the withholding for the pay period. This is the most common tax method.
        /// </summary>
        Annualized = 1,

        /// <summary>
        /// (USA) Supplemental: Select to calculate taxes as a straight percentage of earnings. This method is typically used for one-time pays,
        /// such as bonuses. For example, federal supplemental withholding is 25 percent of earnings. Some states vary the percentage based on annual income,
        /// while some states require PeopleSoft-maintained tax tables to calculate withholding.
        /// </summary>
        Supplemental = 2,

        /// <summary>
        /// (USA) Aggregate: Select to tax the lump sum of the current payment with a previous payment. The system takes the last confirmed paycheck for that
        /// pay period and adds the current payment to it. Taxes are calculated on that lump sum amount, the taxes that were withheld on the confirmed check are subtracted,
        /// and the resulting tax difference is the tax for the current payment.
        /// </summary>
        Aggregate = 3,

        /// <summary>
        /// Cumulative: Select to add together the year-to-date earnings and the earnings for this pay period, annualize the result,
        /// and calculate the annualized tax. The system deannualizes the tax by dividing it by the number of tax periods you specified on the paysheet.
        /// The result is compared to the year-to-date withholding; if it is greater than the year-to-date withholding, the difference becomes the withholding
        /// for the pay period. You generally use this for employees whose wages vary significantly from pay period to pay period, such as salespeople on commission.
        /// </summary>
        Cumulative = 4,
    }

    public static class TaxCalculationTypes
    {
        public static IEnumerable<TaxCalculationType> Values()
        {
            yield return TaxCalculationType.Annualized;
            yield return TaxCalculationType.Supplemental;
            yield return TaxCalculationType.Aggregate;
            yield return TaxCalculationType.Cumulative;
        }
    }
}