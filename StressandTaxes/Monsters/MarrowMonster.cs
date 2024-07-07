using System;
using HarmonyLib;

namespace StressandTaxes.Monsters.Patches
{
	[HarmonyPatch(typeof(MarrowMonster), "Update")]
	public static class MarrowMonster_Update_Patch
	{
		[HarmonyPostfix]
		static void Postfix(MarrowMonster __instance)
		{
			__instance.navMeshAgent.speed *= 2
;
		}
	}

}
