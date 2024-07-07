using System;
using HarmonyLib;
	
namespace StressandTaxes.Costs.Patches
{
	[HarmonyPatch(typeof(ItemManager), "GetItemValue")]
	public static class ItemManager_Patch
	{
		[HarmonyPostfix]
		public static void GetItemValue(ref decimal __result, SpatialItemInstance itemInstance, ItemManager.BuySellMode mode, float sellValueModifier = 0.5f)
		{
			SpatialItemData itemData = itemInstance.GetItemData<SpatialItemData>();
			
			bool flag = mode != ItemManager.BuySellMode.SELL;
			if (!flag)
			{
				__result *= (decimal) 0.75;

				if (itemData.itemSubtype == ItemSubtype.FISH)
				{
					FishItemData FishItemData = itemData as FishItemData;
					if (!FishItemData.day)
					{
						__result *= (decimal) 1.5;
					}
					if (FishItemData.isAberration)
					{
						__result *= (decimal) 1.5;
					}
				}

			}
			if (flag)
			{
				__result *= 1;
			}
		}
	}
}
