using System;
using UnityEngine;

namespace Assets.Scripts.Test
{
	public class Game : MonoBehaviour
	{
		private void Start()
		{
			var services = new ServiceLocator();
			var monoSingletone = FindObjectOfType<TestPlayerController>();
			var test = new TestScript();
			services.Get<SlingShot>();
		}
	}
}
