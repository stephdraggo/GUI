using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI1
{
    [System.Serializable]
    public class PlayerData
    {
        #region Variables
        public string name;
        public int level;

        public float[] position = new float[3]; //vector3

        public float[] currentLifeForce = new float[3];
        public float[] maxLifeForce = new float[3];

        public int[] skillBase = new int[6];
        public int[] skillTemp = new int[6];

        #endregion
        #region Save Player
        public PlayerData(PlayerControl player) //constructor
        {
            name = player.name;

            level = player.level;

            #region position
            //set three points for position vector3
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
            #endregion

            #region Life Force
            //for health, stamina & mana
            for (int i = 0; i < 3; i++)
            {
                currentLifeForce[i] = player.lifeForce[i].current;
                maxLifeForce[i] = player.lifeForce[i].max;
            }
            #endregion

            #region Skills
            //for strength, endurance, agility, charisma, aura & thought
            for (int i = 0; i < 6; i++)
            {
                skillBase[i] = player.skills[i].baseValue;
                skillTemp[i] = player.skills[i].tempValue;
            }
            #endregion

            //class needed

        }
        #endregion
    }
}