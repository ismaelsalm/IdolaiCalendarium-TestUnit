using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using IdolaiCalendarium;

namespace IdolaiCalendariumTest
{


    public class IdolaiDateTest
    {
        public static IEnumerable<object[]> AddDaysParms()
        {
            //Add a Day
            yield return new object[]{
                new IdolaiDate(),
                1,
                new IdolaiDate(1, 1, 2)
            };
            //Add a month
            yield return new object[]{
                new IdolaiDate(),
                42,
                new IdolaiDate(1, 2, 1)
            };
            //Add a year
            yield return new object[]{
                new IdolaiDate(),
                672,
                new IdolaiDate(2, 1, 1)
            };
            //Add 4 years + 16 months (zarconian year)
            yield return new object[]{
                new IdolaiDate(),
                672 * 4,
                new IdolaiDate(4, 17, 1)
            };
        }

        [Theory]
        [MemberData(nameof(AddDaysParms))]
        public static void AfterAddDays_DateShouldBeThis(IdolaiDate inDate, int daysToAdd, IdolaiDate expectedDate)
        {
            IdolaiDate date = inDate.AddDays(daysToAdd);
            Assert.Equal(expectedDate.ToString(), date.ToString());
        }

        public static IEnumerable<object[]> AddMonthParms()
        {
            //Add a month
            yield return new object[]{
                new IdolaiDate(),
                1,
                new IdolaiDate(1, 2, 1)
            };
            //Add a year
            yield return new object[]{
                new IdolaiDate(),
                16,
                new IdolaiDate(2, 1, 1)
            };
            //Add 4 years + 16 months
            yield return new object[]{
                new IdolaiDate(),                
                16 * 4,
                new IdolaiDate(4, 17, 1)
            };

        }

        [Theory]
        [MemberData(nameof(AddMonthParms))]
        public static void AfterAddMonths_DateShouldBeThis(IdolaiDate inDate, int monthsToAdd, IdolaiDate expectedDate)
        {
            IdolaiDate date = inDate.AddMonths(monthsToAdd);
            Assert.Equal(expectedDate.ToString(), date.ToString());
        }
        public static IEnumerable<object[]> AddYearParms()
        {
            //Add a Year
            yield return new object[]{
                new IdolaiDate(),
                1,
                new IdolaiDate(2, 1, 1)
            };
            //Add 4 years
            yield return new object[]{
                new IdolaiDate(),
                4,
                new IdolaiDate(5, 1, 1)
            };
            //Add 100 years
            yield return new object[]{
                new IdolaiDate(),                
                100,
                new IdolaiDate(101, 1, 1)
            };

        }

        [Theory]
        [MemberData(nameof(AddYearParms))]
        public static void AfterAddYears_DateShouldBeThis(IdolaiDate inDate, int yearsToAdd, IdolaiDate expectedDate)
        {
            IdolaiDate date = inDate.AddYears(yearsToAdd);
            Assert.Equal(expectedDate.ToString(), date.ToString());
        }
    }
}