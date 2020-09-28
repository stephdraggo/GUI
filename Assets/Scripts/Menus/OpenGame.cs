using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI1
{
    [AddComponentMenu("GUI/Open Game")]
    public class OpenGame : MonoBehaviour
    {
        #region Variables
        [SerializeField, Tooltip("Connect all panels in this scene, main menu should be first.")]
        private GameObject[] otherPanels;
        #endregion
        void Start()
        {
            for (int i = 0; i < otherPanels.Length; i++) //for all the other panels
            {
                otherPanels[i].SetActive(false); //make sure they're closed
            }
        }

        void Update()
        {
            if (Input.anyKey) //if any key
            {
                otherPanels[0].SetActive(true); //enable main menu
                gameObject.SetActive(false); //disable this panel
            }
        }
    }
}