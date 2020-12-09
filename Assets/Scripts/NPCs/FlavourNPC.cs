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
        [SerializeField]private string[] neutral, positive, negative;
        protected int dialogueIndex;

        public Text nameText, dialogueDisplay;

        [Tooltip("0:Bye, 1:Next, 2:Accept, 3:Decline")]
        public Button[] dialogueActions;

        [Range(-1,1)]private int approval=0;
        #endregion
        private void Start()
        {
            if (neutral.Length != positive.Length || neutral.Length != negative.Length)
            {
                Debug.LogError("dialogue sets are not equal in length, this may cause a problem mid conversation");
            }
        }
        public override void Interact()
        {
            CheckApproval();

            nameText.text = npcName; //display name
            showDialogue = true; //
            dialogueDisplay.text = dialogueText[dialogueIndex];

            for (int i = 0; i < dialogueActions.Length; i++)
            {
                dialogueActions[i].gameObject.SetActive(true);
            }

            dialogueActions[2].GetComponentInChildren<Text>().text = "Be nice to Kevin.";
            dialogueActions[2].onClick.RemoveAllListeners();
            dialogueActions[2].onClick.AddListener(Nice);

            dialogueActions[3].GetComponentInChildren<Text>().text = "Be mean to Kevin.";
            dialogueActions[3].onClick.RemoveAllListeners();
            dialogueActions[3].onClick.AddListener(Mean);
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
        public void Nice()
        {
            approval++;
            CheckApproval();
        }
        public void Mean()
        {
            approval--;
            CheckApproval();
        }
        private void CheckApproval()
        {
            if (approval == 0)
            {
                dialogueText = neutral;
            }
            else if (approval > 0)
            {
                dialogueText = positive;
            }
            else
            {
                dialogueText = negative;
            }
        }
    }
}