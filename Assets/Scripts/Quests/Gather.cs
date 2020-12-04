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
            inventory = GameObject.FindObjectOfType<GUI3.Inventories.Inventory>(); //this might be wrong
            if (inventory == null)
            {
                Debug.LogError("There is no player inventory.");
            }
        }
        #endregion
        #region Functions
        
        public override bool Completed()
        {/*
            GUI3.Inventories.Item item = inventory.FindItem(itemId);
            if (item == null)
            {
                return false;
            }
            if (item.Amount >= requiredAmount)
            {
                return true;
            }*/
            return false;
        }
        
        #endregion
    }
}