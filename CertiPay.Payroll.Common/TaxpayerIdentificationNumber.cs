using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    public class TaxpayerIdentificationNumber
    {
        [StringLength(9)]
        [Display(Name = "Taxpayer Identification Number")]
        public String Value { get; set; }

        public TINType Type { get; set; }

        // TODO Should this be a property of the TIN, or have a TIN Types of AppliedFor, Unavailable, etc.?
        // public Boolean IsVerified { get; set; }

        public override string ToString()
        {
            String val = Value.PadLeft(9, '0');

            switch (this.Type)
            {
                case TINType.SSN:
                case TINType.ITIN:
                    return String.Format("{0} ({1})", val.Insert(3, "-").Insert(6, "-"), Type);

                case TINType.EIN:
                    return String.Format("{0} ({1})", val.Insert(2, "-"), Type);

                default:
                    return String.Format("{0} ({1})", Value, "Unknown");
            }
        }

        public enum TINType : byte
        {
            [Description("Social Security Number")]
            SSN = 1,

            /// <summary>
            /// An Employer Identification Number (EIN) is also known as a federal tax identification number, and is used to identify a business entity.
            /// </summary>
            [Description("Employer Identification Number")]
            EIN = 2,

            /// <summary>
            /// An ITIN, or Individual Taxpayer Identification Number, is a tax processing number only available for
            /// certain nonresident and resident aliens, their spouses, and dependents who cannot get a Social Security Number (SSN).
            /// It is a 9-digit number, beginning with the number "9", formatted like an SSN (NNN-NN-NNNN).
            /// </summary>
            [Description("Individual Taxpayer Identification Number")]
            ITIN = 3

            // ATIN - Taxpayer Identification Number for Pending U.S. Adoptions -- Will never be used, but is here for reference

            // PTIN - Preparer Taxpayer Identification Number -- Should probably not be used, is here for reference
        }

        public static IEnumerable<TINType> Values
        {
            get
            {
                yield return TINType.SSN;
                yield return TINType.EIN;
                yield return TINType.ITIN;
            }
        }
    }
}