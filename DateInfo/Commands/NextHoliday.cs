namespace DateInfo.Commands;

using DateTimeExtensions.WorkingDays;

public class NextHoliday : ICommand
{
    public void Execute(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo)
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
}