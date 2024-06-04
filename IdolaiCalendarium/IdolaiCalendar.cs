using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdolaiCalendarium
{
    public static class IdolaiCalendar
    {
        public const int DaysPerMonth = 42;
        public const int MonthsPerYear = 16;
        public const int FirstZarconianYear = 4; 
        public const int ZarconianYearFrequency = 4;
        public const int IdolaiLeapExclusionInitYear = 1500, IdolaiLeapExclusionEndYear = 2000;

        public static bool IsZarconianYear(int Year){
            return (Year - FirstZarconianYear) % ZarconianYearFrequency == 0 && (Year < IdolaiLeapExclusionInitYear || Year > IdolaiLeapExclusionEndYear);
        }

        public static int NumberOfMonths(int year){
            return IsZarconianYear(year) ? MonthsPerYear + 1 : MonthsPerYear;
        }

        public static int DaysInYear(int year){
            int days = DaysPerMonth * MonthsPerYear;
            return IsZarconianYear(year) ? days + DaysPerMonth : days;
        } 

    }
}