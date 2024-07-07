using System;
using HarmonyLib;

namespace StressandTaxes.Debt.Patches
{
	[HarmonyPatch(typeof(DayLabel), "Update")]
	public static class DayLabel_Update_Patch
	{
		[HarmonyPrefix]
		static void Prefix(DayLabel __instance)
		{
			if (GameManager.Instance.Time.Day != __instance.prevDay && __instance.prevDay != -1)
			{
				GameManager.Instance.GameConfigData.greaterMarrowDebt = GameManager.Instance.GameConfigData.greaterMarrowDebt * (decimal)1.3;
			}
		}
	}

}
