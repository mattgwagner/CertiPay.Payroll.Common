using System.Collections.Generic;
using System.ComponentModel;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// How to handle when routine payroll schedules fall on a weekend day
    /// </summary>
    public enum PayrollScheduleWeekendPolicy : byte
    {
        /// <summary>
        /// Pay on the business day preceeding the weekend
        /// </summary>
        [Description("Prior Business Day")]
        PriorBusinessDay = 1,

        /// <summary>
        /// Pay on the next business day following the weekend
        /// </summary>
        [Description("Next Business Day")]
        NextBusinessDay = 2,

        /// <summary>
        /// Pay date should be adjusted to the nearest business day, i.e. if payday falls on a Saturday,
        /// pay on Friday. If it falls on a Sunday, pay on Monday.
        /// </summary>
        [Description("Nearest Business Day")]
        NearestBusinessDay = 3
    }

    public class PayrollScheduleWeekendPolicies
    {
        public static IEnumerable<PayrollScheduleWeekendPolicy> Values()
        {
            yield return PayrollScheduleWeekendPolicy.PriorBusinessDay;
            yield return PayrollScheduleWeekendPolicy.NextBusinessDay;
            yield return PayrollScheduleWeekendPolicy.NearestBusinessDay;
        }

        // Note: I was going to add a calculate extension method here, but business days all depend on the configured calendar and any holidays.
    }
}