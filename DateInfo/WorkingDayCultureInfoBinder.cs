namespace DateInfo;

using System.CommandLine;
using System.CommandLine.Binding;
using DateTimeExtensions.WorkingDays;

public class WorkingDayCultureInfoBinder : BinderBase<IWorkingDayCultureInfo>
{
    private readonly Option<string> localeOption;

    public WorkingDayCultureInfoBinder(Option<string> localeOption)
    {
        this.localeOption = localeOption;
    }

    protected override IWorkingDayCultureInfo GetBoundValue(BindingContext bindingContext)
    {
        var localeName = bindingContext.ParseResult.GetValueForOption(localeOption);
        if (string.IsNullOrEmpty(localeName))
        {
            return new WorkingDayCultureInfo();
        }
        else
        {
            return new WorkingDayCultureInfo(localeName);
        }
    }
}