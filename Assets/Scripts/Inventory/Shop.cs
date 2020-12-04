using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GUI3.Inventories
{
    public class Shop : InvBase
    {
        public Inventory playerInv;
        public GameObject shopPanel;

        protected override void Start()
        {
            playerInv = player.gameObject.GetComponent<Inventory>();

            playerInv.actionButtons[2].onClick.RemoveAllListeners();
            playerInv.actionButtons[2].onClick.AddListener(SellItem);

            base.Start();

            #region add some default items
            //add some items in here (theoretically could have one of each item)
            AddItem(Random.Range(0, 2));
            AddItem(Random.Range(0, 2));
            AddItem(Random.Range(100, 103));
            AddItem(Random.Range(100, 103));
            AddItem(Random.Range(100, 103));
            AddItem(Random.Range(200, 212));
            AddItem(Random.Range(300, 302));
            AddItem(Random.Range(300, 302));
            AddItem(Random.Range(500, 502));
            AddItem(Random.Range(500, 502));
            AddItem(Random.Range(600, 602));
            AddItem(Random.Range(600, 602));
            #endregion

            SortAndShowInventory();
        }
        public void BuyOne()
        {
            BuyItem(1);
        }
        public void BuyAll()
        {
            BuyItem(selectedItem.Amount);
        }
        private void BuyItem(int _amount)
        {
            if (Inventory.money >= selectedItem.Value * _amount)
            {
                Inventory.money -= selectedItem.Value * _amount;
                for (int i = 0; i < _amount; i++)
                {
                    playerInv.AddItem(selectedItem.ID);
                    RemoveItem();
                }
            }
            else
            {
                Debug.LogError("not enough money");
            }
            SortAndShowInventory();
        }
        public void SellItem()
        {
            Inventory.money += playerInv.selectedItem.Value / 2;
            AddItem(playerInv.selectedItem.ID);
            playerInv.RemoveItem();
            SortAndShowInventory();
        }
        public override void ShowItem()
        {
            base.ShowItem();
            itemDescription.text = selectedItem.Description + "\n\nCost: $" + selectedItem.Value.ToString();
        }
    }
}