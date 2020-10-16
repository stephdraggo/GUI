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
        [System.Serializable]
        public struct StatBlock //for health, mana, stamina
        {
            [Min(0)] public float current;
            [Min(0)] public float max;

        }
        public StatBlock[] lifeForce=new StatBlock[3]; //health, mana, stamina
        public struct BaseSkill //for strength etc
        {
            string skillName;
            int defaultValue;
        }
        public BaseSkill[] baseSkills = new BaseSkill[6];
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
        public void Save()
        {
            SaveControl.SavePlayer(this);
        }

        public void Load()
        {
            PlayerData data = SaveControl.LoadPlayer();

            level = data.level;
            lifeForce[0].current = data.health;
            transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);



        }
    }
}