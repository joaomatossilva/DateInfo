namespace DateInfo;

using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;

public static class Commands
{
    public static void DaysUntilOff(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo)
    {
        int days = 0;
        while (day.IsWorkingDay(cultureInfo))
        {
            days++;
            day = day.AddDays(1);
        }

        if (days > 0)
        {
            writer($"{days} more days until off");
            return;
        }
        else
        {
            writer("It's your off day. Enjoy it!");
            return;
        }
    }

    public static void Today(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo)
    {
        if (day.IsHoliday(cultureInfo))
        {
            //Should have a better way to get this holiday
            var holidays = cultureInfo.GetHolidaysOfYear(day.Year);
            var holiday = holidays.First(x => x.IsInstanceOf(day));
            writer($"Today is {holiday.Name}");
            return;
        }

        if (!day.IsWorkingDay(cultureInfo))
        {
            writer($"It's {day.DayOfWeek}. Have some rest.");
            return;
        }

        writer($"It's a normal {day.DayOfWeek}");
        return;
    }
}