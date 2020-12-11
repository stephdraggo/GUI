using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.Quests
{
    public class Gather : QuestGoal
    {
        #region Variables
        [Header("Gather Quest details")]
        public int itemId;
        public int requiredAmount;
        public int currentAmount;

        public GUI3.Inventories.Inventory inventory;
        #endregion
        #region Start
        private void Start()
        {
            inventory = FindObjectOfType<GUI1.PlayerControl>().GetComponent<GUI3.Inventories.Inventory>(); //get inventory of player
            if (inventory == null)
            {
                Debug.LogError("There is no player inventory.");
            }
        }
        #endregion
        #region Functions
        
        public override bool Completed()
        {
            //figure out if player inv contains item of id itemID

            GUI3.Inventories.Item item = inventory.IDToItem(itemId);

            if (item == null)
            {
                return false;
            }
            currentAmount = item.Amount;
            if (item.Amount >= requiredAmount)
            {
                return true;
            }
            return false;
        }
        public override void Claim()
        {
            inventory.selectedItem = inventory.IDToItem(itemId);
            inventory.RemoveItem(requiredAmount);
            inventory.selectedItem = null;
        }
        #endregion
    }
}