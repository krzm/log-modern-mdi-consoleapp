using CLI.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class MDIDependencyCollection : CLI.Core.Lib.MDIDependencyCollection
{
    public MDIDependencyCollection(
        IServiceCollection container) 
        : base(container) 
    {
    }

    protected override void RegisterDatabase()=> 
        RegisterDependencyProvider<AppDatabase>();

    protected override void RegisterConsoleOutput() => 
        RegisterDependencyProvider<AppOutput>();

    protected override void RegisterCommands() => 
        RegisterDependencyProvider<AppCommands>();

    protected override void RegisterProgram() => 
        Container.AddSingleton<IAppProgram, AppProgram>();
}