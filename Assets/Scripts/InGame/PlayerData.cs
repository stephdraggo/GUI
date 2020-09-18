using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gui
{
    [AddComponentMenu("GUI/Player Data")]
    [System.Serializable]
    public class PlayerData
    {
        #region Variables
        public int level;
        public float health;
        public float[] position; //vector3
        #endregion
        #region Save Player
        public PlayerData(PlayerControl player) //constructor
        {
            level = player.level;
            health = player.health;

            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
        }
        #endregion
    }
}