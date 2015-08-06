using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Describes the type of employee working for the company.
    /// The Fair Labor Standards Act (FLSA) does not define full-time employment or part-time employment.
    /// This is a matter generally to be determined by the employer (US Department of Labor). The definition by
    /// employer can vary and is generally published in a company's Employee Handbook.
    /// </summary>
    public enum EmployeeType : byte
    {
        /// <summary>
        /// Companies commonly require from 30–35 or 40 hours per week to be defined as full-time and therefore eligible for benefits.
        /// </summary>
        [Display(Name = "Full Time")]
        FullTime = 1,

        /// <summary>
        /// A part-time job is a form of employment that carries fewer hours per week than a full-time job.
        /// Workers are considered to be part-time if they commonly work fewer than 30 or 35 hours per week.
        /// </summary>
        [Display(Name = "Part Time")]
        PartTime = 2,

        /// <summary>
        /// Worker is listed as a contract employee and does not receive benefits or tax considerations as employees do
        /// </summary>
        Contractor = 3
    }

    public static class EmployeeTypes
    {
        public static IEnumerable<EmployeeType> Values()
        {
            yield return EmployeeType.FullTime;
            yield return EmployeeType.PartTime;
            yield return EmployeeType.Contractor;
        }
    }
}