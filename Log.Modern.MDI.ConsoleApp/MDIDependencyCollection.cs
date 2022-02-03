using DIHelper;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class MDIDependencySuite
    : DIHelper.MicrosoftDI.MDIDependencySuite
{
    public MDIDependencySuite(
        IServiceCollection container) 
        : base(container) 
    {
    }

    protected override void RegisterDatabase()=> 
        RegisterSet<AppDatabase>();

    protected override void RegisterConsoleOutput() => 
        RegisterSet<AppOutput>();

    protected override void RegisterCommands() => 
        RegisterSet<AppCommands>();

    protected override void RegisterProgram() => 
        Container.AddSingleton<IAppProgram, AppProgram>();
}