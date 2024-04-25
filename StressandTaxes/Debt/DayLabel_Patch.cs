using System;
using HarmonyLib;

namespace StressandTaxes.Debt.Patches
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(DayLabel), "Update")]
	public static class DayLabel_Update_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74

		[HarmonyPrefix]
		static void Prefix(DayLabel __instance)
		{
			if (GameManager.Instance.Time.Day != __instance.prevDay and __instance.prevDay != -1)
			{
				GameManager.Instance.GameConfigData.greaterMarrowDebt = GameManager.Instance.GameConfigData.greaterMarrowDebt * (decimal)1.2;
			}
;
		}
	}

}
