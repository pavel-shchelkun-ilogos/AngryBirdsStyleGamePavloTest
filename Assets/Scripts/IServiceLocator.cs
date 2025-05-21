using System;

public interface IServiceLocator
{
    /// <summary>
    /// Registers a service instance of type T.
    /// </summary>
    /// <typeparam name="T">Type of the service.</typeparam>
    /// <param name="service">Service instance to register.</param>
    void Register<T>(T service) where T : class;

    /// <summary>
    /// Retrieves a registered service of type T.
    /// </summary>
    /// <typeparam name="T">Type of the service.</typeparam>
    /// <returns>Registered service instance.</returns>
    T Get<T>() where T : class;

    /// <summary>
    /// Unregisters a service of type T.
    /// </summary>
    /// <typeparam name="T">Type of the service.</typeparam>
    void Unregister<T>() where T : class;

    /// <summary>
    /// Clears all registered services.
    /// </summary>
    void Clear();
}