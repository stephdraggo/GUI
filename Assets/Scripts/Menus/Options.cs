using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Gui
{
    [AddComponentMenu("GUI/Options")]
    public class Options : MonoBehaviour
    {
        #region Variables
        public AudioMixer mixer;
        #endregion

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
        #region audio
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
        #endregion
    }
}