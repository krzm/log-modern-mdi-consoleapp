using CLI.Core;
using CLI.Core.Lib;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class Program
{
    static void Main(string[] args)
	{
		IBootstraper booter = new Bootstraper(
			new MDIDependencyCollection(
				new ServiceCollection()));
		booter.Boot(args);
	}
}