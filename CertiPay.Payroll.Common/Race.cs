using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Employers are required to attempt to allow employees to use self-identification to complete the EEO-1 report.
    /// If an employee declines to self-identify, employment records or observer identification may be used.
    ///
    /// Where records are maintained, it is recommended that they be kept separately from the employees basic personnel
    /// file or other records available to those responsible for personnel decisions.
    ///
    /// Race and ethnic designations as used by the Equal Employment Opportunity Commission do not denote scientific definitions
    /// of anthropological origins.
    /// </summary>
    public enum Race : byte
    {
        [Display(Name = "Not Specified")]
        NotSpecified = 0,

        //Hispanic or Latino - A person of Cuban, Mexican, Puerto Rican, South or Central American, or other Spanish culture or origin regardless of race.
        [Display(Name = "Hispanic or Latino")]
        HispanicOrLatino = 1,

        //White (Not Hispanic or Latino) - A person having origins in any of the original peoples of Europe, the Middle East, or North Africa.
        [Display(Name = "White (Not Hispanic or Latino)")]
        White = 2,

        //Black or African American (Not Hispanic or Latino) - A person having origins in any of the black racial groups of Africa.
        [Display(Name = "Black or African American (Not Hispanic or Latino)")]
        BlackOrAfricanAmerican = 3,

        //Native Hawaiian or Other Pacific Islander (Not Hispanic or Latino) - A person having origins in any of the peoples of Hawaii, Guam, Samoa, or other Pacific Islands.
        [Display(Name = "Native Hawaiian or Other Pacific Islander (Not Hispanic or Latino)")]
        NativeHawaiianOrPacificIslander = 4,

        //Asian (Not Hispanic or Latino) - A person having origins in any of the original peoples of the Far East, Southeast Asia, or the Indian Subcontinent, including, for example, Cambodia, China, India, Japan, Korea, Malaysia, Pakistan, the Philippine Islands, Thailand, and Vietnam.
        [Display(Name = "Asian (Not Hispanic or Latino)")]
        Asian = 5,

        //American Indian or Alaska Native (Not Hispanic or Latino) - A person having origins in any of the original peoples of North and South America (including Central America), and who maintain tribal affiliation or community attachment.
        [Display(Name = "American Indian or Alaska Native (Not Hispanic or Latino)")]
        AmericanIndianOrAlaskaNative = 6,

        //Two or More Races (Not Hispanic or Latino) - All persons who identify with more than one of the above five races.
        [Display(Name = "Two or More Races (Not Hispanic or Latino)")]
        TwoOrMoreRaces = 7
    }

    public static class Races
    {
        public static IEnumerable<Race> Values()
        {
            yield return Race.NotSpecified;
            yield return Race.HispanicOrLatino;
            yield return Race.White;
            yield return Race.BlackOrAfricanAmerican;
            yield return Race.NativeHawaiianOrPacificIslander;
            yield return Race.Asian;
            yield return Race.AmericanIndianOrAlaskaNative;
            yield return Race.TwoOrMoreRaces;
        }
    }
}