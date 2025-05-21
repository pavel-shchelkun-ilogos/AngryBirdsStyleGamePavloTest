/// <summary>
/// Provides a global singleton instance of the ServiceLocator.
/// </summary>
public partial class ServiceLocator
{
	private static readonly ServiceLocator _instance = new ServiceLocator();

	/// <summary>
	/// Gets the global ServiceLocator instance.
	/// </summary>
	public static ServiceLocator Instance => _instance;
}
