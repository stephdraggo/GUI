using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gui
{
    [AddComponentMenu("GUI/Options")]
    public class Options : MonoBehaviour
    {


        public void SetFullscreen(bool F)
        {
            Screen.fullScreen = F;
        }
        public void ChangeQuality(int i)
        {
            QualitySettings.SetQualityLevel(i);
        }

    }
}