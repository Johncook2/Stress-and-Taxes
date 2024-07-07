using System;
using HarmonyLib;

namespace StressandTaxes.Costs.Patches
{
	[HarmonyPatch(typeof(GameConfigData), "HullRepairCostPerSquare", MethodType.Getter)]
	public static class GameConfigData_HullRepair_Patch
	{
		[HarmonyPostfix]
		static void HullRepairCostPerSquare(ref decimal __result)
		{
			__result *= 6;
		}
	}

    [HarmonyPatch(typeof(GameConfigData), "NightSanityModifier", MethodType.Getter)]
    public static class GameConfigData_SanityModifier_Patch
    {
        [HarmonyPostfix]
        static void NightSanityModifier(ref float __result)
        {
            __result *= 2;
        }
    }

    [HarmonyPatch(typeof(GameConfigData), "GreaterMarrowDebtRepaymentProportion", MethodType.Getter)]
    public static class GameConfigData_GreaterMarrowDebtRepaymentProportion_Patch
    {
        [HarmonyPostfix]
        static void GreaterMarrowDebtRepaymentProportion(ref decimal __result)
        {
            __result *= (GameManager.Instance.GameConfigData.greaterMarrowDebt - GameManager.Instance.SaveData.GreaterMarrowRepayments) / 1000;
        }
    }
}
