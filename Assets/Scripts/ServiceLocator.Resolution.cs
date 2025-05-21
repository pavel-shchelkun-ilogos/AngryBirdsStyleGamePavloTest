using System;
using System.Collections.Generic;

/// <summary>
/// Handles retrieval and clearing of registered services.
/// </summary>
public partial class ServiceLocator
{
	/// <summary>
	/// Retrieves a registered service of type T.
	/// </summary>
	/// <typeparam name="T">Type of the service.</typeparam>
	/// <returns>Registered service instance.</returns>
	public T Get<T>() where T : class
	{
		var type = typeof(T);
		if (services.TryGetValue(type, out var service))
			return service as T;
		throw new KeyNotFoundException($"{type.Name} is not registered in the ServiceLocator.");
	}

	/// <summary>
	/// Clears all registered services.
	/// </summary>
	public void Clear()
	{
		services.Clear();
	}
}
