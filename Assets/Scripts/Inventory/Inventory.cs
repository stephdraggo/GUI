using GUI1;
using System.Linq; //conCAT
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GUI3.Inventories
{
    public class Inventory : MonoBehaviour
    {
        #region Variables
        [Header("Inventory Variables")]
        #region general inventory info
        public List<Item> inventory = new List<Item>();
        public Item selectedItem;
        public GameObject selectedButton;
        [SerializeField] private PlayerControl player;
        public static int money;
        #endregion

        [Header("Shown Item Variables")]
        #region item display
        public GameObject itemShow;
        public Text itemName;
        public Image itemIcon;
        public Text itemDescription;
        public Button useButton;
        public Text buttonText;
        #endregion

        [Header("Display Variables")]
        public GameObject itemButtonPrefab;
        public Transform buttonParent;
        private string sortType = "";
        private string[] sortByType;
        private List<GameObject> itemButtons;

        public GameObject itemPrefab;
        public Transform itemParent;

        [Header("Equipment")]
        public Equipment[] equipmentSlots;

        [System.Serializable]
        public struct Equipment
        {
            public string slotName;
            public Transform equipLocation;
            public GameObject currentlyEquipped;
            public Item item;
        }

        #endregion

        void Start()
        {
            player = gameObject.GetComponent<PlayerControl>();

            #region get array of sorting types
            string[] first = new string[] { "All" };
            string[] second = System.Enum.GetNames(typeof(ItemType));
            string[] sortByType = first.Concat(second).ToArray();
            #endregion

            #region add some default items
            //add some items in here (theoretically could have one of each item)
            inventory.Add(ItemData.CreateItem(Random.Range(0, 2)));
            inventory.Add(ItemData.CreateItem(Random.Range(0, 2)));
            inventory.Add(ItemData.CreateItem(Random.Range(100, 103)));
            inventory.Add(ItemData.CreateItem(Random.Range(100, 103)));
            inventory.Add(ItemData.CreateItem(Random.Range(100, 103)));
            inventory.Add(ItemData.CreateItem(Random.Range(200, 212)));
            inventory.Add(ItemData.CreateItem(Random.Range(300, 302)));
            inventory.Add(ItemData.CreateItem(Random.Range(300, 302)));
            inventory.Add(ItemData.CreateItem(Random.Range(500, 502)));
            inventory.Add(ItemData.CreateItem(Random.Range(500, 502)));
            inventory.Add(ItemData.CreateItem(Random.Range(600, 602)));
            inventory.Add(ItemData.CreateItem(Random.Range(600, 602)));
            #endregion

        }

        void Update()
        {
            if (selectedItem != null)
            {
                ShowItem();
            }
            else
            {
                itemShow.SetActive(false);
            }
        }
        #region Functions
        public Item FindItem(int _id)
        {
            return inventory.Find(items => items.ID == _id);
        }
        public void AddItem(Item item)
        {
            Item foundItem = inventory.Find(items => items.ID == item.ID);
            if (foundItem != null)
            {
                foundItem.Amount += item.Amount;
            }
            else
            {
                inventory.Add(item);
            }
        }
        public void ShowItem()
        {
            #region display item details
            itemShow.SetActive(true);
            itemName.text = selectedItem.Name;
            itemIcon.sprite = selectedItem.Icon;
            itemDescription.text = selectedItem.Description;
            #endregion

            #region set ui by type

            useButton.onClick.RemoveAllListeners(); //add specific listeners in switch
            switch (selectedItem.Type)
            {
                case ItemType.Consumable:
                    buttonText.text = "Consume";
                    useButton.onClick.AddListener(ConsumeItem);
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
                    useButton.onClick.AddListener(EquipItem);
                    break;

                case ItemType.Wearable:
                    buttonText.text = "Equip";
                    useButton.onClick.AddListener(EquipItem);
                    break;

                case ItemType.Crafting:
                    buttonText.text = "Use";
                    useButton.onClick.AddListener(UseItem);
                    break;

                case ItemType.Ingredients:
                    buttonText.text = "Use";
                    useButton.onClick.AddListener(UseItem);
                    break;

                case ItemType.Potions:
                    buttonText.text = "Consume";
                    useButton.onClick.AddListener(ConsumeItem);
                    break;

                case ItemType.Scrolls:
                    buttonText.text = "Use";
                    useButton.onClick.AddListener(UseItem);
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
            RidItem();
        }
        private void ConsumeItem()
        {
            //food, potions
            Debug.Log("Consumed " + selectedItem.Name);
            player.lifeForce[0].current += selectedItem.EffectAmount;
            RidItem();
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
            RidItem();
        }
        private void RidItem()
        {
            inventory.Remove(selectedItem);
            selectedItem = null;
            Destroy(selectedButton);
        }
        #endregion
        public void SortAndShowInventory()
        {
            // foreach (Item item in inventory)
            for (int i = 0; i < inventory.Count; i++)
            {
                GameObject newButton = Instantiate(itemButtonPrefab, buttonParent);
                newButton.GetComponentInChildren<Text>().text = inventory[i].Name + ": " + inventory[i].Amount.ToString();

                Item _item = inventory[i];
                newButton.GetComponent<Button>().onClick.AddListener(() => SelectItem(_item, newButton));

                newButton.name = inventory[i].Name;
            }
        }
        private void SelectItem(Item item, GameObject button)
        {
            selectedItem = item;
            selectedButton = button;
        }
        #endregion

    }

}
