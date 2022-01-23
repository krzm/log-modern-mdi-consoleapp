using CLI.Core.Lib;
using Core.Lib;
using Log.Modern.Lib;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class AppCommands : MDIDependencyProvider
{
    public AppCommands(
        IServiceCollection container) 
        : base(container)
    {
    }

    public override void RegisterDependencies()
    {
        Container.AddSingleton<IReadCommand<LogArgFilter>, LogReadCommand>();
    }
}