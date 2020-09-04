using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    [AddComponentMenu("GUI/KeyBinds")]
    public class KeyBind : MonoBehaviour
    {
        #region Variables
        public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>(); //static dictionary containing keycodes and their reference names
        public Text forward, backward, left, right, jump, crouch, sprint, inventory, interact, pause;
        public GameObject currentKey;
        public Color selectedKey, changedKey, white;
        #endregion
        void Start()
        {
            DefaultKeyBinds(); //set default keys

            LoadKeys();
            


            UpdateKeyBindUI(); //update ui to match keybinds

        }

        void Update()
        {

        }

        void OnGUI()
        {
            string newKey = "";
            Event e = Event.current;
            if (currentKey != null)
            {
                currentKey.GetComponent<Image>().color = selectedKey; //set button colour to selected
                if (e.isKey) //if any key is pressed
                {
                    newKey = e.keyCode.ToString(); //get the keycode as string
                }
                #region shift key patch
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    newKey = "LeftShift";
                }
                if (Input.GetKey(KeyCode.RightShift))
                {
                    newKey = "RightShift";
                }
                #endregion
                if (newKey != "") //if new key is not null
                {
                    keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey); //set dictionary reference
                    currentKey.GetComponentInChildren<Text>().text = newKey; //attach the new key text element
                    currentKey.GetComponent<Image>().color = changedKey; //set button colour to changed
                    currentKey = null; //reset current key
                }
            }
        }
        #region Functions
        public void SaveKeys()
        {
            foreach (var key in keys) //for each key in the keys dictionary
            {
                PlayerPrefs.SetString(key.Key, key.Value.ToString()); //save the strings of the key tags and values
            }
        }
        public void LoadKeys()
        {
            Debug.Log("Keys almost loaded: " + keys.Count);
            List<string> keyskeys = new List<string>(keys.Keys);
            foreach (string key in keyskeys)
            {

           
                //keys[key.Key] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key.Key.ToString())); //set dictionary reference

                KeyBind.keys[key] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key, keys[key].ToString()));
                //keys[key](key.Key, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key.Key.ToString(), key.Value.ToString())));
                Debug.Log("Keys loaded");
            }

        }
        public void DefaultKeyBinds()
        {
            //add default keys with code and tag to dictionary keys
            keys.Add("Forward", KeyCode.W);
            keys.Add("Backward", KeyCode.S);
            keys.Add("Left", KeyCode.A);
            keys.Add("Right", KeyCode.D);
            keys.Add("Jump", KeyCode.Space);
            keys.Add("Crouch", KeyCode.LeftControl);
            keys.Add("Sprint", KeyCode.LeftShift);
            keys.Add("Inventory", KeyCode.I);
            keys.Add("Interact", KeyCode.E);
            keys.Add("Pause", KeyCode.P);
        }
        public void UpdateKeyBindUI()
        {
            //sets ui text to string of keycode tagged
            forward.text = keys["Forward"].ToString();
            backward.text = keys["Backward"].ToString();
            left.text = keys["Left"].ToString();
            right.text = keys["Right"].ToString();
            jump.text = keys["Jump"].ToString();
            crouch.text = keys["Crouch"].ToString();
            sprint.text = keys["Sprint"].ToString();
            inventory.text = keys["Inventory"].ToString();
            interact.text = keys["Interact"].ToString();
            pause.text = keys["Pause"].ToString();
        }
        public void ChangeKey(GameObject clickedKey)
        {
            if (currentKey == null | currentKey == clickedKey)
            {
                currentKey = clickedKey;
            }
            else
            {
                currentKey.GetComponent<Image>().color = white;
                currentKey = clickedKey;
            }
        }

        #endregion
    }
}
