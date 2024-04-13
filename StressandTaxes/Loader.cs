using UnityEngine;

namespace StressandTaxes
{
	public class Loader
	{
		/// <summary>
		/// This method is run by Winch to initialize your mod
		/// </summary>
		public static void Initialize()
		{
			var gameObject = new GameObject(nameof(StressandTaxes));
			gameObject.AddComponent<SnTCore>();
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
