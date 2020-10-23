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

        [SerializeField, Tooltip("Array of visual customising strings.")]
        private string[] _names;

        [Tooltip("Array of texture lists. There are 6 lists, this will not change.")]
        public List<Texture2D>[] textures = new List<Texture2D>[6];

        [Tooltip("Index of current texture: skin, hair, eyes, mouth, clothes, armour.")]
        public int[] textureID = new int[6];

        [Tooltip("Reference to character renderer.")]
        public Renderer characterRenderer;
        #endregion
        #region Start
        private void Start()
        {
            _names = new string[6] { "Skin", "Hair", "Eyes", "Mouth", "Clothes", "Armour" };


            StartTexture();

            if (PlayerPrefs.GetString("Saved") == null)
            {
                DefaultCharacter();
            }
            LoadCharacter();
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
            GUI.Label(new Rect(_scrX, _scrY, 20 * _scrX, _scrY * 3), "Customise Appearance"); //title box

            for (int i = 0; i < _names.Length; i++) //for every texture type
            {
                if (GUI.Button(new Rect(_scrX, _scrY * (i + 1) * 4, _scrX * 3, _scrY * 3), "<")) //make back button
                {
                    SetTexture(_names[i], -1); //
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

            

            switch (type)
            {
                case "Skin":
                    matIndex = 1;
                    Debug.Log("affect skin");
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
            textureID[matIndex] += dir; //basic change based on input
            if (textureID[matIndex] < 0) //if the new value is less than 0
            {
                textureID[matIndex] = textures[matIndex].Count - 1; //change to last index of the relevant texture list
            }
            else if (textureID[matIndex] > textures[matIndex].Count - 1) //if the index excedes the texture list
            {
                textureID[matIndex] = 0; //set to first texture
            }
            #endregion


            Material[] mats = characterRenderer.materials; //get the array of materials from the object

            mats[matIndex].mainTexture = textures[matIndex][textureID[matIndex]]; //change the specified material's texture to the new texture
            characterRenderer.materials[matIndex] = mats[matIndex]; //load the changed material onto the object
        }
        #endregion

        #region Save
        public void SaveCharacter()
        {
            PlayerPrefs.SetString("Saved", "Yes");

            //save textures
            PlayerPrefs.SetInt("Skin", textureID[0]);
            PlayerPrefs.SetInt("Hair", textureID[1]);
            PlayerPrefs.SetInt("Eyes", textureID[2]);
            PlayerPrefs.SetInt("Mouth", textureID[3]);
            PlayerPrefs.SetInt("Clothes", textureID[4]);
            PlayerPrefs.SetInt("Armour", textureID[5]);



            PlayerPrefs.Save();
        }
        public void LoadCharacter()
        {
            //load textures
            textureID[0] = PlayerPrefs.GetInt("Skin");
            textureID[1] = PlayerPrefs.GetInt("Hair");
            textureID[2] = PlayerPrefs.GetInt("Eyes");
            textureID[3] = PlayerPrefs.GetInt("Mouth");
            textureID[4] = PlayerPrefs.GetInt("Clothes");
            textureID[5] = PlayerPrefs.GetInt("Armour");


        }
        public void DefaultCharacter()
        {
            for (int i = 0; i < textureID.Length; i++)
            {
                textureID[i] = 0;
            }

            SaveCharacter();
        }
        #endregion
    }
}