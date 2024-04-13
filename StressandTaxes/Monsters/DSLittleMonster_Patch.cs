using System;
using HarmonyLib;

namespace StressandTaxes.Monsters.Patches
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(DSLittleMonster), "CheckHomeDistance")]
	public static class DSLittleMonster_CheckHomeDistance_Patch1
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
		[HarmonyPrefix]
		static void Prefix(DSLittleMonster __instance, ref float __state)
		{
			__state = __instance.maxRange;
			__instance.maxRange *= (float)1.75 - (GameManager.Instance.Player.Sanity.CurrentSanity);
		}

		[HarmonyPostfix]
		static void Postfix(DSLittleMonster __instance, float __state)
		{
			__instance.maxRange = __state
;
		}
	}

	[HarmonyPatch(typeof(DSLittleMonster), "Move")]
	public static class DSLittleMonster_Move_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
		[HarmonyPrefix]
		static void Prefix(DSLittleMonster __instance, ref float __state)
		{
			__state = __instance.speed;
			__instance.speed *= (float)1.75 - (GameManager.Instance.Player.Sanity.CurrentSanity);
			float sanity = GameManager.Instance.Player.Sanity.CurrentSanity;
			FileLog.Log(sanity.ToString());
			
		}

		[HarmonyPostfix]
		static void Postfix(DSLittleMonster __instance, float __state)
		{
			__instance.speed = __state
;
		}
	}

	[HarmonyPatch(typeof(DSLittleMonster), "UpdateAttachment")]
	public static class DSLittleMonster_UpdateAttachment_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
		[HarmonyPrefix]
		static void Prefix(DSLittleMonster __instance, ref float __state)
		{
			__state = __instance.attachDistanceThreshold;
			__instance.attachDistanceThreshold *= (float)1.75 - (GameManager.Instance.Player.Sanity.CurrentSanity);
		}

		[HarmonyPostfix]
		static void Postfix(DSLittleMonster __instance, float __state)
		{
			__instance.attachDistanceThreshold = __state
;
		}
	}
	
	[HarmonyPatch(typeof(DSLittleMonster), "LookForPlayer")]
	public static class DSLittleMonster_LookForPlayer_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
		[HarmonyPrefix]
		static void Prefix(DSLittleMonster __instance, ref float __state)
		{
			__state = __instance.maxRange;
			__instance.maxRange *= (float)1.75 - (GameManager.Instance.Player.Sanity.CurrentSanity);
		}

		[HarmonyPostfix]
		static void Postfix(DSLittleMonster __instance, float __state)
		{
			__instance.maxRange = __state;
		}
	}
}
