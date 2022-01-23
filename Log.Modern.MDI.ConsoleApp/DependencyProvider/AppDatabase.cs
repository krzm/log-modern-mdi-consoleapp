using Core;
using Core.Lib;
using Log.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class AppDatabase : MDIDependencyProvider
{
    public AppDatabase(
        IServiceCollection container) 
        : base(container)
    {
    }

    public override void RegisterDependencies()
    {
        Container.AddSingleton<LogContext>();

        Container.AddSingleton<IGenericRepository<Category>, EFGenericRepository<Category, LogContext>>();
        Container.AddSingleton<IGenericRepository<Place>, EFGenericRepository<Place, LogContext>>();
        Container.AddSingleton<IGenericRepository<Data.Task>, EFGenericRepository<Data.Task, LogContext>>();
        Container.AddSingleton<ILogRepo, LogRepo>();

        Container.AddSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}