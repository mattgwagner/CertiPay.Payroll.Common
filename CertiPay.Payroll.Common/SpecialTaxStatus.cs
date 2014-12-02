using System;
using System.Collections.Generic;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Applies a special tax status to an employee, company, earning, or other entity. Can be combined together
    /// i.e. SpecialTaxStatus.ExemptFromFICA | SpecialTaxStatus.ExemptFromMedicare
    /// </summary>
    [Flags]
    public enum SpecialTaxStatus : byte
    {
        // Note: This might need to get tweaked, since I'm not sure if we need to separate FICA from SS and Medicare?

        /// <summary>
        /// Entity has no special tax considerations
        /// </summary>
        None = 0,

        /// <summary>
        /// Entity is exempt from paying FICA taxes
        /// </summary>
        ExemptFromFICA = 1 << 1,

        /// <summary>
        /// Entity is exempt from paying Social Security taxes
        /// </summary>
        ExemptFromSocialSecurity = 1 << 2,

        /// <summary>
        /// Entity is empt from paying medicare taxes
        /// </summary>
        ExemptFromMedicare = 1 << 3,

        /// <summary>
        /// Entity is exempt from paying federal taxes
        /// </summary>
        ExemptFromFederalTax = 1 << 4,

        /// <summary>
        /// Entity is exempt from paying state taxes
        /// </summary>
        ExemptFromStateTax = 1 << 5,

        /// <summary>
        /// Entity is exempt from paying local taxes
        /// </summary>
        ExemptFromLocalTax = 1 << 6
    }

    public class SpecialTaxStatuses
    {
        public static IEnumerable<SpecialTaxStatus> Values()
        {
            yield return SpecialTaxStatus.None;
            yield return SpecialTaxStatus.ExemptFromFICA;
            yield return SpecialTaxStatus.ExemptFromSocialSecurity;
            yield return SpecialTaxStatus.ExemptFromMedicare;
            yield return SpecialTaxStatus.ExemptFromFederalTax;
            yield return SpecialTaxStatus.ExemptFromStateTax;
            yield return SpecialTaxStatus.ExemptFromLocalTax;
        }
    }
}