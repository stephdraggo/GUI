using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI1
{
    [AddComponentMenu("GUI/Customisation/Visuals")]
    public class CustomIMGUI : MonoBehaviour
    {
        #region Variables
        [Tooltip("1/80 of screen width and 1/45 screen height, for OnGUI only.")]
        private float _scrX, _scrY;

        [SerializeField, Tooltip("Array of visual customising strings.")]
        protected string[] _names;

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

        #region OnGUI, not used
        /*
        private void OnGUI()
        {
            #region calculate screen dimensions
            _scrX = Screen.width / 80;
            _scrY = Screen.height / 45;

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
        */
        #endregion

        #region Functions
        #region canvas functions
        public void SetTextureNext(string _type)
        {
            SetTexture(_type, 1);
        }
        public void SetTextureBack(string _type)
        {
            SetTexture(_type, -1);
        }
        public void RandomTextures()
        {
            for (int i = 0; i < textureID.Length; i++)
            {
                textureID[i] = Random.Range(0, textures[i].Count);
                SetTexture(_names[i].ToString(), textureID[i]);
            }
        }
        #endregion
        #region start texture
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
        #endregion
        #region set texture
        /// <summary>
        /// Cycles through the given texture type's index in the given direction
        /// </summary>
        /// <param name="_type">texture type being affected</param>
        /// <param name="_dir">direction to change the index in</param>
        void SetTexture(string _type, int _dir)
        {
            int matIndex = 0;

            switch (_type)
            {
                case "Skin":
                    matIndex = 0;
                    break;
                case "Hair":
                    matIndex = 1;
                    break;
                case "Eyes":
                    matIndex = 2;
                    break;
                case "Mouth":
                    matIndex = 3;
                    break;
                case "Clothes":
                    matIndex = 4;
                    break;
                case "Armour":
                    matIndex = 5;
                    break;



                default:
                    break;
            }

            #region directional value
            textureID[matIndex] += _dir; //basic change based on input
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
            mats[matIndex + 1].mainTexture = textures[matIndex][textureID[matIndex]]; //change the specified material's texture to the new texture
            characterRenderer.materials[matIndex + 1] = mats[matIndex + 1]; //load the changed material onto the object
        }
        #endregion
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
                SetTexture(_names[i].ToString(), textureID[i]);
            }

            SaveCharacter();
        }
        #endregion
    }
}