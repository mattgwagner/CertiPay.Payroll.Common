using System.Collections.Generic;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// How the distribution is calculated from the net paycheck amount
    /// </summary>
    public enum DistributionType
    {
        /// <summary>
        /// The remaining amount of the payroll posting is send to the distribution
        /// </summary>
        Balance = 1,

        /// <summary>
        /// A given flat amount of the remaining paycheck is sent to the distribution i.e. $400 to savings
        /// </summary>
        FlatAmount = 2,

        /// <summary>
        /// A percentage of the remaining paycheck is sent to the distribution i.e. 25% to savings
        /// </summary>
        Percentage = 3
    }

    public class DistributionTypes
    {
        public static IEnumerable<DistributionType> Values()
        {
            yield return DistributionType.Balance;
            yield return DistributionType.FlatAmount;
            yield return DistributionType.Percentage;
        }
    }
}