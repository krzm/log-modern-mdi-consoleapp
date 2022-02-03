using CommandDotNet;
using CRUDCommandHelper;
using Log.Modern.Lib;

namespace Log.Modern.MDI.ConsoleApp;

[Command("log")]
public class LogModelCommands
{
    private const string DateFormat = "dd.MM.yyyy";
    private readonly IReadCommand<LogArgFilter> logReadCommand;

    public LogModelCommands(
        IReadCommand<LogArgFilter> logReadCommand)
    {
        this.logReadCommand = logReadCommand;
    }

    [DefaultCommand]
    public void Read(
        [Operand(
            "date"
            , Description = $"Optional date in format {DateFormat}"
        )]  
        DateTime? date)
    {
        logReadCommand.Read(new LogArgFilter(){ Start = date });
    }
}