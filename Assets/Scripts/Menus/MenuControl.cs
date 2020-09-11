using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gui
{
    [AddComponentMenu("GUI/Menu Control")]
    public class MenuControl : MonoBehaviour
    {
        #region Variables
        [Header("Reference Variables")]
        public GameObject placeHolderShhh;
        #endregion



        #region Functions
        public void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
        }
        public void ChangeScene(int i)
        {
            SceneManager.LoadScene(i);
        }




        /// <summary>My own thing I'm figuring out for fun, not for actual use.</summary>
        /// <param name="H">Ideally a KeyCode somehow.</param>
        /// <param name="thingToToggle"></param>
        public void ToggleWithKey(KeyCode H, GameObject thingToToggle)
        {
            if (Input.GetKeyDown(H)) //
            {
                if (thingToToggle.activeSelf) //if active
                {
                    thingToToggle.SetActive(false); //deactivate
                }
                else //if inactive
                {
                    thingToToggle.SetActive(true); //activate
                }
            }
        }
        #endregion
    }
}