using System.Collections.Generic;//List
using UnityEngine;

namespace GUI3.Inventories
{
    public class Chest : InvBase
    {
        
        /*
        private void OnGUI()
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
            if (showChestInv)
            {
                //Display of the chest items
                for (int i = 0; i < chestInv.Count; i++)
                {
                    if (GUI.Button(new Rect(12.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), chestInv[i].Name))
                    {
                        selectedItem = chestInv[i];
                    }
                }
                if (selectedItem != null)
                {
                    GUI.Box(new Rect(8.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 7 * scr.y), "");
                    GUI.Box(new Rect(8.75f * scr.x, 0.5f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Icon);
                    GUI.Box(new Rect(9.05f * scr.x, 3.5f * scr.y, 2.5f * scr.x, 0.5f * scr.y), selectedItem.Name);
                    GUI.Box(new Rect(8.75f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                    if (GUI.Button(new Rect(10.5f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Take Item"))
                    {
                        //add to player
                        _inventory.AddItem(ItemData.CreateItem(selectedItem.ID));
                        //remove from chest
                        chestInv.Remove(selectedItem);
                        selectedItem = null;
                        return;
                    }
                }
            }
        }
        */
    }
}