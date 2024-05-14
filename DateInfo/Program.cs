using System.CommandLine;
using DateInfo;
using DateInfo.Commands;

var c = new RootCommand();

var dayOption = new Option<string>("--day", "Day in YYYY-MM-DD format");
var localeOption = new Option<string>("--locale", "Locale for holidays. Example: pt-PT");

/* -- still unsure on this
var daysUntilOffCommand = new Command("until", "Get the days until an off day");
daysUntilOffCommand.SetHandler((day, culture) => Commands.DaysUntilOff(WriteOutput, day, culture), new DayBinder(dayOption), new WorkingDayCultureInfoBinder(localeOption));
daysUntilOffCommand.AddOption(dayOption);
daysUntilOffCommand.AddOption(localeOption);
c.AddCommand(daysUntilOffCommand);
*/

var todayCommand = AddCommand("today", "Some info about today", new Today(), dayOption, localeOption);
c.AddCommand(todayCommand);

var nextCommand = AddCommand("next", "Show the next holiday of the current year", new NextHoliday(), dayOption, localeOption);
c.AddCommand(nextCommand);

var listCommand = AddCommand("list", "Show all holidays from current year", new ListHolidays(), dayOption, localeOption);
c.AddCommand(listCommand);

c.AddOption(dayOption);
c.AddOption(localeOption);

c.Invoke(args);
return;

// to be reworked
static void WriteOutput(string text)
{
    Console.WriteLine(text);
}

static Command AddCommand(string name, string description, ICommand commandHandler, Option<string> dayOption, Option<string> localeOption)
{
    var command = new Command(name, description);
    command.SetHandler((day, culture) => commandHandler.Execute(WriteOutput, day, culture), new DayBinder(dayOption), new WorkingDayCultureInfoBinder(localeOption));
    command.AddOption(dayOption);
    command.AddOption(localeOption);
    return command;
}