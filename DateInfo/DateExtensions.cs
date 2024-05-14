namespace DateInfo;

using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;

public static class DateExtensions
{
    public static int CalculateDaysUntilOff(this DateTime day, IWorkingDayCultureInfo cultureInfo)
    {
        int days = 0;
        while (day.IsWorkingDay(cultureInfo))
        {
            days++;
            day = day.AddDays(1);
        }

        return days;
    }
}