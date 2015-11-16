namespace E01_DayOfWeekService
{
    using System;
    using System.Globalization;

    public class GetDayService : IGetDayService
    {
        public string GetDateBul(DateTime date)
        {
            var culture = new CultureInfo("bg-BG");

            return culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
        }
    }
}
