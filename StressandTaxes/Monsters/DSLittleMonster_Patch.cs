using Winch.Core;
using HarmonyLib;

namespace StressandTaxes.Monsters.Patches
{
	[HarmonyPatch(typeof(DSLittleMonster), "CheckHomeDistance")]
	public static class DSLittleMonster_CheckHomeDistance_Patch1
	{
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
		[HarmonyPrefix]
		static void Prefix(DSLittleMonster __instance, ref float __state)
		{
			__state = __instance.speed;
			__instance.speed *= (float)1.75 - (GameManager.Instance.Player.Sanity.CurrentSanity);
			float sanity = GameManager.Instance.Player.Sanity.CurrentSanity;
			WinchCore.Log.Info("sanity: " + sanity.ToString());
			
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
