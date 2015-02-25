using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    public enum Gender : byte
    {
        [Display(Name = "Not Specified")]
        NotSpecified = 0,

        Male = 1,

        Female = 2
    }

    public static class Genders
    {
        public static IEnumerable<Gender> Values()
        {
            yield return Gender.NotSpecified;
            yield return Gender.Male;
            yield return Gender.Female;
        }
    }
}