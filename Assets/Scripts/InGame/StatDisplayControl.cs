using UnityEngine;
using UnityEngine.UI;

namespace GUI1
{
    [AddComponentMenu("GUI/Health Bar Control")]
    public class StatDisplayControl : MonoBehaviour
    {
        #region Variables
        [Header("Reference Variables")]
        [SerializeField, Tooltip("Image to change based on current health/mana/stamina.")]
        private Image healthBar;

        [SerializeField, Tooltip("Range of colour change.")]
        private Gradient gradient;

        [SerializeField, Tooltip("The object to fetch the health values from. Currently only works with PlayerControl.")]
        private GameObject statOwner;

        [SerializeField, Tooltip("0: health, 1: mana, 2: stamina")]
        private int statIndex;

        private bool isPlayer = false;
        [Min(0)] private float current, max;
        private PlayerControl player = null;
        #endregion
        #region Start
        void Start()
        {
            if (statOwner.TryGetComponent<PlayerControl>(out PlayerControl _player)) //if there is a PlayerControl attached to the stat owner
            {
                isPlayer = true; //tell the script this is a player object
                player = _player;
            }
            else //if there is eg enemy control script instead
            {
                isPlayer = false; //tell the script this is not a player object
            }
        }
        #endregion
        #region Update
        void Update()
        {
            if (isPlayer) //if this is for the player
            {
                //try catch is here for the first assignment since it's calling things that aren't functional yet
                try { current = player.lifeForce[statIndex].current; } //update current stat
                catch { current = 10; }

                //current = player.lifeForce[statIndex].current;
                max = player.lifeForce[statIndex].max; //set max to the player's max relevent stat
            }

            healthBar.fillAmount = Mathf.Clamp01(current / max); //tell the image how far to fill
            healthBar.color = gradient.Evaluate(healthBar.fillAmount); //tell the image what colour to fill
        }
        #endregion
        #region Functions
        /// <summary>Refetch the max stats, call this from a level up function.</summary>
        public void LevelUpHealthDisplay()
        {
            if (isPlayer) //if this is for the player
            {
                max = player.lifeForce[statIndex].max; //update max stat
            }
        }
        #endregion
    }
}