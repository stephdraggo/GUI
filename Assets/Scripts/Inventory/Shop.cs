using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI3.Inventories
{
    public class Shop : MonoBehaviour
    {
        public List<Item> shopInv = new List<Item>();
        public Item selectedItem;
        public bool showShopInv;
        public Vector2 scr;
        //public ApprovalDialogue dlg;
        private void Start()
        {
            #region add some default items
            //add some items in here (theoretically could have one of each item)
            shopInv.Add(ItemData.CreateItem(Random.Range(0, 2)));
            shopInv.Add(ItemData.CreateItem(Random.Range(0, 2)));
            shopInv.Add(ItemData.CreateItem(Random.Range(100, 103)));
            shopInv.Add(ItemData.CreateItem(Random.Range(100, 103)));
            shopInv.Add(ItemData.CreateItem(Random.Range(100, 103)));
            shopInv.Add(ItemData.CreateItem(Random.Range(200, 212)));
            shopInv.Add(ItemData.CreateItem(Random.Range(300, 302)));
            shopInv.Add(ItemData.CreateItem(Random.Range(300, 302)));
            shopInv.Add(ItemData.CreateItem(Random.Range(500, 502)));
            shopInv.Add(ItemData.CreateItem(Random.Range(500, 502)));
            shopInv.Add(ItemData.CreateItem(Random.Range(600, 602)));
            shopInv.Add(ItemData.CreateItem(Random.Range(600, 602)));
            #endregion
        }
        /*
        private void OnGUI()
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
            if (showShopInv)
            {
                //Display of the shop items
                for (int i = 0; i < shopInv.Count; i++)
                {
                    if (GUI.Button(new Rect(12.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), shopInv[i].Name))
                    {
                        selectedItem = shopInv[i];
                    }
                }
                if (selectedItem != null)
                {
                    GUI.Box(new Rect(8.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 7 * scr.y), "");
                    GUI.Box(new Rect(8.75f * scr.x, 0.5f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Icon);
                    GUI.Box(new Rect(9.05f * scr.x, 3.5f * scr.y, 2.5f * scr.x, 0.5f * scr.y), selectedItem.Name);
                    GUI.Box(new Rect(8.75f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);
                    if (Inventory.money >= selectedItem.Value)
                    {
                        if (GUI.Button(new Rect(10.5f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Buy Item"))
                        {
                            LinearInventory.money -= selectedItem.Value;
                            //add to player
                            LinearInventory.inv.Add(ItemData.CreateItem(selectedItem.ID));
                            //remove from shop
                            shopInv.Remove(selectedItem);
                            selectedItem = null;
                            return;
                        }
                    }

                }
                if (GUI.Button(new Rect(0.25f * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Exit Shop"))
                {
                    showShopInv = false;
                    LinearInventory.showInv = false;
                    LinearInventory.currentShop = null;
                    dlg.showDlg = true;
                }
                GUI.Box(new Rect(7f * scr.x, 8.5f * scr.y, 2 * scr.x, 0.5f * scr.y), "Money $" + LinearInventory.money);

            }
        }*/
    }
}