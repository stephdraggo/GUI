using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace GUI1
{
    [AddComponentMenu("GUI/Save and Load Player Prefs")]
    public class SaveAndLoadPlayerPrefs : MonoBehaviour
    {
        #region Variables
        [Header("Reference Variables")]
        public AudioMixer mixer;
        public Dropdown qualityDropdown, resolutionDropdown;
        public Toggle muteToggle, fullscreenToggle;
        public Slider musicSlider, sfxSlider;
        public KeyBind keybind;
        #endregion

        void Start()
        {
            if (!PlayerPrefs.HasKey("fullscreen")) //if there are no saved options
            {
                DefaultOptions(); //set saved options to default
            }

            LoadOptions(); //load saved options
        }
        public void SaveOptions()
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
            #region quality done
            PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel()); //set value to current quality level
            #endregion
            #region audio done
            float volume; //temporary variable

            mixer.GetFloat("MasterVolume", out volume); //outputs bool and modifies (out) volume variable
            PlayerPrefs.SetFloat("masterVolume", volume); //save master volume to temporary volume variable

            mixer.GetFloat("MusicVolume", out volume); //outputs bool and modifies (out) volume variable
            PlayerPrefs.SetFloat("musicVolume", volume); //save music volume to temporary volume variable

            mixer.GetFloat("SFXVolume", out volume); //outputs bool and modifies (out) volume variable
            PlayerPrefs.SetFloat("sfxVolume", volume); //save sfx volume to temporary volume variable
            #endregion
            #region resolution done
            PlayerPrefs.SetInt("resolutionWidth", Screen.currentResolution.width);
            PlayerPrefs.SetInt("resolutionHeight", Screen.currentResolution.height);

            Debug.Log("Saving: " + PlayerPrefs.GetInt("resolutionWidth") + " * " + PlayerPrefs.GetInt("resolutionHeight"));
            #endregion


            PlayerPrefs.Save(); //save options
        }
        public void LoadOptions()
        {
            #region fullscreen done
            bool fullScreenRes;
            if (PlayerPrefs.GetInt("fullscreen") == 1) //if saved option is true(1)
            {
                fullscreenToggle.isOn = true; //change toggle to on
                Screen.fullScreen = true; //set screen to fullscreen
                fullScreenRes = true;
            }
            else //if saved option is false(0)
            {
                fullscreenToggle.isOn = false; //change toggle to off
                Screen.fullScreen = false; //set screen to windowed
                fullScreenRes = false;
            }
            #endregion
            #region quality done
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality")); //set quality to saved quality value
            qualityDropdown.value = PlayerPrefs.GetInt("quality"); //update dropdown to match quality level
            #endregion
            #region audio done
            mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("masterVolume")); //set master volume to saved value (0 or -80)

            mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("musicVolume")); //set music volume to saved value
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume"); //set music slider ui to saved value

            mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("sfxVolume")); //set sfx volume to saved value
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume"); //set sfx slider ui to saved value

            if (PlayerPrefs.GetFloat("masterVolume") > -70f) //if master volume is greater than muted
            {
                muteToggle.isOn = false; //set mute toggle ui to unticked
            }
            else //if master volume is muted
            {
                muteToggle.isOn = true; //set mute toggle ui to ticked
            }
            #endregion
            #region resolution done
            Debug.Log("Loading: " + PlayerPrefs.GetInt("resolutionWidth") + " * " + PlayerPrefs.GetInt("resolutionHeight"));
            Screen.SetResolution(PlayerPrefs.GetInt("resolutionWidth"), PlayerPrefs.GetInt("resolutionHeight"), fullScreenRes);
            #endregion


        }
        public void DefaultOptions()
        {
            #region default options
            PlayerPrefs.SetInt("fullscreen", 0); //default is windowed

            PlayerPrefs.SetInt("quality", 3); //default quality is high

            PlayerPrefs.SetFloat("masterVolume", 0f); //default master volume
            PlayerPrefs.SetFloat("musicVolume", 0f); //default music volume
            PlayerPrefs.SetFloat("sfxVolume", 0f); //default sfx volume

            PlayerPrefs.SetInt("resolutionWidth", 1600); //these stop it from crashing on start bc 0 resolution
            PlayerPrefs.SetInt("resolutionHeight", 900);

            #endregion

            PlayerPrefs.Save(); //save default
        }
    }
}

