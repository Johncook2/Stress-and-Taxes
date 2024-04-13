using System;
using HarmonyLib;

namespace StressandTaxes.Monsters.Patches
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(SBMonsterAnimationHelper), "Update")]
	public static class SBMonsterAnimationHelper_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
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
