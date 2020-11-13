using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.NPCs
{
    public abstract class BaseNPC : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        protected string name;
        #endregion

        #region Functions
        public abstract void Interact();
        #endregion
    }
}