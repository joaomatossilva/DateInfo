using System.CommandLine;
using DateInfo;

var c = new RootCommand();

var dayOption = new Option<string>("--day", "Day in YYYY-MM-DD format");

var localeOption = new Option<string>("--locale", "Locale for holidays. Example: pt-PT");

var daysUntilOffCommand = new Command("until", "Get the days until an off day");
daysUntilOffCommand.SetHandler((day, culture) => Commands.DaysUntilOff(WriteOutput, day, culture), new DayBinder(dayOption), new WorkingDayCultureInfoBinder(localeOption));
daysUntilOffCommand.AddOption(dayOption);
daysUntilOffCommand.AddOption(localeOption);
c.AddCommand(daysUntilOffCommand);

var todayCommand = new Command("today", "Some info about today");
todayCommand.SetHandler((day, culture) => Commands.Today(WriteOutput, day, culture), new DayBinder(dayOption), new WorkingDayCultureInfoBinder(localeOption));
todayCommand.AddOption(dayOption);
todayCommand.AddOption(localeOption);
c.AddCommand(todayCommand);

c.AddOption(dayOption);
c.AddOption(localeOption);

c.Invoke(args);

static void WriteOutput(string text)
{
    Console.WriteLine(text);
}