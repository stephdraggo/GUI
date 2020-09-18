using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gui
{
    [AddComponentMenu("GUI/Player Control")]
    public class PlayerControl : MonoBehaviour
    {
        #region Variables
        [Header("Reference Variables")]
        public static bool isDead;
        public int level;
        public float health;
        [System.Serializable]
        private struct StatBlock //for health, mana, stamina
        {
            [Min(0)] public float current;
            [Min(0)] public float max;

        }
        private StatBlock lifeForce;
        #endregion
        #region Properties
        public float StatMax
        {
            get
            {
                return lifeForce.current;
            }
            set
            {
                if (lifeForce.current > lifeForce.max)
                {
                    lifeForce.current = lifeForce.max;
                }
                lifeForce.current = value;
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
            health = data.health;
            transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);



        }
    }
}