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
        private void Update()
        {
            if (transform.position.y < -200) //if fallen off world
            {
                Destroy(gameObject); //remove
            }
        }
        public void OnCollection(Inventory _inventory)
        {
            if (itemType == ItemType.Money)
            {
                Inventory.money += amount;
            }
            else if (itemType == ItemType.Weapon || itemType == ItemType.Wearable || itemType == ItemType.Quest)//Weapon,Apparel, Quest
            {
                _inventory.AddItem(itemId);
            }
            else //Food,Crafting,Ingredients,Potions,Scrolls
            {
                _inventory.AddItem(itemId);
            }
            Destroy(gameObject);
        }
    }
}