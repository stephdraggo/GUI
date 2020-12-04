using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystems.NPCs
{
    public class FlavourNPC : BaseNPC
    {
        #region Variables
        //reference dialogue script
        [SerializeField]
        protected string[] dialogueText;
        protected int dialogueIndex;

        public Text nameText, dialogueDisplay;

        [Tooltip("0:Bye, 1:Next, 2:Accept, 3:Decline")]
        public Button[] dialogueActions;

        #endregion
        private void Start()
        {
           
        }
        public override void Interact()
        {
            nameText.text = npcName; //display name
            showDialogue = true; //
            dialogueDisplay.text = dialogueText[dialogueIndex];
        }
        public void Bye()
        {
            dialogueIndex = 0;
            showDialogue = false;
            dialogueDisplay.text = dialogueText[dialogueIndex];
        }
        public void Next()
        {
            dialogueIndex++;
            if (dialogueIndex >= dialogueText.Length)
            {
                Bye();
            }
            dialogueDisplay.text = dialogueText[dialogueIndex];
        }
        public void Accept(bool _accept)
        {
            //for quests
            dialogueActions[2].enabled = false;
            dialogueActions[3].enabled = false;

        }
    }
}