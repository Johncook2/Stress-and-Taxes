using BepInEx;
using System;
using HarmonyLib;

namespace StressandTaxes.Costs.Patches
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(GameConfigData), "HullRepairCostPerSquare", MethodType.Getter)]
	public static class GameConfigData_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
		[HarmonyPostfix]
		static void HullRepairCostPerSquare(ref decimal __result)
		{
			__result *= 6;
		}
	}
}