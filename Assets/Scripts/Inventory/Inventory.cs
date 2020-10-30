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

        [Header("Display Variables")]
        [SerializeField] private bool showInv = false;
        private string sortType = "";

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
    }
#endif
}
