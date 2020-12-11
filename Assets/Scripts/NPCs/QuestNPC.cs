using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.NPCs
{
    public class QuestNPC : FlavourNPC
    {
        #region Variables
        [SerializeField] protected Quests.QuestManager questManager;
        [SerializeField] protected Quests.Quest quest;
        #endregion
        #region Start
        private void Start()
        {
            questManager = FindObjectOfType<Quests.QuestManager>();
            if (questManager == null)
            {
                Debug.LogError("There is no quest manager.");
            }
        }
        #endregion
        #region Functions
        public override void Interact()
        {
            nameText.text = npcName+": "+quest.title; //display name
            showQuest = true; //
            dialogueDisplay.text = quest.description;

            #region set buttons
            //clear and enable all buttons
            for (int i = 0; i < dialogueActions.Length; i++)
            {
                dialogueActions[i].onClick.RemoveAllListeners();
                dialogueActions[i].enabled = true;
            }
            //accept logic
            if (quest.goal.state == Quests.QuestState.Available) //only if available
            {
                dialogueActions[0].onClick.AddListener(() => questManager.AcceptQuest(quest)); //add function
            }
            else
            {
                dialogueActions[0].enabled = false; //or disable button
            }
            //decline
            dialogueActions[1].onClick.AddListener(()=>questManager.DeclineQuest(quest)); //decline button
            //claim logic
            if (quest.goal.Completed()) //only if completed
            {
                dialogueActions[2].onClick.AddListener(() => questManager.ClaimReward(quest)); //add function
            }
            else
            {
                dialogueActions[2].enabled = false; //or disable button
            }
            #endregion

            //Debug.Log("Quest giver NPC.");
            //switch (quest.goal.state)
            //{
            //    case Quests.QuestState.Available:
            //        //dialogue: "do this thing please"
            //        //for now accepts quests by default
            //        //questManager.AcceptQuest(quest);
            //        break;

            //    case Quests.QuestState.Active:
            //        if (quest.goal.Completed())
            //        {
            //            //dialogue: "here's your reward"
            //            questManager.ClaimReward(quest);
            //        }
            //        else
            //        {
            //            //dialogue: "what are you waiting for"
            //        }
            //        break;

            //    case Quests.QuestState.Claimed:
            //        //dialogue: "thanks for doing that thing earlier"

            //        break;

            //    default:
            //        break;
            //}
        }
        #endregion
    }
}