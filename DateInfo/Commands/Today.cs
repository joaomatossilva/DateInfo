namespace DateInfo.Commands;

using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;

public class Today : ICommand
{
    public void Execute(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo)
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

        var daysUntilOff = day.CalculateDaysUntilOff(cultureInfo);
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
}