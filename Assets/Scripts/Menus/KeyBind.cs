using System.Collections;
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
            if (!keys.ContainsKey("Forward")) //if no keybinds are saved
            {
                DefaultKeyBinds(); //set default keys
            }

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
                currentKey.GetComponent<Image>().color = selectedKey;
                if (e.isKey) //if any key is pressed
                {
                    newKey = e.keyCode.ToString(); //get the keycode as string
                }
                if (Input.GetKey(KeyCode.LeftShift)) //
                {
                    newKey = "LeftShift";
                }
                if (Input.GetKey(KeyCode.RightShift))
                {
                    newKey = "RightShift";
                }
                if (newKey != "")
                {
                    keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                    currentKey.GetComponentInChildren<Text>().text = newKey;
                    currentKey.GetComponent<Image>().color = changedKey;
                    currentKey = null;
                }
            }



        }
        #region Functions
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


/*
 
     void OnGUI(){
     
     Event e = Event.current;

                if (e.isKey) //if any key is pressed
                {
                    if (e.keyCode == KeyCode.W) //if the key is W
                    {

                    }
                }
     
     }
     
     */
