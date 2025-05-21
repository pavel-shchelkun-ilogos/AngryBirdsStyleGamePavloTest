using System;
using System.Collections.Generic;

/// <summary>
/// Core implementation for ServiceLocator.
/// Contains the service storage dictionary.
/// </summary>
public partial class ServiceLocator : IServiceLocator
{
	// Dictionary to hold service instances
	private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
}
