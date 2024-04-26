using System;
using HarmonyLib;

namespace StressandTaxes.Sanity.Patches
{
    // Token: 0x02000004 RID: 4
    [HarmonyPatch(typeof(PlayerSanity), "Update")]
    public static class PlayerSanity_Update_Patch
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74

        [HarmonyPrefix]
        static void Prefix(PlayerSanity __instance)
        {
            if (__instance._sanity = 0)
            {
                WorldEventManager.RollForEvent();
            }
        }
    }

    [HarmonyPatch(typeof(PlayerSanity), "ChangeSanity")]
    public static class PlayerSanity_ChangeSanity_Patch
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74

        [HarmonyPrefix]
        static void Prefix(PlayerSanity __instance)
        {
            if (__instance._sanity = 0)
            {
                WorldEventManager.RollForEvent();
            }
        }
    }

}