namespace DateInfo.Commands;

using DateTimeExtensions.WorkingDays;

public class ListHolidays : ICommand
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
            writer($"{holiday.Observance:d} - {holiday.Holiday.Name}");
        }
    }
}