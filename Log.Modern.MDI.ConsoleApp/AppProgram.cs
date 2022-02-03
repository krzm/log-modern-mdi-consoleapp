using CommandDotNet;
using CommandDotNet.Repl;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

[Command()]
public class AppProgram 
    : CommandDotNet.Helper.AppProgramMDI<AppProgram>
{
	private static bool inSession;

    [Subcommand()]
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