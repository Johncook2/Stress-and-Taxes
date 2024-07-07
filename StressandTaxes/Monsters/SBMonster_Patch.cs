using System;
using HarmonyLib;

namespace StressandTaxes.Monsters.Patches
{
	[HarmonyPatch(typeof(SBMonsterAnimationHelper), "Update")]
	public static class SBMonsterAnimationHelper_Patch
	{
		[HarmonyPrefix]
		static void Prefix(SBMonsterAnimationHelper __instance, ref float __state)
		{
			__state = __instance.attackTentacleInRangeDurationThreshold;
			__instance.attackTentacleInRangeDurationThreshold *= (float) (GameManager.Instance.Player.Sanity.CurrentSanity);
		}

		[HarmonyPostfix]
		static void Postfix(SBMonsterAnimationHelper __instance, float __state)
		{
			__instance.attackTentacleInRangeDurationThreshold = __state
;
		}
	}

}
