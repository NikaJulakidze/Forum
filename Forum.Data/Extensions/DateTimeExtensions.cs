using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Forum.Data.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetDayOfWeek(this DateTime timeNow, DayOfWeek Monday)
        {
            var aaa = timeNow.DayOfWeek - Monday;
            var diff = (7 + (timeNow.DayOfWeek - Monday)) % 7;
            return timeNow.AddDays(-1 * diff).Date;
        }
    }
}
