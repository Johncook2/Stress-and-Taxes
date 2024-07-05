using System;
using HarmonyLib;

namespace StressandTaxes.Costs.Patches
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(GameConfigData), "HullRepairCostPerSquare", MethodType.Getter)]
	public static class GameConfigData_HullRepair_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
		[HarmonyPostfix]
		static void HullRepairCostPerSquare(ref decimal __result)
		{
			__result *= 6;
		}
	}

    [HarmonyPatch(typeof(GameConfigData), "NightSanityModifier", MethodType.Getter)]
    public static class GameConfigData_SanityModifier_Patch
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
        [HarmonyPostfix]
        static void NightSanityModifier(ref decimal __result)
        {
            __result *= 2;
        }
    }

    [HarmonyPatch(typeof(GameConfigData), "GreaterMarrowDebtRepaymentProportion", MethodType.Getter)]
    public static class GameConfigData_GreaterMarrowDebtRepaymentProportion_Patch
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
        [HarmonyPostfix]
        static void GreaterMarrowDebtRepaymentProportion(ref decimal __result)
        {
            __result *= (GameManager.Instance.GameConfigData.greaterMarrowDebt - GameManager.Instance.SaveData.GreaterMarrowRepayments) / 1000;
        }
    }
}
