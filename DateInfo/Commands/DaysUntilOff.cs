namespace DateInfo.Commands;

using DateTimeExtensions.WorkingDays;

public class DaysUntilOff : ICommand
{
    public void Execute(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo)
    {
        var days = day.CalculateDaysUntilOff(cultureInfo);
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
}