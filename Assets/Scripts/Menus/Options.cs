using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace GUI1
{
    [AddComponentMenu("GUI/Options")]
    public class Options : MonoBehaviour
    {
        #region Variables
        public AudioMixer mixer;
        public Resolution[] resolutions;
        public Dropdown resolution;

        #endregion

        void Start()
        {
            StartResolution();
        }

        #region Functions
        #region fullscreen done
        public void SetFullscreen(bool F)
        {
            Screen.fullScreen = F;
        }
        #endregion
        #region quality done
        public void ChangeQuality(int i)
        {
            QualitySettings.SetQualityLevel(i);
        }
        #endregion
        #region audio done
        public void SetMusicVolume(float value)
        {
            mixer.SetFloat("MusicVolume", value);
        }
        public void SetSFXVolume(float value)
        {
            mixer.SetFloat("SFXVolume", value);
        }
        public void MuteToggle(bool mute)
        {
            if (mute)
            {
                mixer.SetFloat("MasterVolume", -80);
            }
            else
            {
                mixer.SetFloat("MasterVolume", 0);
            }
        }
        #endregion
        #region resolution done
        public void StartResolution()
        {
            resolutions = Screen.resolutions; //fill array with all possible resolutions for the current screen
            resolution.ClearOptions(); //clear selection
            List<string> options = new List<string>(); //empty list of options
            int index = 0; //reset index
            for (int i = 0; i < resolutions.Length; i++) //for all resolutions in array
            {
                string option = resolutions[i].width + "x" + resolutions[i].height; //make string based on resolution
                options.Add(option); //add string to options list
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) //if selected resolution is active resolution
                {
                    index = i; //set index to active resolution index
                }
            }
            resolution.AddOptions(options); //put list of options into dropdown ui
            resolution.value = index; //ui select current resolution
            resolution.RefreshShownValue(); //refresh display(?)
        }
        public void SetResolution(int index)
        {
            Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreenMode); //set selected resolution
        }
        #endregion
        #endregion
    }
}