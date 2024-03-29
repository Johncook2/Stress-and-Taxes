using UnityEngine;
using Winch.Core;

namespace StressandTaxes
{
	public class StressandTaxes : MonoBehaviour
	{
		public void Awake()
		{
			WinchCore.Log.Debug($"{nameof(StressandTaxes)} has loaded!");
		}
	}
}
