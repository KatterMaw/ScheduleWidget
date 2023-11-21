using Autofac;
using CommunityToolkit.Diagnostics;

namespace ScheduleWidget;

public static class ServiceLocator
{
	public static IContainer Container
	{
		get
		{
			Guard.IsNotNull(_container);
			return _container;
		}
		set
		{
			if (_container != null)
				ThrowHelper.ThrowInvalidOperationException("Container already set");
			Guard.IsNotNull(value);
			_container = value;
		}
	}
	
	private static IContainer? _container;
}