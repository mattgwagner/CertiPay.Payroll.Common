using System.Collections.Generic;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Describes how an employee is configured to file taxes
    /// </summary>
    public enum EmployeeTaxFilingStatus
    {
        /// <summary>
        /// Employee is filing taxes without any dependents or a spouse
        /// </summary>
        Single = 1,

        /// <summary>
        /// Employee is filing taxes jointly with their spouse
        /// </summary>
        MarriedFilingJointly = 2,

        /// <summary>
        /// Employee is married but is filing at the higher single rate
        /// </summary>
        MarriedFilingSeparately = 3,

        /// <summary>
        /// Generally, you can claim head of household filing status on your tax return only if
        /// you are unmarried and pay more than 50% of the costs of keeping up a home for yourself and your
        /// dependent(s) or other qualifying individuals. See Pub. 501, Exemptions, Standard Deduction,
        /// and Filing Information, for information.
        /// </summary>
        HeadOfHousehold = 4,

        /// <summary>
        /// Employee is a widow(er) and has a dependent child
        /// </summary>
        WidowerWithDependentChild = 5
    }

    public static class TaxFilingStatuses
    {
        public static IEnumerable<EmployeeTaxFilingStatus> Values()
        {
            yield return EmployeeTaxFilingStatus.Single;
            yield return EmployeeTaxFilingStatus.MarriedFilingJointly;
            yield return EmployeeTaxFilingStatus.MarriedFilingSeparately;
            yield return EmployeeTaxFilingStatus.HeadOfHousehold;
            yield return EmployeeTaxFilingStatus.WidowerWithDependentChild;
        }
    }
}