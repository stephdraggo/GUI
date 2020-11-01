using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI3.Inventories
{
    public class Item
    {
        #region Private Variables
        [SerializeField] private int id;
        [SerializeField] private string name;
        [SerializeField] private string description;
        [SerializeField] private int eValue;
        [SerializeField] private int amount;
        [SerializeField] private Texture2D icon;
        [SerializeField] private GameObject mesh;
        [SerializeField] private ItemType type;
        [SerializeField] private int effectAmount;
        #endregion

        #region Public Properties
        public int ID
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Description
        {
            get => description;
            set => description = value;
        }
        public int Value
        {
            get => eValue;
            set => eValue = value;
        }
        public int Amount
        {
            get => amount;
            set => amount = value;
        }
        public Texture2D Icon
        {
            get => icon;
            set => icon = value;
        }
        public GameObject Mesh
        {
            get => mesh;
            set => mesh = value;
        }
        public ItemType Type
        {
            get => type;
            set => type = value;
        }
        /// <summary>Damage, Armour or Heal amount depending on item type.</summary>
        public int EffectAmount
        {
            get => effectAmount;
            set => effectAmount = value;
        }
        #endregion
    }

    public enum ItemType
    {
        Food,
        Weapon,
        Apparel,
        Crafting,
        Ingredients,
        Potions,
        Scrolls,
        Quest,
        Money,
    }
}