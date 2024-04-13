using System;
using HarmonyLib;

namespace StressandTaxes.Monsters.Patches
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(MarrowMonster), "Update")]
	public static class MarrowMonster_Update_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74

		[HarmonyPostfix]
		static void Postfix(MarrowMonster __instance)
		{
			__instance.navMeshAgent.speed *= 2
;
		}
	}

}
