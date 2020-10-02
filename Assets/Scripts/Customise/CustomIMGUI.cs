using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI1
{
    [AddComponentMenu("GUI/Customisation/IMGUI (prototype only)")]
    public class CustomIMGUI : MonoBehaviour
    {
        #region Variables
        [Tooltip("1/160 of screen width and 1/90 screen height")]
        private float _scrX, _scrY;

        [Tooltip("Array of visual customising strings.")]
        private string[] _names;

        [Tooltip("Array of texture lists. There are 6 lists, this will not change.")]
        public List<Texture2D>[] textures = new List<Texture2D>[6];
        #endregion
        #region Start
        private void Start()
        {
            _names = new string[6] { "Skin", "Hair", "Eyes", "Mouth", "Clothes", "Armour" };



            StartTexture();

        }
        #endregion
        #region OnGUI
        private void OnGUI()
        {
            #region calculate screen dimensions
            _scrX = Screen.width / 160;
            _scrY = Screen.height / 90;

            #endregion
            #region appearance
            GUI.Label(new Rect(_scrX, _scrY, 20 * _scrX, _scrY * 3), "Customise Appearance");

            for (int i = 0; i < _names.Length; i++)
            {
                if (GUI.Button(new Rect(_scrX, _scrY * (i + 1) * 4, _scrX * 3, _scrY * 3), "<"))
                {
                    SetTexture(_names[i], -1);
                }

                GUI.Label(new Rect(5 * _scrX, _scrY * (i + 1) * 4, 10 * _scrX, 3 * _scrY), _names[i]);

                if (GUI.Button(new Rect(18 * _scrX, _scrY * (i + 1) * 4, _scrX * 3, _scrY * 3), ">"))
                {
                    SetTexture(_names[i], 1);
                }
            }
            #endregion
        }
        #endregion
        #region Functions
        /// <summary>
        /// Creates lists of textures and fills them with the available textures.
        /// </summary>
        void StartTexture()
        {
            for (int i = 0; i < _names.Length; i++) //for every texture type
            {
                textures[i] = new List<Texture2D>(); //make the list

                int index = 0; //start at index 0
                Texture2D tempTexture; //create temporary texture
                do
                {
                    tempTexture = (Texture2D)Resources.Load("Character/" + _names[i] + "_" + index);

                    if (tempTexture != null)
                    {
                        textures[i].Add(tempTexture);
                        Debug.Log("Added texture: " + _names[i] + "_" + index);
                    }

                    index++;
                } while (tempTexture != null); //go back to "do" while the temp texture is not null
            }
        }
        void SetTexture(string type, int dir)
        {
            switch (type)
            {
                case "Skin":
                    //set texture
                    break;
                case "Hair":
                    //set texture
                    break;
                case "Eyes":
                    //set texture
                    break;
                case "Mouth":
                    //set texture
                    break;
                case "Clothes":
                    //set texture
                    break;
                case "Armour":
                    //set texture
                    break;



                default:
                    break;
            }
        }
        #endregion
    }
}