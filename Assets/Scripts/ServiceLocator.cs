using System;
using System.Collections.Generic;

/// <summary>
/// Instance-based Service Locator for Unity projects.
/// Implements the IServiceLocator interface for dependency injection and testing.
/// </summary>
public class ServiceLocator : IServiceLocator
{
    // Dictionary to hold service instances
    private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

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
    /// Unregisters a service of type T.
    /// </summary>
    /// <typeparam name="T">Type of the service.</typeparam>
    public void Unregister<T>() where T : class
    {
        var type = typeof(T);
        if (services.ContainsKey(type))
            services.Remove(type);
    }

    /// <summary>
    /// Clears all registered services.
    /// </summary>
    public void Clear()
    {
        services.Clear();
    }
}