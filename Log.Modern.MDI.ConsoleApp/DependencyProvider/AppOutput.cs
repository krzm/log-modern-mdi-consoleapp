using DataToTable;
using Log.Data;
using Log.Modern.Lib;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class AppOutput : CLI.Core.Lib.MDI.AppOutput
{
    public AppOutput(
        IServiceCollection container) 
            : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container.AddSingleton<IColumnCalculator<LogModel>, ColumnCalculator<LogModel>>();
    }
    
    protected override void RegisterTableProviders()
    {
        Container.AddSingleton<IDataToText<LogModel>, LogTableProvider>();
    }
}