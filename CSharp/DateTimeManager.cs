using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class DateTimeManager
    {
        public DateTime GetDate(DateTime date, int count, Time time)
        {

            switch (time)
            {
                case Time.Day:
                    date = date.AddDays(count);
                    break;
                case Time.Week:
                    date = date.AddDays((count * 7));
                    break;
                case Time.Month:
                    date = date.AddMonths(count);
                    break;
                default:
                    //
                    break;
            }

            return date;


        }



        public void WeekOfYear(int year)
        {
            DateTime baseDate = new DateTime(year, 1, 1);
            DateTime countDate = new DateTime();
            DateTime endDate = new DateTime((year + 1), 1, 1);
            int i = 1;
            while (baseDate.DayOfWeek != DayOfWeek.Monday)
            {
                baseDate = baseDate.AddDays(1);
            }


            while (true)
            {
                if (countDate < endDate)
                {
                    countDate = baseDate.AddDays(6);
                    Console.WriteLine($"第{i}周：{baseDate.ToString("yyyy-MM-dd")}-{countDate.ToString("yyyy-MM-dd")}");
                    baseDate = countDate.AddDays(1);
                    i++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
