using Autofac;
using Serilog;

namespace ScheduleWidget;

public static class AppBootstrapper
{
	public static void Setup()
	{
		SetupLogging();
		SetupServiceLocator();
	}

	private static void SetupLogging()
	{
		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Verbose()
			.WriteTo.Seq("http://localhost:5341")
			.WriteTo.Debug()
			.CreateLogger();
	}

	private static void SetupServiceLocator()
	{
		ServiceLocator.Container = new ContainerBuilder()
			.Build();
	}
}