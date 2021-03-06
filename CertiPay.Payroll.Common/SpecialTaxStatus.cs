﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Applies a special tax status to an employee, company, earning, or other entity. Can be combined together
    /// i.e. SpecialTaxStatus.ExemptFromFICA | SpecialTaxStatus.ExemptFromStateTax
    /// </summary>
    [Flags]
    public enum SpecialTaxStatus : byte
    {
        /// <summary>
        /// Entity has no special tax considerations
        /// </summary>
        None = 0,

        /// <summary>
        /// Entity is exempt from paying Social Security taxes
        /// </summary>
        [Display(Name = "Exempt from Social Security")]
        ExemptFromSocialSecurity = 1 << 1,

        /// <summary>
        /// Entity is empt from paying medicare taxes
        /// </summary>
        [Display(Name = "Exempt from Medicare")]
        ExemptFromMedicare = 1 << 2,

        /// <summary>
        /// Entity is exempt from paying FICA taxes
        /// </summary>
        [Display(Name = "Exempt from FICA")]
        ExemptFromFICA = ExemptFromSocialSecurity | ExemptFromMedicare,

        /// <summary>
        /// Entity is exempt from paying federal taxes
        /// </summary>
        [Display(Name = "Exempt from Federal Taxes")]
        ExemptFromFederalTax = 1 << 3,

        /// <summary>
        /// Entity is exempt from paying state taxes
        /// </summary>
        [Display(Name = "Exempt from State Taxes")]
        ExemptFromStateTax = 1 << 4,

        /// <summary>
        /// Entity is exempt from paying local taxes
        /// </summary>
        [Display(Name = "Exempt from Local Taxes")]
        ExemptFromLocalTax = 1 << 5,

        /// <summary>
        /// Entity is exempt from paying FUTA tax (an employer-only tax)
        /// </summary>
        [Display(Name = "Exempt from Federal Unemployment Tax")]
        ExemptFromFUTA = 1 << 6,

        /// <summary>
        /// Entity is exempt from all taxes
        /// </summary>
        [Display(Name = "Non-Taxable")]
        NonTaxable = ExemptFromSocialSecurity | ExemptFromMedicare | ExemptFromFederalTax | ExemptFromStateTax | ExemptFromLocalTax | ExemptFromFUTA
    }

    public class SpecialTaxStatuses
    {
        /// <summary>
        /// Returns all of the special tax statuses configured
        /// </summary>
        public static IEnumerable<SpecialTaxStatus> Values()
        {
            yield return SpecialTaxStatus.None;
            yield return SpecialTaxStatus.ExemptFromFICA;
            yield return SpecialTaxStatus.ExemptFromSocialSecurity;
            yield return SpecialTaxStatus.ExemptFromMedicare;
            yield return SpecialTaxStatus.ExemptFromFederalTax;
            yield return SpecialTaxStatus.ExemptFromStateTax;
            yield return SpecialTaxStatus.ExemptFromLocalTax;
            yield return SpecialTaxStatus.ExemptFromFUTA;
            yield return SpecialTaxStatus.NonTaxable;
        }
    }
}