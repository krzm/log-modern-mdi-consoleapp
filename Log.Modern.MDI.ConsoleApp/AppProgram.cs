using CommandDotNet;
using CommandDotNet.Repl;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

[Command(
    ExtendedHelpTextLines  = new string[] {
    "Directives:"
    , "  [debug] to attach a debugger to the app"
    , "  [parse] to output how the inputs were tokenized"
    , "  [log] to output framework logs to the console"
    , "  [log:debug|info|warn|error|fatal] to output framework logs for the given level or above"
    , "directives must be specified before any commands and arguments"
    , "Example: %AppName% [debug] [parse] [log:info] math" })]
public class AppProgram : Console.Modern.Lib.AppProgramMDI<AppProgram>
{
	private static bool inSession;

    [Subcommand]
    public LogModelCommands? LogModel { get; set; }
    
    public AppProgram(
        IServiceCollection services) 
            : base(services)
    {
    }

    [DefaultCommand()]
    public void StartSession(
        CommandContext context,
        ReplSession replSession)
    {
        if (inSession == false)
        {
            context.Console.WriteLine("start session");
            inSession = true;
            replSession.Start();
        }
        else
        {
            context.Console.WriteLine($"no session {inSession}");
            context.ShowHelpOnExit = true;
        }
    }
}