using System;
using HarmonyLib;
using static WorldEventManager;
using static GameManager;

namespace StressandTaxes.Sanity.Patches
{
    [HarmonyPatch(typeof(PlayerSanity), "Update")]
    public static class PlayerSanity_Update_Patch
    {

        [HarmonyPrefix]
        static void Prefix(PlayerSanity __instance)
        {
            if (__instance._sanity == 0)
            {
                GameManager.Instance.WorldEventManager.RollForEvent();
            }
        }
    }

    [HarmonyPatch(typeof(PlayerSanity), "ChangeSanity")]
    public static class PlayerSanity_ChangeSanity_Patch
    {

        [HarmonyPrefix]
        static void Prefix(PlayerSanity __instance)
        {
            if (__instance._sanity == 0)
            {
                GameManager.Instance.WorldEventManager.RollForEvent();
            }
        }
    }

}
