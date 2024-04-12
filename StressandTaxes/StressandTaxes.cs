using UnityEngine;
using Winch.Core;
using System;
using HarmonyLib;


namespace StressandTaxes
{
	public class StressandTaxes : MonoBehaviour
	{
		public void Awake()
		{
			WinchCore.Log.Debug($"{nameof(StressandTaxes)} has loaded!");
		}
	}

	[HarmonyPatch(typeof(GameConfigData), "HullRepairCostPerSquare", MethodType.Getter)]
	public static class GameConfigData_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
		[HarmonyPostfix]
		static void HullRepairCostPerSquare(ref decimal __result)
		{
			__result *= 6;
		}
	}

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

	[HarmonyPatch(typeof(MarrowMonster), "Update")]
	public static class MarrowMonster_Update_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74

		[HarmonyPostfix]
		static void Postfix(MarrowMonster __instance)
		{
			__instance.navMeshAgent.speed *= 2
;
		}
	}

	[HarmonyPatch(typeof(RepairActionHandler), "OnItemHoveredChanged")]
	public static class RepairActionHandler_OnItemHoveredChanged_Patch
	{
		static void Postfix(RepairActionHandler __instance)
		{
			__instance.repairAction.Enable();
		}
	}

	[HarmonyPatch(typeof(RepairActionHandler), "RepairFocusedItem")]
	public static class RepairActionHandler_RepairFocusedItem_Patch
	{
		static void Postfix(RepairActionHandler __instance)
		{
			GridCell lastSelectedCell = GameManager.Instance.GridManager.LastSelectedCell;
			if (lastSelectedCell && lastSelectedCell.OccupyingUnderlayObject && lastSelectedCell.OccupyingUnderlayObject.ItemData.itemType == ItemType.DAMAGE)
			{
				if (GameManager.Instance.SaveData.Funds < __instance.repairCost)
				{
					GameManager.Instance.GameConfigData.greaterMarrowDebt += __instance.repairCost;
					lastSelectedCell.ParentGrid.linkedGrid.RemoveObjectFromGridData(lastSelectedCell.OccupyingUnderlayObject.SpatialItemInstance, true);
					GameManager.Instance.Input.RemoveActionListener(new DredgePlayerActionBase[]
					{
						__instance.repairAction
					}, ActionLayer.UI_WINDOW);
					GameEvents.Instance.TriggerItemHoveredChanged(lastSelectedCell.OccupyingObject);
					GameEvents.Instance.TriggerOnPlayerDamageChanged();
				}
			}
			else if (lastSelectedCell && lastSelectedCell.OccupyingObject && lastSelectedCell.OccupyingObject.ItemData.damageMode == DamageMode.DURABILITY && GameManager.Instance.SaveData.Funds < __instance.repairCost)
			{
				GameManager.Instance.GameConfigData.greaterMarrowDebt += __instance.repairCost;
				lastSelectedCell.OccupyingObject.SpatialItemInstance.RepairToFullDurability();
				GameManager.Instance.Input.RemoveActionListener(new DredgePlayerActionBase[]
				{
					__instance.repairAction
				}, ActionLayer.UI_WINDOW);
				GameEvents.Instance.TriggerItemInventoryChanged(lastSelectedCell.OccupyingObject.ItemData);
				GameEvents.Instance.TriggerItemHoveredChanged(lastSelectedCell.OccupyingObject);
				GameEvents.Instance.TriggerItemsRepaired();
			}
			__instance.RefreshRepairAllPrompt();
		}
	}

	[HarmonyPatch(typeof(SaveManager), "Save")]
	public static class Save_Patch
	{
	static void Prefix( ref decimal __state)
		{
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

	[HarmonyPatch(typeof(SBMonsterAnimationHelper), "Update")]
	public static class SBMonsterAnimationHelper_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
		[HarmonyPrefix]
		static void Prefix(SBMonsterAnimationHelper __instance, ref float __state)
		{
			__state = __instance.attackTentacleInRangeDurationThreshold;
			__instance.attackTentacleInRangeDurationThreshold *= (float) (GameManager.Instance.Player.Sanity.CurrentSanity);
		}

		[HarmonyPostfix]
		static void Postfix(SBMonsterAnimationHelper __instance, float __state)
		{
			__instance.attackTentacleInRangeDurationThreshold = __state
;
		}
	}

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
				__result *= (decimal) 0.5;

				if (itemData.itemSubtype == ItemSubtype.FISH)
				{
					FishItemData FishItemData = itemData as FishItemData;
					if (!FishItemData.day)
					{
						__result *= (decimal) 1.5;
					}
					if (FishItemData.isAberration)
					{
						__result *= 2;
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
