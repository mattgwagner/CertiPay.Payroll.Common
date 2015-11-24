using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Provides a reference list of holidays observed by the Federal Reserve System
    /// </summary>
    public sealed class BankHolidays
    {
        //When a federal holiday falls on a Saturday, it is usually observed on the preceding Friday.
        //When the holiday falls on a Sunday, it is usually observed on the following Monday.

        //There are ten annual U.S.federal holidays on the calendar designated by the United States Congress.
        //Unlike many other countries, there are no ‘national holidays’ in the United States because
        //Congress only has authority to create holidays for federal institutions.

        //Most federal holidays are also observed as state holidays.

        //​Though not technically accurate, U.S.federal holidays are often referred to as
        //‘public holidays’ or ‘legal holidays’ because of their wide spread observance.

        //Bank holidays are usually the same as federal holidays since most banks follow
        //the holiday calendar of the U.S.Federal Reserve. They tend to use the modern
        //President’s Day for the observance of George Washington’s Birthday.

        private static readonly DateTime StartDate = DateTime.Parse("1/1/2015");

        private static readonly DateTime StopDate = DateTime.Parse("12/31/2020");

        /// <summary>
        /// Returns holidays observed after the given date
        /// </summary>
        public static IEnumerable<Holiday> After(DateTime after)
        {
            return Values.Where(_ => _.Date > after);
        }

        /// <summary>
        /// Returns a list of all holidays in the system through the programmed stop date (12/31/2020)
        /// </summary>
        public static IEnumerable<Holiday> Values
        {
            get
            {
                return new[]
                {
                    NewYearsDay,
                    MartinLutherKingDay,
                    GeorgeWashingtonsBirthday,
                    MemorialDay,
                    IndependenceDay,
                    LaborDay,
                    ColumbusDay,
                    VeteransDay,
                    ThanksgivingDay,
                    ChristmasDay
                }
                .SelectMany(_ => _)
                .OrderBy(_ => _.Date)
                .ToArray();
            }
        }

        /// <summary>
        /// Represents a single federal holiday in time
        /// </summary>
        public class Holiday
        {
            /// <summary>
            /// The date of the actual holiday (NOT THE OBSERVED DATE)
            /// </summary>
            public DateTime Date { get; internal set; }

            /// <summary>
            /// The name describing the holiday
            /// </summary>
            public String Description { get; internal set; }

            /// <summary>
            /// The date that the holiday will be observed
            /// (i.e. some federal holidays are moved to week days)
            /// </summary>
            public DateTime ObservedOn { get; internal set; }

            internal Holiday(String description, DateTime date, DateTime? observedOn = null)
            {
                this.Description = description;
                this.Date = date;
                this.ObservedOn = observedOn ?? date;
            }
        }

        private static IEnumerable<Holiday> NewYearsDay
        {
            get
            {
                // Observed: to weekday if weekend

                String description = "New Year's Day";

                yield return new Holiday(description, new DateTime(2015, (int)Month.January, 1));
                yield return new Holiday(description, new DateTime(2016, (int)Month.January, 1));
                yield return new Holiday(description, new DateTime(2017, (int)Month.January, 1), new DateTime(2017, (int)Month.January, 2));
                yield return new Holiday(description, new DateTime(2018, (int)Month.January, 1));
                yield return new Holiday(description, new DateTime(2019, (int)Month.January, 1));
                yield return new Holiday(description, new DateTime(2020, (int)Month.January, 1));
            }
        }

        private static IEnumerable<Holiday> MartinLutherKingDay
        {
            get
            {
                // Third Monday in January

                String description = "Martin Luther King, Jr.'s Day";

                yield return new Holiday(description, new DateTime(2015, (int)Month.January, 19));
                yield return new Holiday(description, new DateTime(2016, (int)Month.January, 18));
                yield return new Holiday(description, new DateTime(2017, (int)Month.January, 16));
                yield return new Holiday(description, new DateTime(2018, (int)Month.January, 15));
                yield return new Holiday(description, new DateTime(2019, (int)Month.January, 21));
                yield return new Holiday(description, new DateTime(2020, (int)Month.January, 20));
            }
        }

        private static IEnumerable<Holiday> GeorgeWashingtonsBirthday
        {
            get
            {
                // Third Monday in Feburary

                String description = "Washington's Birthday";

                yield return new Holiday(description, new DateTime(2015, (int)Month.February, 16));
                yield return new Holiday(description, new DateTime(2016, (int)Month.February, 15));
                yield return new Holiday(description, new DateTime(2017, (int)Month.February, 20));
                yield return new Holiday(description, new DateTime(2018, (int)Month.February, 19));
                yield return new Holiday(description, new DateTime(2019, (int)Month.February, 17));
                yield return new Holiday(description, new DateTime(2020, (int)Month.February, 18));
            }
        }

        private static IEnumerable<Holiday> MemorialDay
        {
            get
            {
                // Last Monday in May

                String description = "Memorial Day";

                yield return new Holiday(description, new DateTime(2015, (int)Month.May, 25));
                yield return new Holiday(description, new DateTime(2016, (int)Month.May, 30));
                yield return new Holiday(description, new DateTime(2017, (int)Month.May, 29));
                yield return new Holiday(description, new DateTime(2018, (int)Month.May, 28));
                yield return new Holiday(description, new DateTime(2019, (int)Month.May, 27));
                yield return new Holiday(description, new DateTime(2020, (int)Month.May, 25));
            }
        }

        private static IEnumerable<Holiday> IndependenceDay
        {
            get
            {
                // Observed: to monday if sunday

                String description = "Independence Day";

                yield return new Holiday(description, new DateTime(2015, (int)Month.July, 4), new DateTime(2015, (int)Month.July, 3));
                yield return new Holiday(description, new DateTime(2016, (int)Month.July, 4));
                yield return new Holiday(description, new DateTime(2017, (int)Month.July, 4));
                yield return new Holiday(description, new DateTime(2018, (int)Month.July, 4));
                yield return new Holiday(description, new DateTime(2019, (int)Month.July, 4));
                yield return new Holiday(description, new DateTime(2020, (int)Month.July, 4), new DateTime(2020, (int)Month.July, 3));
            }
        }

        private static IEnumerable<Holiday> LaborDay
        {
            get
            {
                // Third Monday in September

                String description = "Labor Day";

                yield return new Holiday(description, new DateTime(2015, (int)Month.September, 7));
                yield return new Holiday(description, new DateTime(2016, (int)Month.September, 5));
                yield return new Holiday(description, new DateTime(2017, (int)Month.September, 4));
                yield return new Holiday(description, new DateTime(2018, (int)Month.September, 3));
                yield return new Holiday(description, new DateTime(2019, (int)Month.September, 2));
                yield return new Holiday(description, new DateTime(2020, (int)Month.September, 7));
            }
        }

        private static IEnumerable<Holiday> ColumbusDay
        {
            get
            {
                // Second Monday in October

                String description = "Columbus Day";

                yield return new Holiday(description, new DateTime(2015, (int)Month.October, 12));
                yield return new Holiday(description, new DateTime(2016, (int)Month.October, 10));
                yield return new Holiday(description, new DateTime(2017, (int)Month.October, 9));
                yield return new Holiday(description, new DateTime(2018, (int)Month.October, 8));
                yield return new Holiday(description, new DateTime(2019, (int)Month.October, 14));
                yield return new Holiday(description, new DateTime(2020, (int)Month.October, 12));
            }
        }

        private static IEnumerable<Holiday> VeteransDay
        {
            get
            {
                // Observed: to weekday if weekend

                String description = "Veterans Day";

                yield return new Holiday(description, new DateTime(2015, (int)Month.November, 11));
                yield return new Holiday(description, new DateTime(2016, (int)Month.November, 11));
                yield return new Holiday(description, new DateTime(2017, (int)Month.November, 11), new DateTime(2017, (int)Month.November, 10));
                yield return new Holiday(description, new DateTime(2018, (int)Month.November, 11), new DateTime(2018, (int)Month.November, 12));
                yield return new Holiday(description, new DateTime(2019, (int)Month.November, 11));
                yield return new Holiday(description, new DateTime(2020, (int)Month.November, 11));
            }
        }

        private static IEnumerable<Holiday> ThanksgivingDay
        {
            get
            {
                // 4th Thursday in November

                String description = "Thanksgiving Day";

                yield return new Holiday(description, new DateTime(2015, (int)Month.November, 26));
                yield return new Holiday(description, new DateTime(2016, (int)Month.November, 24));
                yield return new Holiday(description, new DateTime(2017, (int)Month.November, 23));
                yield return new Holiday(description, new DateTime(2018, (int)Month.November, 22));
                yield return new Holiday(description, new DateTime(2019, (int)Month.November, 28));
                yield return new Holiday(description, new DateTime(2020, (int)Month.November, 26));
            }
        }

        private static IEnumerable<Holiday> ChristmasDay
        {
            get
            {
                // Observed: to weekday if weekend

                String description = "Christmas Day";

                yield return new Holiday(description, new DateTime(2015, (int)Month.December, 25));
                yield return new Holiday(description, new DateTime(2016, (int)Month.December, 25), new DateTime(2016, (int)Month.December, 26));
                yield return new Holiday(description, new DateTime(2017, (int)Month.December, 25));
                yield return new Holiday(description, new DateTime(2018, (int)Month.December, 25));
                yield return new Holiday(description, new DateTime(2019, (int)Month.December, 25));
                yield return new Holiday(description, new DateTime(2020, (int)Month.December, 25));
            }
        }
    }
}