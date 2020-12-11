using GUI1;
using System.Linq; //conCAT
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GUI3.Inventories
{
    public class Inventory : InvBase
    {
        #region Variables
        [Header("Inventory Variables")]
        public static int money;
        public Text displayMoney;
        public GameObject itemPrefab;
        public Transform itemParent;

        [Header("Equipment")]
        public Equipment[] equipmentSlots;

        [Header("Current Shop/Chest")]
        public bool chestShopActive;
        public GameObject chestShopPanel;

        [System.Serializable]
        public struct Equipment
        {
            public string slotName;
            public Transform equipLocation;
            public GameObject currentlyEquipped;
            public Item item;
        }
        #endregion

        protected override void Start()
        {
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

            chestShopPanel.SetActive(false);

        }
        protected override void Update()
        {
            base.Update();

            displayMoney.text = "$" + money.ToString();
        }
        #region Functions


        public override void ShowItem()
        {
            base.ShowItem();

            #region set use button by type

            actionButtons[0].onClick.RemoveAllListeners(); //add specific listeners in switch
            buttonText = actionButtons[0].GetComponentInChildren<Text>();
            switch (selectedItem.Type)
            {
                case ItemType.Consumable:
                    buttonText.text = "Consume";
                    actionButtons[0].onClick.AddListener(ConsumeItem);
                    break;

                case ItemType.Weapon:
                    if (equipmentSlots[2].currentlyEquipped == null || selectedItem.Name != equipmentSlots[2].currentlyEquipped.name)
                    {
                        buttonText.text = "Equip";
                    }
                    else
                    {
                        buttonText.text = "Unequip";
                    }
                    actionButtons[0].onClick.AddListener(EquipItem);
                    break;

                case ItemType.Wearable:
                    buttonText.text = "Equip";
                    actionButtons[0].onClick.AddListener(EquipItem);
                    break;

                case ItemType.Crafting:
                    buttonText.text = "Use";
                    actionButtons[0].onClick.AddListener(UseItem);
                    break;

                case ItemType.Ingredients:
                    buttonText.text = "Use";
                    actionButtons[0].onClick.AddListener(UseItem);
                    break;

                case ItemType.Potions:
                    buttonText.text = "Consume";
                    actionButtons[0].onClick.AddListener(ConsumeItem);
                    break;

                case ItemType.Scrolls:
                    buttonText.text = "Use";
                    actionButtons[0].onClick.AddListener(UseItem);
                    break;

                case ItemType.Quest:
                    buttonText.text = "N/A";
                    break;

                case ItemType.Money:
                    buttonText.text = "N/A";
                    break;

                default:
                    break;
            }
            #endregion
        }
        #region using items
        private void UseItem()
        {
            //crafting, ingredients, scrolls
            Debug.Log("Used " + selectedItem.Name);
            RemoveItem();
        }
        private void ConsumeItem()
        {
            //food, potions
            Debug.Log("Consumed " + selectedItem.Name);
            player.lifeForce[0].current += selectedItem.EffectAmount;
            RemoveItem();
        }
        private void EquipItem()
        {
            //armour, weapons
            Debug.Log("Equipped " + selectedItem.Name);

            //if we have something equiped then remove it
            if (equipmentSlots[2].currentlyEquipped != null)
            {
                Destroy(equipmentSlots[2].currentlyEquipped);
            }
            GameObject curItem = Instantiate(selectedItem.Mesh, equipmentSlots[2].equipLocation);
            equipmentSlots[2].currentlyEquipped = curItem;
            curItem.name = selectedItem.Name;

            //if this is equipped, then remove it
            if (selectedItem.Name == equipmentSlots[2].currentlyEquipped.name)
            {
                Destroy(equipmentSlots[2].currentlyEquipped);
            }

            selectedItem = null;
        }
        public void DropItem()
        {
            //spawn thing in world and delete from inventory or send to chest or shop if there is one open
            GameObject newObject = Instantiate(itemPrefab, player.transform.position, Quaternion.identity, itemParent);
            ItemHandler newIt = newObject.AddComponent<ItemHandler>();
            newIt.itemId = selectedItem.ID;
            newIt.itemType = selectedItem.Type;
            newIt.amount = 1;
            newObject.name = selectedItem.Name;
            newObject.layer = LayerMask.NameToLayer("Interactable");

            RemoveItem();
        }
        #endregion
        public Item IDToItem(int _id)
        {
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].ID == _id)
                {
                    return inv[i];
                }
            }
            return null;
        }
        #endregion

    }

}
