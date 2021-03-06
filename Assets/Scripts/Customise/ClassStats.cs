﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GUI1
{
    [AddComponentMenu("GUI/Customisation/Class and Stats")]
    public class ClassStats : MonoBehaviour
    {
        #region Variables
        public PlayerControl player;
        public string playerName;
        [Header("Character Class")]
        public CharacterClass charClass = CharacterClass.Fighter;
        public string[] selectedClass = new string[3];
        public int selectedIndex = 0;

        [Header("Stat Bonus")]
        public int statPoints = 10;
        public GameObject[] addStats, takeStats;
        public Text[] statDisplay;
        public Text pointsDisplay;

        #endregion
        #region Start
        void Start()
        {
            ChooseClass(0);
            selectedClass = new string[] { "Fighter", "Rogue", "Witch" };
            string[] tempName = new string[] { "Strength", "Endurance", "Agility", "Charisma", "Aura", "Thought" };
            for (int i = 0; i < tempName.Length; i++)
            {
                player.skills[i].skillName = tempName[i];
                player.skills[i].tempValue = 0;
            }
            UpdateDisplay();
        }
        #endregion
        #region Functions
        #region add, take and reset stats
        public void AddStat(int _index)
        {
            if (statPoints > 0)
            {
                statPoints--;
                player.skills[_index].tempValue++;
            }
            UpdateDisplay();
        }
        public void TakeStat(int _index)
        {
            if (statPoints < 10 && player.skills[_index].tempValue > 0)
            {
                statPoints++;
                player.skills[_index].tempValue--;
            }
            UpdateDisplay();
        }
        public void ResetStats()
        {
            if (statPoints < 10)
            {
                statPoints = 10;
                for (int i = 0; i < player.skills.Length; i++)
                {
                    player.skills[i].tempValue = 0;
                }
            }
            UpdateDisplay();
        }
        #endregion
        #region display
        public void UpdateDisplay()
        {
            pointsDisplay.text = "Points left: " + statPoints.ToString();
            for (int i = 0; i < player.skills.Length; i++)
            {
                statDisplay[i].text = player.skills[i].skillName + ": " + (player.skills[i].baseValue + player.skills[i].tempValue).ToString();
            }
        }
        public void UpdateName(string _newName)
        {
            player.name = _newName;
        }
        #endregion
        #region save
        public void SaveCharacter()
        {
            player.Save();
        }
        #endregion
        #region choose class
        public void ChooseClass(int classIndex)
        {
            switch (classIndex)
            {
                case 0:
                    player.skills[0].baseValue = 15;
                    player.skills[1].baseValue = 10;
                    player.skills[2].baseValue = 10;
                    player.skills[3].baseValue = 10;
                    player.skills[4].baseValue = 5;
                    player.skills[5].baseValue = 15;
                    charClass = CharacterClass.Fighter;
                    break;
                case 1:
                    player.skills[0].baseValue = 5;
                    player.skills[1].baseValue = 15;
                    player.skills[2].baseValue = 10;
                    player.skills[3].baseValue = 15;
                    player.skills[4].baseValue = 10;
                    player.skills[5].baseValue = 10;
                    charClass = CharacterClass.Rogue;
                    break;
                case 2:
                    player.skills[0].baseValue = 10;
                    player.skills[1].baseValue = 10;
                    player.skills[2].baseValue = 15;
                    player.skills[3].baseValue = 10;
                    player.skills[4].baseValue = 15;
                    player.skills[5].baseValue = 5;
                    charClass = CharacterClass.Witch;
                    break;
            }

            UpdateDisplay();

        }
        #endregion
        #endregion
    }
    public enum CharacterClass
    {
        Fighter,
        Rogue,
        Witch,
    }
}