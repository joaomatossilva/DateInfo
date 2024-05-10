namespace DateInfo;

using System.CommandLine;
using System.CommandLine.Binding;
using System.Globalization;

public class DayBinder : BinderBase<DateTime>
{
    private readonly Option<string> dayOption;

    public DayBinder(Option<string> dayOption)
    {
        this.dayOption = dayOption;
    }

    protected override DateTime GetBoundValue(BindingContext bindingContext)
    {
        var dayString = bindingContext.ParseResult.GetValueForOption(dayOption);
        if (string.IsNullOrEmpty(dayString))
        {
            return DateTime.Today;
        }

        if (DateTime.TryParseExact(dayString, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime day))
        {
            return day;
        }

        throw new FormatException("Day was non in a valid format");
    }
}