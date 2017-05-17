using System;

namespace GreenGoblin.WindowsForm
{
    public static class DateTimeExtensions
    {
        public static bool IsMaxDateTime(this DateTime dateTime)
        {
            if (dateTime.Year > 9000)
            {
                return true;
            }
            return false;

            //if (DateTime.MaxValue - dateTime < TimeSpan.FromSeconds(0))
            //{
            //    return true;
            //}
            //return false;
        }
    }
}