using System;

namespace Assets.Scripts
{
	public static class Game
	{
		// Lazy-initialized singleton instance implementing IServiceLocator
		private static readonly Lazy<IServiceLocator> _lazyInstance =
			new Lazy<IServiceLocator>(() => new ServiceLocator());

		/// <summary>
		/// Gets the global, lazily-initialized IServiceLocator instance.
		/// </summary>
		public static IServiceLocator ServiceLocator => _lazyInstance.Value;
	}
}
