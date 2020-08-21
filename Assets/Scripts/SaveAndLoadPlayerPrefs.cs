using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    [AddComponentMenu("GUI/Save and Load Player Prefs")]
    public class SaveAndLoadPlayerPrefs : MonoBehaviour
    {
        #region Variables
        public Toggle fullscreenToggle;
        public Dropdown qualityDropdown;
        #endregion

        public void Start()
        {
            if (!PlayerPrefs.HasKey("fullscreen")) //if there are no saved options
            {
                DefaultPlayerPrefs(); //set saved options to default
            }
            LoadPlayerPrefs(); //load saved options
        }
        public void SavePlayerPrefs()
        {
            #region fullscreen done
            if (Screen.fullScreen) //if in fullscreen
            {
                PlayerPrefs.SetInt("fullscreen", 1); //set value true(1)
            }
            else //if not in fullscreen
            {
                PlayerPrefs.SetInt("fullscreen", 0); //set value to false(0)
            }
            #endregion
            #region quality
            PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel()); //set value to current quality level
            #endregion
            #region resolution

            #endregion

            PlayerPrefs.Save(); //save options
        }

        public void LoadPlayerPrefs()
        {
            #region fullscreen done
            if (PlayerPrefs.GetInt("fullscreen") == 1) //if saved option is true(1)
            {
                fullscreenToggle.isOn = true; //change toggle to on
                Screen.fullScreen = true; //set screen to fullscreen
            }
            else //if saved option is false(0)
            {
                fullscreenToggle.isOn = false; //change toggle to off
                Screen.fullScreen = false; //set screen to windowed
            }
            #endregion
            #region quality
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality")); //set quality to saved quality value
            qualityDropdown.value = PlayerPrefs.GetInt("quality"); //update dropdown to match quality level
            #endregion
            #region resolution

            #endregion

        }
        public void DefaultPlayerPrefs()
        {
            PlayerPrefs.SetInt("fullscreen", 0); //default is windowed
            PlayerPrefs.SetInt("quality", 3); //default quality is high

            PlayerPrefs.Save(); //save default
        }
    }
}