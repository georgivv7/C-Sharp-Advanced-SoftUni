using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static int CalculateDifference(string date, string secondDate)
        {
            DateTime date1 = DateTime.Parse(date); 
            DateTime date2 = DateTime.Parse(secondDate);

            TimeSpan difference = date1.Subtract(date2);
            return difference.Duration().Days;
        }
    }
}
