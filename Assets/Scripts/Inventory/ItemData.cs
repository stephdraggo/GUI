using UnityEngine;

namespace GUI3.Inventories
{
    public static class ItemData
    {
        public static Item CreateItem(int _itemID)
        {
            string _name = "";
            string _description = "";
            int _value = 0;
            int _amount = 0;
            string _icon = "";
            string _mesh = "";
            ItemType _type = ItemType.Consumable;
            int _effect = 0;
            switch (_itemID)
            {
                #region Food 0 - 99
                case 0:
                    _name = "Apple";
                    _description = "Munchies and Crunchies";
                    _value = 1;
                    _amount = 1;
                    _icon = "Food/Apple";
                    _mesh = "Food/Apple";
                    _type = ItemType.Consumable;
                    _effect = 10;
                    break;
                case 1:
                    _name = "Meat";
                    _description = "Steamed Hams";
                    _value = 10;
                    _amount = 1;
                    _icon = "Food/Meat";
                    _mesh = "Food/Meat";
                    _type = ItemType.Consumable;
                    _effect = 25;
                    break;
                #endregion
                #region Weapon 100 - 199
                case 100:
                    _name = "Axe";
                    _description = "AXE is AXE";
                    _value = 150;
                    _amount = 1;
                    _icon = "Weapon/Axe";
                    _mesh = "Weapon/Axe";
                    _type = ItemType.Weapon;
                    _effect = 50;
                    break;
                case 101:
                    _name = "Bow";
                    _description = "Pew Pew";
                    _value = 75;
                    _amount = 1;
                    _icon = "Weapon/Bow";
                    _mesh = "Weapon/Bow";
                    _type = ItemType.Weapon;
                    _effect = 15;

                    break;
                case 102:
                    _name = "Sword";
                    _description = "Stick'em with the pointy end";
                    _value = 200;
                    _amount = 1;
                    _icon = "Weapon/Sword";
                    _mesh = "Weapon/Sword";
                    _type = ItemType.Weapon;
                    _effect = 30;

                    break;
                #endregion
                #region Apparel 200 - 299
                case 200:
                    _name = "Armour";
                    _description = "Very useful for keeping your inside things inside you";
                    _value = 75;
                    _amount = 1;
                    _icon = "Apparel/Armour/Armour";
                    _mesh = "Apparel/Armour/Armour";
                    _type = ItemType.Wearable;
                    _effect = 45;
                    break;
                case 201:
                    _name = "Boots";
                    _description = "100% effective against foot related tetnus";
                    _value = 20;
                    _amount = 1;
                    _icon = "Apparel/Armour/Boots";
                    _mesh = "Apparel/Armour/Boots";
                    _type = ItemType.Wearable;
                    _effect = 10;
                    break;
                case 202:
                    _name = "Braces";
                    _description = "You can try and do what Wonder Woman can, but it probably wont end well";
                    _value = 20;
                    _amount = 1;
                    _icon = "Apparel/Armour/Braces";
                    _mesh = "Apparel/Armour/Braces";
                    _type = ItemType.Wearable;
                    _effect = 10;
                    break;
                case 203:
                    _name = "Gloves";
                    _description = "You can try and do what Wonder Woman can, but it probably wont end well";
                    _value = 25;
                    _amount = 1;
                    _icon = "Apparel/Armour/Gloves";
                    _mesh = "Apparel/Armour/Gloves";
                    _type = ItemType.Wearable;
                    _effect = 15;
                    break;
                case 204:
                    _name = "Helmet";
                    _description = "Technically' prevents brain injuries, but the science hasnt come back on that";
                    _value = 40;
                    _amount = 1;
                    _icon = "Apparel/Armour/Helmet";
                    _mesh = "Apparel/Armour/Helmet";
                    _type = ItemType.Wearable;
                    _effect = 35;
                    break;
                case 205:
                    _name = "Pauldrons";
                    _description = "Pointy Shoulder Pads";
                    _value = 18;
                    _amount = 1;
                    _icon = "Apparel/Armour/Pauldrons";
                    _mesh = "Apparel/Armour/Pauldrons";
                    _type = ItemType.Wearable;
                    _effect = 8;
                    break;
                case 206:
                    _name = "Shield";
                    _description = "Point it in the general direction of danger and it 'should' work";
                    _value = 35;
                    _amount = 1;
                    _icon = "Apparel/Armour/Shield";
                    _mesh = "Apparel/Armour/Shield";
                    _type = ItemType.Wearable;
                    _effect = 30;
                    break;
                case 207:
                    _name = "Belt";
                    _description = "Keeps your pants up";
                    _value = 5;
                    _amount = 1;
                    _icon = "Apparel/Belt";
                    _mesh = "Apparel/Belt";
                    _type = ItemType.Wearable;
                    break;
                case 208:
                    _name = "Cloak";
                    _description = "Flappy Flappy Cape...NO CAPES!";
                    _value = 25;
                    _amount = 1;
                    _icon = "Apparel/Cloak";
                    _mesh = "Apparel/Cloak";
                    _type = ItemType.Wearable;
                    break;
                case 209:
                    _name = "Necklace";
                    _description = "Sparkles";
                    _value = 50;
                    _amount = 1;
                    _icon = "Apparel/Necklace";
                    _mesh = "Apparel/Necklace";
                    _type = ItemType.Wearable;
                    break;
                case 210:
                    _name = "Pants";
                    _description = "FOR THE LOVE OF GOD PUT PANTS ON";
                    _value = 5;
                    _amount = 1;
                    _icon = "Apparel/Pants";
                    _mesh = "Apparel/Pants";
                    _type = ItemType.Wearable;
                    break;
                case 211:
                    _name = "Ring";
                    _description = "Symbol of Stockholm shops";
                    _value = 500;
                    _amount = 1;
                    _icon = "Apparel/Ring";
                    _mesh = "Apparel/Ring";
                    _type = ItemType.Wearable;
                    break;
                #endregion
                #region Crafting 300 - 399
                case 300:
                    _name = "Gem";
                    _description = "Priceless";
                    _value = 400;
                    _amount = 1;
                    _icon = "Crafting/Gem";
                    _mesh = "Crafting/Gem";
                    _type = ItemType.Crafting;
                    break;
                case 301:
                    _name = "Ingot";
                    _description = "Bar of Iron";
                    _value = 10;
                    _amount = 1;
                    _icon = "Crafting/Ingot";
                    _mesh = "Crafting/Ingot";
                    _type = ItemType.Crafting;
                    break;
                #endregion
                #region Ingredients 400 - 499

                #endregion
                #region Potions 500 - 599
                case 500:
                    _name = "Health Potion";
                    _description = "Liquid Life";
                    _value = 50;
                    _amount = 1;
                    _icon = "Potions/HealthPotion";
                    _mesh = "Potions/HealthPotion";
                    _type = ItemType.Potions;
                    _effect = 25;
                    break;
                case 501:
                    _name = "Mana Potion";
                    _description = "Liquid Magic";
                    _value = 50;
                    _amount = 1;
                    _icon = "Potions/ManaPotion";
                    _mesh = "Potions/ManaPotion";
                    _type = ItemType.Potions;
                    _effect = 25;
                    break;
                #endregion
                #region Scrolls 600 - 699
                case 600:
                    _name = "Book of the Dead";
                    _description = "Book that summons minions";
                    _value = 5000;
                    _amount = 1;
                    _icon = "Scrolls/Book";
                    _mesh = "Scrolls/Book";
                    _type = ItemType.Scrolls;
                    break;
                case 601:
                    _name = "Fireball Scroll";
                    _description = "Scroll that summons a fireball....lets hope not on you";
                    _value = 1000;
                    _amount = 1;
                    _icon = "Scrolls/Scroll";
                    _mesh = "Scrolls/Scroll";
                    _type = ItemType.Scrolls;
                    break;
                #endregion
                #region Quest 700 - 799

                #endregion
                #region Misc 800 - 899
                case 800:
                    _name = "Coin";
                    _description = "Clink Clink";
                    _value = 1;
                    _amount = 1;
                    _icon = "Coins";
                    _mesh = "Coins";
                    _type = ItemType.Money;
                    break;
                #endregion

                default:
                    _itemID = 0;
                    _name = "Apple";
                    _description = "Munchies and Crunchies";
                    _value = 1;
                    _amount = 1;
                    _icon = "Food/Apple.png";
                    _mesh = "Food/Apple";
                    _type = ItemType.Consumable;
                    _effect = 10;
                    break;
            }
            Item temp = new Item
            {
                ID = _itemID,
                Name = _name,
                Description = _description,
                Value = _value,
                Amount = _amount,
                Type = _type,
                Icon = Resources.Load<Sprite>("Icon/" + _icon),
                Mesh = Resources.Load("Mesh/" + _mesh) as GameObject,
                EffectAmount = _effect
            };
            return temp;
        }
    }
}