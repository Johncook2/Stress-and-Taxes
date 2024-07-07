using System;
using HarmonyLib;
using static WorldEventManager;
using static GameManager;

namespace StressandTaxes.Sanity.Patches
{
    [HarmonyPatch(typeof(SanityModifierDetector), "GetTotalModifierValue")]
    public static class SanityModifierDetector_GetTotalModifierValue_Patch
    {
        [HarmonyPrefix]
        static void Postfix(ref decimal __result)
        {
             __result *=  1;
        }
    }
}