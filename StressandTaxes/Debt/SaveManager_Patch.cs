using System;
using HarmonyLib;


namespace StressandTaxes.Debt.Patches
{	
	[HarmonyPatch(typeof(SaveManager), "Save")]
	public static class Save_Patch
	{
	static void Prefix( ref decimal __state)
		{
			if (GameManager.Instance.SaveData.GreaterMarrowRepayments == 50)
			{
				GameManager.Instance.SaveData.GreaterMarrowRepayments = 100;
			}

            __state = GameManager.Instance.SaveData.GreaterMarrowRepayments;
			GameManager.Instance.SaveData.GreaterMarrowRepayments = GameManager.Instance.GameConfigData.greaterMarrowDebt - __state;
		}	
	
	static void Postfix( ref decimal __state)
		{
			GameManager.Instance.GameConfigData.greaterMarrowDebt = GameManager.Instance.SaveData.GreaterMarrowRepayments + __state;
			GameManager.Instance.SaveData.GreaterMarrowRepayments = __state;
		}
	}

	[HarmonyPatch(typeof(SaveManager), "Load")]
	public static class Load_Patch
	{
	static void Postfix()
		{
			GameManager.Instance.GameConfigData.greaterMarrowDebt = GameManager.Instance.SaveData.GreaterMarrowRepayments+1;
			GameManager.Instance.SaveData.GreaterMarrowRepayments = 1;

		}
	}
}
