using System;
using HarmonyLib;
	
namespace StressandTaxes.Costs.Patches
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(ItemManager), "GetItemValue")]
	public static class ItemManager_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
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
