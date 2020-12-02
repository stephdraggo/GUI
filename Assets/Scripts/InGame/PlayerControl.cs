using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI1
{
    [AddComponentMenu("GUI/Player Control")]
    public class PlayerControl : MonoBehaviour
    {
        #region Variables
        [Header("Reference Variables")]
        public static bool isDead;
        public int level;
        public CharacterClass playerClass;

        [System.Serializable]
        public struct StatBlock //for health, mana, stamina
        {
            [Min(0)] public float current;
            [Min(0)] public float max;
        }
        public StatBlock[] lifeForce = new StatBlock[3]; //health, mana, stamina

        [System.Serializable]
        public struct Skill //for strength, endurance, agility, charisma, aura & thought
        {
            public string skillName;
            public int baseValue;
            public int tempValue;
            public int totalValue;
        }
        public Skill[] skills = new Skill[6]; //strength, endurance, agility, charisma, aura & thought
        #endregion
        #region Properties
        /// <summary>
        /// can't remember why I made this but it works for health
        /// </summary>
        public float StatMax
        {
            get
            {
                return lifeForce[0].max;
            }
            set
            {
                if (lifeForce[0].current > lifeForce[0].max)
                {
                    lifeForce[0].current = lifeForce[0].max;
                }
                lifeForce[0].current = value;
            }
        }

        #endregion
        #region Start
        private void Start()
        {
            Load();
            Save();
            Load();

            CheckStats();
        }
        #endregion
        #region Functions
        #region save and load
        public void Save()
        {
            BinarySaveControl.SavePlayer(this);
        }
        public void Load()
        {
            PlayerData data = BinarySaveControl.LoadPlayer();

            name = data.name;

            level = data.level;

            playerClass = data.playerClass;

            #region position
            transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
            #endregion

            #region Life Force
            for (int i = 0; i < 3; i++)
            {
                lifeForce[i].current = data.currentLifeForce[i];
                lifeForce[i].max = data.maxLifeForce[i];
            }
            #endregion

            #region Skills
            for (int i = 0; i < 6; i++)
            {
                skills[i].baseValue = data.skillBase[i];
                skills[i].tempValue = data.skillTemp[i];
                skills[i].totalValue = skills[i].baseValue + skills[i].tempValue;
            }
            #endregion
        }
        #endregion
        #region stats
        private void CheckStats()
        {
            //check skill total values
            for (int i = 0; i < skills.Length; i++)
            {
                skills[i].totalValue = skills[i].baseValue + skills[i].tempValue;
            }

            //health is one part strength, three parts endurance
            lifeForce[0].max = skills[0].totalValue + skills[1].totalValue * 3;
            //stamina is three parts endurance, one part agility
            lifeForce[1].max = skills[1].totalValue * 3 + skills[2].totalValue;
            //mana is one part aura, one part thought
            lifeForce[2].max = skills[4].totalValue + skills[5].totalValue;
        }
        #endregion
        #endregion
    }
}