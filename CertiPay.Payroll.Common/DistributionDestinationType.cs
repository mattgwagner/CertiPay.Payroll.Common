using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// How a distribution for payroll will reach the employee
    /// </summary>
    public enum DistributionDestinationType : byte
    {
        /// <summary>
        /// Direct deposit to the employee's account
        /// </summary>
        [Display(Name = "Direct Deposit")]
        DirectDeposit = 1,

        /// <summary>
        /// A physically printed check
        /// </summary>
        Check = 2,

        /// <summary>
        /// Deposit to the employee's pay card
        /// </summary>
        PayCard = 3,
    }

    public class DistributionDestinationTypes
    {
        public static IEnumerable<DistributionDestinationType> Values()
        {
            foreach (var type in Enum.GetValues(typeof(DistributionDestinationType)))
            {
                yield return (DistributionDestinationType)type;
            }
        }
    }
}