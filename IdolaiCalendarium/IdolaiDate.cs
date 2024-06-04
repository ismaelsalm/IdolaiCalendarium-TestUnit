using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdolaiCalendarium
{
    
    public class IdolaiDate
    {
        public int Year {get; private set; }
        public int Month {get; private set; }
        public int Day {get; private set;}

        public bool IsZarconianYear {get => IdolaiCalendar.IsZarconianYear(Year); }

        public IdolaiDate(){
            Year = 1;
            Month = 1;
            Day = 1;
        }
        public IdolaiDate(int year, int month, int day){         
            Year = year;
            Month = month;
            Day = day;
        }

        public override string ToString()
        {

            string leapObs = IsZarconianYear ? " It's a Zarconian year!" : "";
            return $"{Day}/{Month}/{Year}";
            
        }


        public IdolaiDate AddDays(int days){
            Day += days;
            while (Day > IdolaiCalendar.DaysInYear(Year))
            {
                Day -= IdolaiCalendar.DaysInYear(Year);
                Year++;
            }
            
            if(IdolaiCalendar.DaysPerMonth > Day){
                return this;
            }

            int months = Day / IdolaiCalendar.DaysPerMonth;
            Day %= IdolaiCalendar.DaysPerMonth;
            AddMonths(months);
            
            return this;
        }

        public IdolaiDate AddMonths(int months){
            Month += months;
            int numberOfMonths = IdolaiCalendar.NumberOfMonths(Year);
            while (Month > numberOfMonths)
            {
                Month -= numberOfMonths;
                Year++;
                numberOfMonths = IdolaiCalendar.NumberOfMonths(Year);
            }

            
            return this;
        }

        public IdolaiDate AddYears(int years){
            bool wasZarconian = IdolaiCalendar.IsZarconianYear(Year);
            Year += years;
            if(!wasZarconian && IdolaiCalendar.IsZarconianYear(Year)){
                return AddMonths(1);
            }
            return this;
        }

    }
}