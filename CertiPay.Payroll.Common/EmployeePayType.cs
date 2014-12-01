using System.Collections.Generic;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Describes how an employee pay is calculated
    /// </summary>
    public enum EmployeePayType
    {
        /// <summary>
        /// Employee earns a set salary per period of time, i.e. $70,000 yearly
        /// </summary>
        Salary = 1,

        /// <summary>
        /// Employee earns a given amount per hour of work, i.e. $10 per hour
        /// </summary>
        Hourly = 2
    }

    public static class EmployeePayTypes
    {
        public static IEnumerable<EmployeePayType> Values()
        {
            yield return EmployeePayType.Salary;
            yield return EmployeePayType.Hourly;
        }
    }
}