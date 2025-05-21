using System;

/// <summary>
/// Handles registration and unregistration of services.
/// </summary>
public partial class ServiceLocator
{
	/// <summary>
	/// Registers a service instance of type T.
	/// </summary>
	/// <typeparam name="T">Type of the service.</typeparam>
	/// <param name="service">Service instance to register.</param>
	public void Register<T>(T service) where T : class
	{
		var type = typeof(T);
		if (service == null)
			throw new ArgumentNullException(nameof(service), $"Cannot register null for {type.Name}");
		if (services.ContainsKey(type))
			throw new InvalidOperationException($"{type.Name} is already registered.");
		services[type] = service;
	}

	/// <summary>
	/// Unregisters a service of type T.
	/// </summary>
	/// <typeparam name="T">Type of the service.</typeparam>
	public void Unregister<T>() where T : class
	{
		var type = typeof(T);
		services.Remove(type);
	}
}
