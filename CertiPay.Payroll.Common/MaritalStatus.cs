using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    public enum MaritalStatus : byte
    {
        //A person's marital status indicates whether the person is married. Questions about marital status appear on many polls and forms, including censuses.
        //The question has historically also appeared in job applications and credit card applications and similar contexts, though the practice is increasing
        //regarded as anachronistic,[citation needed] as an answer would normally not be relevant to the consideration of the merits of an application and may in
        //fact be considered unlawful discrimination in some countries.

        //In the simplest sense, the only possible answers are "married" or "single". Some unmarried people object to describing themselves by a simplistic term
        //"single", and often other options are given, such as "divorced", "widowed", widow or widower, "cohabiting", "civil union", "domestic partnership" and
        //"unmarried partners". In some cases, knowing that people are divorced, widowed, or in a relationship is more useful than simply knowing that they are unmarried.
        //The category of "married" would also cover the situation of the person being "separated". In many cases, people who are in a committed co-habiting relationship
        //may describe themselves as married, and some laws (such as taxation laws) require them to do so.

        [Display(Name = "Not Specified")]
        NotSpecified = 0,

        Single = 1,

        Married = 2,

        // Divorced = 3

        // Widowed = 4
    }

    public static class MaritalStatuses
    {
        public static IEnumerable<MaritalStatus> Values()
        {
            yield return MaritalStatus.NotSpecified;
            yield return MaritalStatus.Single;
            yield return MaritalStatus.Married;
        }
    }
}