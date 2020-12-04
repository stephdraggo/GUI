using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GUI1
{
    [AddComponentMenu("GUI/Pause Control")]
    public class PauseControl : MonoBehaviour
    {
        #region Variables
        [Header("Reference Variables")]
        public static bool paused;
        public GameObject pausePanel, optionsPanel, invPanel, dialoguePanel;
        public GUI3.Inventories.Inventory inventory;
        #endregion
        void Start()
        {
            Resume();
#if UNITY_EDITOR
            //make sure both panels are not active
            Resume();
#endif
        }

        void Update()
        {
            if (GameSystems.NPCs.BaseNPC.showDialogue)
            {
                dialoguePanel.SetActive(true);
                Pause();
            }
            else if(dialoguePanel.activeSelf)
            {
                dialoguePanel.SetActive(false);
                Resume();
            }
            if (Input.GetKeyDown(KeyBind.keys["Pause"]) || Input.GetKeyDown(KeyCode.Escape)) //if pause key or escape is pressed
            {
                if (paused) //if paused
                {
                    Resume();
                }
                else //if not paused
                {
                    Pause();
                }
            }

            if (Input.GetKeyDown(KeyBind.keys["Inventory"])) //if inventory key is pressed
            {
                if (!invPanel.activeSelf)
                {
                    ShowInv();
                }
                else
                {
                    Resume();
                }
            }
        }

        #region Functions
        public void ShowInv()
        {
            Pause();
            invPanel.SetActive(true); //acitvate inventory panel
            pausePanel.SetActive(false); //acitvate inventory panel
            inventory.SortAndShowInventory();
        }
        public void Resume()
        {
            paused = false; //set bool to not paused
            Time.timeScale = 1; //set time going
            Cursor.lockState = CursorLockMode.Locked; //lock cursor

            optionsPanel.SetActive(false); //disable options panel
            invPanel.SetActive(false); //disable inv panel
            pausePanel.SetActive(false); //disable pause menu
        }
        public void Pause()
        {
            paused = true; //set bool to paused
            Time.timeScale = 0; //stop time
            pausePanel.SetActive(true); //enable pause menu
            Cursor.lockState = CursorLockMode.None; //free cursor
        }
        #endregion
    }
}