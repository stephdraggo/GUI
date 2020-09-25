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
        public GameObject pausePanel, optionsPanel;
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
            if (Input.GetKeyDown(KeyBind.keys["Pause"])||Input.GetKeyDown(KeyCode.Escape)) //if pause key is pressed
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
        }

        #region Functions
        public void Resume()
        {
            paused = false; //set bool to not paused
            Time.timeScale = 1; //set time going
            Cursor.lockState = CursorLockMode.Locked; //lock cursor

            if (optionsPanel.activeSelf) //if in options panel
            {
                optionsPanel.SetActive(false); //disable options panel
            }
            else //if in pause panel
            {
                pausePanel.SetActive(false); //disable pause menu
            }
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