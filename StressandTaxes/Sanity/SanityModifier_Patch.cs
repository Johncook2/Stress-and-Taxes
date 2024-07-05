using System;
using HarmonyLib;
using static WorldEventManager;
using static GameManager;

namespace StressandTaxes.Sanity.Patches
{
    // Token: 0x02000004 RID: 4
    [HarmonyPatch(typeof(SanityModifierDetector), "GetTotalModifierValue")]
    public static class SanityModifierDetector_GetTotalModifierValue_Patch
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74

        [HarmonyPrefix]
        static void Postfix(ref decimal __result)
        {
             __result *=  1;
        }
    }
}