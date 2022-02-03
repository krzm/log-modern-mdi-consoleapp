using DIHelper;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class Program
{
    static void Main(string[] args)
	{
		IBootstraper booter = new Bootstraper(
			new MDIDependencySuite(
				new ServiceCollection()));
		booter.Boot(args);
	}
}