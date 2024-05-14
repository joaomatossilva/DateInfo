namespace DateInfo.Commands;

using DateTimeExtensions.WorkingDays;

public interface ICommand
{
    void Execute(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo);
}