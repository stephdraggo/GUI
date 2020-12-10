using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.NPCs
{
    public abstract class BaseNPC : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        protected string npcName;
        public static bool showDialogue,showQuest;
        #endregion

        #region Functions
        public abstract void Interact();
        #endregion
    }
}