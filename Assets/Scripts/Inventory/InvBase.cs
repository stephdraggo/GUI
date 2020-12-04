using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GUI1;
using System.Linq;

namespace GUI3.Inventories
{
    public abstract class InvBase : MonoBehaviour
    {
        #region Variables

        [Header("Inventory Variables")]
        #region general inventory info
        public List<Item> inventory = new List<Item>();
        public Item selectedItem;
        public GameObject selectedButton;
        public PlayerControl player;
        #endregion

        [Header("Show Item Variables")]
        #region item display
        public GameObject itemShow;
        public Text itemName;
        public Image itemIcon;
        public Text itemDescription;
        [Tooltip("Player: 0-use, 1-drop, 2-sell\n\nShop: 0-buy 1, 1-buy all\n\nChest: 0-take 1, 1-take all, 2-take everything")]
        public Button[] actionButtons;
        public Text buttonText;
        #endregion

        [Header("Display Inventory Variables")]
        #region inventory display
        public GameObject itemButtonPrefab;
        public Transform buttonParent;
        protected string sortType = "";
        protected string[] sortByType;
        public List<GameObject> itemButtons;
        #endregion

        #endregion
        #region Start
        protected virtual void Start()
        {
            player = FindObjectOfType<PlayerControl>();

            #region get array of sorting types
            string[] first = new string[] { "All" };
            string[] second = System.Enum.GetNames(typeof(ItemType));
            string[] sortByType = first.Concat(second).ToArray();
            #endregion
        }
        #endregion
        #region Update
        protected virtual void Update()
        {
            if (selectedItem != null)
            {
                if (selectedItem.Amount <= 0)
                {
                    selectedItem = null;
                    return; //stay in method but not in if statement?
                }
                ShowItem();
            }
            else
            {
                itemShow.SetActive(false);
            }
        }
        #endregion
        #region Functions
        public virtual void AddItem(int _id, int _amount = 1)
        {
            Item _item = (inventory.Find(items => items.ID == _id));

            if (_item != null)
            {
                _item.Amount += _amount;
            }
            else
            {
                inventory.Add(ItemData.CreateItem(_id));
            }
            SortAndShowInventory();
        }
        public virtual void RemoveItem(int _amount = 1)
        {
            if (selectedItem.Amount < 1)
            {
                Debug.LogError("Less than 1 item, something's wrong.");
            }
            else if (selectedItem.Amount > _amount) //if there are more items then are being removed
            {
                selectedItem.Amount -= _amount; //remove amount
            }
            else
            {
                inventory.Remove(selectedItem);
                selectedItem = null;
                Destroy(selectedButton);
            }
            SortAndShowInventory();
        }
        public virtual void ShowItem()
        {
            itemShow.SetActive(true);
            itemName.text = selectedItem.Name;
            itemIcon.sprite = selectedItem.Icon;
            itemDescription.text = selectedItem.Description+"\n\nSell Value: $"+(selectedItem.Value/2).ToString();
        }
        public virtual void SortAndShowInventory()
        {
            if (itemButtons != null)
            {
                for (int i = 0; i < itemButtons.Count; i++)
                {
                    Destroy(itemButtons[i]);
                }
                itemButtons.Clear();
            }

            for (int i = 0; i < inventory.Count; i++)
            {
                GameObject newButton = Instantiate(itemButtonPrefab, buttonParent);
                newButton.GetComponentInChildren<Text>().text = inventory[i].Name + ": " + inventory[i].Amount.ToString();
                Item _item = inventory[i];
                newButton.GetComponent<Button>().onClick.AddListener(() => SelectItem(_item, newButton));
                newButton.name = inventory[i].Name;

                itemButtons.Add(newButton);
            }
        }
        protected virtual void SelectItem(Item item, GameObject button)
        {
            selectedItem = item;
            selectedButton = button;
        }
        #endregion
    }
}