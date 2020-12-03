using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI3.Inventories
{
    public class ItemHandler : MonoBehaviour
    {
        public int itemId;
        public ItemType itemType;
        public int amount;
        private void Start()
        {
            
        }
        public void OnCollection(Inventory _inventory)
        {
            if (itemType == ItemType.Money)
            {
                Inventory.money += amount;
            }
            else if (itemType == ItemType.Weapon || itemType == ItemType.Wearable || itemType == ItemType.Quest)//Weapon,Apparel, Quest
            {
                _inventory.AddItem(ItemData.CreateItem(itemId));
            }
            else //Food,Crafting,Ingredients,Potions,Scrolls
            {
                _inventory.AddItem(ItemData.CreateItem(itemId));
                /*
                int found = 0;
                int addIndex = 0;
                for (int i = 0; i < inv.inventory.Count; i++)
                {
                    if (itemId == inv.inventory[i].ID)
                    {
                        found = 1;
                        addIndex = i;
                        break;
                    }
                }
                if (found == 1)
                {
                    inv.inventory[addIndex].Amount += amount;
                }
                else
                {
                    inv.inventory.Add(ItemData.CreateItem(itemId));

                    for (int i = 0; i < inv.inventory.Count; i++)
                    {
                        if (itemId == inv.inventory[i].ID)
                        {
                            inv.inventory[i].Amount = amount;
                        }
                    }
                }*/
            }
            Destroy(gameObject);
        }
    }
}