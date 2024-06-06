namespace DateInfo.Commands;

using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;

public class Shell : ICommand
{
    public void Execute(Action<string> writer, DateTime day, IWorkingDayCultureInfo cultureInfo)
    {
        if (day.IsWorkingDay(cultureInfo))
        {
            //UTF: \uf133
            writer("");
            return;
        }

        //UTF: \uf273
        writer("");
    }
}