using System;
using HarmonyLib;

/*
namespace StressandTaxes.Debt.Patches
{
    [HarmonyPatch(typeof(SellModeActionHandler), "SellFocusedItem")]
    public static class SellModeActionHandler_Focused_Patch
    {
        static void Prefix(SellModeActionHandler __instance, ref decimal __state)
        {
            __state = __instance.destination.Id;
            __instance.destination.Id = "destination.gm-fishmonger";
        }

        static void Postfix(ref decimal __state)
        {
            __instance.destination.Id = __state;
        }
    }

    [HarmonyPatch(typeof(SellModeActionHandler), "OnSellAllPressed")]
    public static class SellModeActionHandler_All_Patch
    {
        static void Prefix(SellModeActionHandler __instance, ref decimal __state)
        {
            __state = __instance.destination.Id;
            __instance.destination.Id = "destination.gm-fishmonger";
        }

        static void Postfix(ref decimal __state)
        {
            __instance.destination.Id = __state;
        }
    }
}
*/