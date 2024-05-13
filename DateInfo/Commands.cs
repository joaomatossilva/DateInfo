namespace DateInfo;

using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;

public static class Commands
{
    public static void ListHolidays(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo)
    {
        var holidays = cultureInfo.GetHolidaysOfYear(day.Year).Select(x => new
                {
                    Holiday = x,
                    Observance = x.GetInstance(day.Year)
                })
            .OrderBy(x => x.Observance);
        foreach (var holiday in holidays)
        {
            writer($"{holiday.Observance:d} - {holiday.Holiday.Name}");
        }
    }

    public static void NextHoliday(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo)
    {

        var holidays = cultureInfo.GetHolidaysOfYear(day.Year).Select(x => new
                {
                    Holiday = x,
                    Observance = x.GetInstance(day.Year)
                })
            .OrderBy(x => x.Observance);

        foreach (var holiday in holidays)
        {
            if(holiday.Observance > day)
            {
                writer($"Next holiday is {holiday.Holiday.Name} on {holiday.Observance:d}");
                return;
            }
        }

        writer("There aren't more holidays this year");
    }

    public static void DaysUntilOff(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo)
    {
        var days = CalculateDaysUntilOff(day, cultureInfo);
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
            writer($"It's {day.DayOfWeek}. Enjoy some rest.");
            return;
        }

        var daysUntilOff = CalculateDaysUntilOff(day, cultureInfo);
        switch (daysUntilOff)
        {
            case 6:
                writer("It's a long week, full of opportunities!");
                return;
            case 5:
                writer("Beginning of a new week, make it count!");
                return;
            case 4:
                writer("Still some way to go, keep it up!");
                return;
            case 3:
                writer("You're half way there.");
                return;
            case 2:
                writer("It's almost time to rest.");
                return;
            case 1:
                writer("The last mile. Bring it home!");
                return;
        }
    }

    private static int CalculateDaysUntilOff(DateTime day, IWorkingDayCultureInfo cultureInfo)
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