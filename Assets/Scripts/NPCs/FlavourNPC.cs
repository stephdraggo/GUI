using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.NPCs
{
    public class FlavourNPC : BaseNPC
    {
        #region Variables
        //reference dialogue script
        [SerializeField]
        protected string[] dialogueText;
        #endregion
        public override void Interact()
        {
            //set up dialogue
            Debug.Log("Flavour NPC.");
        }
    }
}