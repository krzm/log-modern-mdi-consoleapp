using EFCore.Helper;
using Log.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class AppDatabase 
    : DIHelper.MicrosoftDI.MDIDependencySet
{
    public AppDatabase(
        IServiceCollection container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container.AddSingleton<LogContext>();

        Container.AddSingleton<IRepository<Category>, EFRepository<Category, LogContext>>();
        Container.AddSingleton<IRepository<Place>, EFRepository<Place, LogContext>>();
        Container.AddSingleton<IRepository<Data.Task>, EFRepository<Data.Task, LogContext>>();
        Container.AddSingleton<ILogRepo, LogRepo>();

        Container.AddSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}