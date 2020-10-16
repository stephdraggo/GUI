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

        [SerializeField,Tooltip("Array of visual customising strings.")]
        private string[] _names;

        [Tooltip("Array of texture lists. There are 6 lists, this will not change.")]
        public List<Texture2D>[] textures = new List<Texture2D>[6];

        [Tooltip("Reference to character renderer.")]
        public Renderer characterRenderer;
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
                    tempTexture = (Texture2D)Resources.Load("Character/" + _names[i] + "_" + index); //locate the texture by path

                    if (tempTexture != null) //if that texture exists
                    {
                        textures[i].Add(tempTexture); //add to list
                    }

                    index++;

                } while (tempTexture != null); //go back to "do" while the temp texture is not null
            }
        }

        /// <summary>
        /// Cycles through the given texture type's index in the given direction
        /// </summary>
        /// <param name="type">texture type being affected</param>
        /// <param name="dir">direction to change the index in</param>
        void SetTexture(string type, int dir)
        {
            int matIndex = 0;
            int textureIndex = 0;

            Material[] mats = characterRenderer.materials;

            switch (type)
            {
                case "Skin":
                    matIndex = 1;
                    Debug.Log("affect skin");
                    //want to get the current skin texture as its index in the skin texture list

                    //textureIndex = mats[matIndex].mainTexture;
                    break;
                case "Hair":
                    matIndex = 2;
                    break;
                case "Eyes":
                    matIndex = 3;
                    break;
                case "Mouth":
                    matIndex = 4;
                    break;
                case "Clothes":
                    matIndex = 5;
                    break;
                case "Armour":
                    matIndex = 6;
                    break;



                default:
                    break;
            }

            #region directional value
            textureIndex += dir; //basic change based on input
            if (textureIndex < 0) //if the new value is less than 0
            {
                textureIndex = textures[matIndex].Count - 1; //change to last index of the relevant texture list
            }
            else if (textureIndex > textures[matIndex].Count - 1) //if the index excedes the texture list
            {
                textureIndex = 0; //set to first texture
            }
            #endregion



            
            mats[matIndex].mainTexture = textures[matIndex][textureIndex];
            characterRenderer.materials = mats;
        }
        #endregion
    }
}