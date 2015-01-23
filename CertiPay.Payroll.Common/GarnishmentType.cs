using System.Collections.Generic;
using System.ComponentModel;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Wage garnishment, the most common type of garnishment, is the process of deducting money from an employee's monetary compensation (including salary), sometimes
    /// as a result of a court order. Wage garnishments continue until the entire debt is paid or arrangements are made to pay off the debt. Garnishments can be taken
    /// for any type of debt but common examples of debt that result in garnishments include:
    /// child support, defaulted student loans, taxes, unpaid court fines
    /// When served on an employer, garnishments are taken as part of the payroll process. When processing payroll, sometimes there is not enough money in the employee's
    /// net pay to satisfy all of the garnishments. For example, in a case with federal tax, local tax, and credit card garnishments, the first garnishment taken would be the
    /// federal tax garnishments, then the local tax garnishments, and finally, garnishments for the credit card. Employers receive a notice telling them to withhold a certain
    /// amount of their employee's wages for payment and cannot refuse to garnish wages. Employers must correctly calculate the amount to withhold, and must make the deductions until the garnishment expires.
    /// (Source: Wikipedia)
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Garnishment"/>
    public enum GarnishmentType : byte
    {
        // Note: These are currently ordered in the order they should be applied, however there are many rules/guidelines around how to apply
        // garnishments, such as if a child support order was in place before an IRS Tax Levy, it stays in first...
        // so, best to just have another way of applying them in the correct order in each circumstance

        [Description("Unpaid Taxes")]
        UnpaidTaxes = 1,

        [Description("Child Support")]
        ChildSupport = 2,

        Bankruptcy = 3,

        Creditor = 4,

        [Description("Student Loans")]
        StudentLoans = 5
    }

    public class GarnishmentTypes
    {
        public static IEnumerable<GarnishmentType> Values()
        {
            yield return GarnishmentType.UnpaidTaxes;
            yield return GarnishmentType.ChildSupport;
            yield return GarnishmentType.Creditor;
            yield return GarnishmentType.Bankruptcy;
            yield return GarnishmentType.StudentLoans;
        }
    }
}