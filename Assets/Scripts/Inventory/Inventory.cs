using GUI1;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI3.Inventories
{
    public class Inventory : MonoBehaviour
    {
        #region Variables
        [Header("Inventory Variables")]
        public List<Item> inventory = new List<Item>();
        public Item selectedItem;
        [SerializeField] private PlayerControl player;

        [Header("Display Variables")]
        [SerializeField] private bool showInv = false;
        private string sortType = "";

        [Header("Equipment")]
        public Equipment[] equipmentSlots;

        [Serializable]
        public struct Equipment
        {
            public string slotName;
            public Transform equipLocation;
            public GameObject currentlyEquipped;
            public Item item;
        }

#if UNITY_EDITOR
        private Vector2 scr;
        private Vector2 scrollPosition;
#endif
        #endregion

        void Start()
        {

        }

        void Update()
        {

        }
        #region Functions

        #endregion

#if UNITY_EDITOR
        private void OnGUI()
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;

            if (showInv)
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), ""); //box of size screen

                string[] itemTypes = Enum.GetNames(typeof(ItemType)); //array of item type names
                int itemTypeCount = itemTypes.Length; //number of item types

                for (int i = 0; i < itemTypeCount; i++) //for every item type
                {
                    if (GUI.Button(new Rect((4 + i) * scr.x, 0, scr.x, 0.25f * scr.y), itemTypes[i])) //make button
                    {
                        sortType = itemTypes[i];
                    }
                }

                Display();

                if (selectedItem != null)
                {
                    OpenItem();
                }
            }
        }

        private void Display()
        {
            if (sortType == "")
            {
                scrollPosition = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y), scrollPosition, new Rect(0, 0, 0, inventory.Count * .25f * scr.y), false, true);

                for (int i = 0; i < inventory.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, (1 + i) * 0.25f * scr.y, 3 * scr.x, 0.25f * scr.y), inventory[i].Name))
                    {
                        selectedItem = inventory[i];
                    }
                }
                GUI.EndScrollView();
            }
            else
            {
                ItemType type = (ItemType)Enum.Parse(typeof(ItemType), sortType); //get enum from string

                int slotCount = 0;

                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, (1 + slotCount) * 0.25f * scr.y, 3 * scr.x, 0.25f * scr.y), inventory[i].Name))
                        {
                            selectedItem = inventory[i];
                        }
                        slotCount++;
                    }
                }
            }
        }
        private void OpenItem()
        {
            GUI.Box(new Rect(4.25f * scr.x, 0.5f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Icon);

            GUI.Box(new Rect(4.55f * scr.x, 3.5f * scr.y, 2.5f * scr.x, 0.5f * scr.y), selectedItem.Name);

            GUI.Box(new Rect(4.25f * scr.x, 4 * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

            switch (selectedItem.Type)
            {
                #region food
                case ItemType.Food:
                    if (player.lifeForce[0].current < player.lifeForce[0].max) //if not at max health
                    {
                        if (GUI.Button(new Rect(4.5f * scr.x, 6.5f * scr.y, scr.x, 0.25f * scr.y), "Eat")) //enable eat
                        {
                            player.lifeForce[0].current += selectedItem.EffectAmount; //heal by amount

                            selectedItem.Amount--; //decrease item
                            if (selectedItem.Amount <= 0) //if none left
                            {
                                inventory.Remove(selectedItem); //remove item
                                selectedItem = null; //select nothing
                                break;
                            }
                        }
                    }
                    break;
                #endregion

                case ItemType.Weapon:
                    if (equipmentSlots[2].currentlyEquipped == null || selectedItem.ID != equipmentSlots[2].item.ID) //if selected weapon not equipped
                    {
                        if (GUI.Button(new Rect(4.5f * scr.x, 6.5f * scr.y, scr.x, 0.25f * scr.y), "Equip")) //enable equip
                        {
                            if (equipmentSlots[2].currentlyEquipped != null) //if another weapon equipped
                            {
                                Destroy(equipmentSlots[2].currentlyEquipped); //get rid of it
                            }
                            GameObject currentItem = Instantiate(selectedItem.Mesh, equipmentSlots[2].equipLocation); //spawn new weapon object
                            equipmentSlots[2].currentlyEquipped = currentItem; //set as equipped
                            equipmentSlots[2].item = selectedItem; //set item
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(4.5f * scr.x, 6.5f * scr.y, scr.x, 0.25f * scr.y), "Unequip")) //enable unequip
                        {
                            Destroy(equipmentSlots[2].currentlyEquipped); //get rid of it
                            equipmentSlots[2].item = null; //nothing equipped
                        }
                    }
                    break;

                case ItemType.Apparel:
                    break;

                case ItemType.Crafting:
                    break;

                case ItemType.Ingredients:
                    break;

                case ItemType.Potions:
                    break;

                case ItemType.Scrolls:
                    break;

                case ItemType.Quest:
                    break;

                case ItemType.Money:
                    break;


                default:
                    break;
            }
        }
    }
#endif
}
