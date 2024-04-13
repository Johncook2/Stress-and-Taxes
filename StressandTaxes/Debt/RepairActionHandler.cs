using BepInEx;
using System;
using HarmonyLib;

namespace StressandTaxes.Debt.Patches
{
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
}