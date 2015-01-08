using System.Collections.Generic;
using System.ComponentModel;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// A configured garnishment, or involuntary, ordered deduction from an employee's pay for things such
    /// as unpaid taxes, child support, or bankruptcy
    /// </summary>
    public enum GarnishmentType
    {
        [Description("Child Support")]
        ChildSupport = 1,

        [Description("Unpaid Taxes")]
        UnpaidTaxes = 2,

        Creditor = 3,

        Bankruptcy = 4,

        [Description("Student Loans")]
        StudentLoans = 5
    }

    public class GarnishmentTypes
    {
        public static IEnumerable<GarnishmentType> Values()
        {
            yield return GarnishmentType.ChildSupport;
            yield return GarnishmentType.UnpaidTaxes;
            yield return GarnishmentType.Creditor;
            yield return GarnishmentType.Bankruptcy;
            yield return GarnishmentType.StudentLoans;
        }
    }
}