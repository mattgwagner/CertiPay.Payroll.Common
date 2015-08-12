namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// The Fair Labor Standards Act uses the terms exempt and nonexempt to describe work that is included (nonexempt)
    /// or not included (exempt) in the Act’s overtime and record-keeping provisions. The Act requires that overtime (payment
    /// for hours worked in excess of 40 hours in one week) be paid to employees performing nonexempt work. The Act exempts,
    ///  or does not require, that time and one half be paid to employees performing exempt work.
    /// </summary>
    public enum FLSAStatus : byte
    {
        /// <summary>
        /// Employee is allowed to earn overtime for performing the work in excess of 40 hours in one week
        /// </summary>
        Nonexempt = 0,

        /// <summary>
        /// Employee is not allowed or exempt from earning overtime for performing work in excess of 40 hours in one week
        /// </summary>
        Exempt = 1
    }
}