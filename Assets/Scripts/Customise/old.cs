using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class old : MonoBehaviour
{
    #region Variables
    [Header("Character Class")]
    public CharacterClass charClass = CharacterClass.Fighter;
    public string[] selectedClass = new string[3];
    public int selectedIndex = 0; //not needed for Canvas


    [Header("Dropdown Menu")]
    public bool showDropDown;
    public Vector2 scrollPos;
    public string classButton = "";
    public int statPoints = 10;

    [Header("Texture List")]
    //list of textures for eyes, skin, etc
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes, mouth, hair, clothes, armour = new List<Texture2D>();
    [Header("Index")]
    //index for textures
    public int skinIndex;
    public int eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    [Header("Renderer")]
    //mesh renderer for character
    public Renderer characterRenderer;
    [Header("Max Index")]
    //max size of texture lists
    public int skinMax;
    public int eyesMax, mouthMax, hairMax, clothesMax, armourMax;
    #endregion
    #region Start
    void Start()
    {
        ChooseClass(0);
        selectedClass = new string[] { "Fighter", "Rogue", "Witch" };
        string[] tempName = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        for (int i = 0; i < tempName.Length; i++)
        {
            CharacterStats[i].name = tempName[i];
        }

        #region for loop for texture pulling
        #region Skin
        for (int i = 0; i < skinMax; i++) //go through all items in skin list
        {
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D; //grabs texture from folder
            skin.Add(temp); //adds texture to list
        }
        #endregion
        #region Eyes
        for (int i = 0; i < eyesMax; i++) //go through all items in eyes list
        {
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D; //grabs texture from folder
            eyes.Add(temp); //adds texture to list
        }
        #endregion
        #region Mouth
        for (int i = 0; i < mouthMax; i++) //go through all items in mouth list
        {
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D; //grabs texture from folder
            mouth.Add(temp); //adds texture to list
        }
        #endregion
        #region Hair
        for (int i = 0; i < hairMax; i++) //go through all items in hair list
        {
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D; //grabs texture from folder
            hair.Add(temp); //adds texture to list
        }
        #endregion
        #region Clothes
        for (int i = 0; i < clothesMax; i++) //go through all items in clothes list
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D; //grabs texture from folder
            clothes.Add(temp); //adds texture to list
        }
        #endregion
        #region Armour
        for (int i = 0; i < armourMax; i++) //go through all items in armour list
        {
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D; //grabs texture from folder
            armour.Add(temp); //adds texture to list
        }
        #endregion
        #endregion
        characterRenderer = GameObject.FindGameObjectWithTag("CharacterMesh").GetComponent<Renderer>(); //attach mesh renderer
        #region set textures on start
        //set each one to 0
        SetTexture("Skin", 0);
        SetTexture("Eyes", 0);
        SetTexture("Mouth", 0);
        SetTexture("Hair", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
        #endregion
    }
    #endregion
    void Update()
    {

    }
    void OnGUI()
    {
        Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
        int i = 0;
        #region Skin
        if (GUI.Button(new Rect(0.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), "<"))
        {
            SetTexture("Skin", -1);
        }
        GUI.Box(new Rect(0.75f * scr.x, (1 + i) * 0.5f * scr.y, 1.5f * scr.x, 0.5f * scr.y), "Skin");
        if (GUI.Button(new Rect(2.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), ">"))
        {
            SetTexture("Skin", 1);
        }
        #endregion
        i++;
        #region Eyes
        if (GUI.Button(new Rect(0.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), "<"))
        {
            SetTexture("Eyes", -1);
        }
        GUI.Box(new Rect(0.75f * scr.x, (1 + i) * 0.5f * scr.y, 1.5f * scr.x, 0.5f * scr.y), "Eyes");
        if (GUI.Button(new Rect(2.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), ">"))
        {
            SetTexture("Eyes", 1);
        }
        #endregion
        i++;
        #region Mouth
        if (GUI.Button(new Rect(0.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), "<"))
        {
            SetTexture("Mouth", -1);
        }
        GUI.Box(new Rect(0.75f * scr.x, (1 + i) * 0.5f * scr.y, 1.5f * scr.x, 0.5f * scr.y), "Mouth");
        if (GUI.Button(new Rect(2.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), ">"))
        {
            SetTexture("Mouth", 1);
        }
        #endregion
        i++;
        #region Hair
        if (GUI.Button(new Rect(0.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), "<"))
        {
            SetTexture("Hair", -1);
        }
        GUI.Box(new Rect(0.75f * scr.x, (1 + i) * 0.5f * scr.y, 1.5f * scr.x, 0.5f * scr.y), "Hair");
        if (GUI.Button(new Rect(2.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), ">"))
        {
            SetTexture("Hair", 1);
        }
        #endregion
        i++;
        #region Clothes
        if (GUI.Button(new Rect(0.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), "<"))
        {
            SetTexture("Clothes", -1);
        }
        GUI.Box(new Rect(0.75f * scr.x, (1 + i) * 0.5f * scr.y, 1.5f * scr.x, 0.5f * scr.y), "Clothes");
        if (GUI.Button(new Rect(2.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), ">"))
        {
            SetTexture("Clothes", 1);
        }
        #endregion
        i++;
        #region Armour
        if (GUI.Button(new Rect(0.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), "<"))
        {
            SetTexture("Armour", -1);
        }
        GUI.Box(new Rect(0.75f * scr.x, (1 + i) * 0.5f * scr.y, 1.5f * scr.x, 0.5f * scr.y), "Armour");
        if (GUI.Button(new Rect(2.25f * scr.x, (1 + i) * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), ">"))
        {
            SetTexture("Armour", 1);
        }
        #endregion

        #region Character Class
        i = 0;
        //height (1 + i) * 0.5f * scr.y
        if (GUI.Button(new Rect(13f * scr.x, (1 + i) * 0.5f * scr.y, 2f * scr.x, 0.5f * scr.y), classButton))
        {
            showDropDown = !showDropDown;
        }
        i++;
        if (showDropDown)
        {
            scrollPos = GUI.BeginScrollView(new Rect(13f * scr.x, (1 + i) * 0.5f * scr.y, 2f * scr.x, 0.5f * scr.y),
                scrollPos,
                new Rect(0, 0, 0, selectedClass.Length * 0.5f * scr.y), false, true);

            for (int j = 0; j < selectedClass.Length; j++)
            {
                if (GUI.Button(new Rect(0, 0.5f * scr.y * j, 1.75f * scr.x, 0.5f * scr.y), selectedClass[j]))
                {
                    ChooseClass(j);
                    classButton = selectedClass[j];
                    showDropDown = false;
                }
            }

            GUI.EndScrollView();
        }
        GUI.Box(new Rect(13f * scr.x, 1.5f * scr.y, 2f * scr.x, 0.5f * scr.y), "Points: " + statPoints);
        for (int k = 0; k < CharacterStats.Length; k++)
        {
            if (statPoints > 0)
            {
                //can spend points
                if (GUI.Button(new Rect(12.5f * scr.x, 2f * scr.y + k * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), "+"))
                {
                    statPoints--;
                    CharacterStats[k].tempValue++;
                }
            }
            GUI.Box(new Rect(13f * scr.x, 2f * scr.y + k * 0.5f * scr.y, 2 * scr.x, 0.5f * scr.y), CharacterStats[k].name + ": " + (CharacterStats[k].value + CharacterStats[k].tempValue));
            if (statPoints < 10 && CharacterStats[k].tempValue > 0)
            {
                //can subtract points
                if (GUI.Button(new Rect(15f * scr.x, 2f * scr.y + k * 0.5f * scr.y, 0.5f * scr.x, 0.5f * scr.y), "-"))
                {
                    statPoints++;
                    CharacterStats[k].tempValue--;
                }
            }
        }
        if (statPoints < 10)
        {
            if (GUI.Button(new Rect(13f * scr.x, 5f * scr.y, 2 * scr.x, 0.5f * scr.y), "Reset"))
            {
                statPoints = 10;
                for (int l = 0; l < CharacterStats.Length; l++)
                {
                    CharacterStats[l].tempValue = 0;
                }
            }
        }

        #endregion

        name = GUI.TextField(new Rect(7 * scr.x, 6.5f * scr.y, 2 * scr.x, 0.5f * scr.y), name);

        if (GUI.Button(new Rect(7 * scr.x, 7f * scr.y, 2 * scr.x, 0.5f * scr.y), "Save and Play"))
        {
            SaveCharacter();
            SceneManager.LoadScene(2);
        }
    }

    void SaveCharacter()
    {
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("MouthIndex", mouthIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
        PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
        PlayerPrefs.SetInt("ArmourIndex", armourIndex);

        PlayerPrefs.SetString("CharacterName", name);

        for (int i = 0; i < CharacterStats.Length; i++)
        {
            PlayerPrefs.SetInt(CharacterStats[i].name, (CharacterStats[i].value + CharacterStats[i].tempValue));
        }
        PlayerPrefs.SetString("CharacterClass", selectedClass[selectedIndex]);
    }

    void ChooseClass(int classIndex)
    {
        switch (classIndex)
        {
            case 0:
                CharacterStats[0].value = 15; //str
                CharacterStats[1].value = 10; //dex
                CharacterStats[2].value = 10; //con
                CharacterStats[3].value = 10; //int
                CharacterStats[4].value = 5; //wis
                CharacterStats[5].value = 15; //cha
                charClass = CharacterClass.Fighter;
                break;
            case 1:
                CharacterStats[0].value = 5;
                CharacterStats[1].value = 15;
                CharacterStats[2].value = 10;
                CharacterStats[3].value = 15;
                CharacterStats[4].value = 10;
                CharacterStats[5].value = 10;
                charClass = CharacterClass.Rogue;
                break;
            case 2:
                CharacterStats[0].value = 10;
                CharacterStats[1].value = 10;
                CharacterStats[2].value = 15;
                CharacterStats[3].value = 10;
                CharacterStats[4].value = 15;
                CharacterStats[5].value = 5;
                charClass = CharacterClass.Witch;
                break;
        }
    }

    #region SetTexture
    public void SetTexture(string type, int dir) //cannot take both inputs when canvas, so 2 functions pos/neg
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] texture = new Texture2D[0];

        #region material and values (switch)
        switch (type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                texture = skin.ToArray();
                matIndex = 1;
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                texture = eyes.ToArray();
                matIndex = 2;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                texture = mouth.ToArray();
                matIndex = 3;
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                texture = hair.ToArray();
                matIndex = 4;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                texture = clothes.ToArray();
                matIndex = 5;
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                texture = armour.ToArray();
                matIndex = 6;
                break;
        }
        #endregion
        #region assign direction
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        else if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = characterRenderer.materials; //grabbing materials directly from renderer
        mat[matIndex].mainTexture = texture[index]; //changes texture
        characterRenderer.materials = mat; //close the circle
        #endregion
        #region set material (switch)
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
        }
        #endregion
    }
    #endregion
    #region SetTextureDirections
    public void SetTextureForth(string type) //cannot take both inputs when canvas, so 2 functions pos/neg
    {
        SetTexture(type, 1);
    }
    public void SetTextureBack(string type) //cannot take both inputs when canvas, so 2 functions pos/neg
    {
        SetTexture(type, -1);
    }
    #endregion
    #region random and reset
    public void RandomTexture()
    {
        Debug.Log("Here's where random code goes");
        SetTexture("Skin", Random.Range(0, skinMax - 1));
        SetTexture("Eyes", Random.Range(0, eyesMax - 1));
        SetTexture("Mouth", Random.Range(0, mouthMax - 1));
        SetTexture("Hair", Random.Range(0, hairMax - 1));
        SetTexture("Clothes", Random.Range(0, clothesMax - 1));
        SetTexture("Armour", Random.Range(0, armourMax - 1));
    }
    public void ResetTexture()
    {
        Debug.Log("Here's where reset code goes");
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
    }
    #endregion

}
public enum CharacterClass
{
    Fighter,
    Rogue,
    Witch
}