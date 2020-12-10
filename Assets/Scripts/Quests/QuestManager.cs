using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.Quests
{
    public class QuestManager : MonoBehaviour
    {
        #region Variables
        public GUI1.PlayerControl player;
        public GUI3.Inventories.Inventory inventory;
        //also reference dialogue script
        private Quest currentQuest;


        #endregion
        #region Properties
        
        #endregion
        void Start()
        {
            player = FindObjectOfType<GUI1.PlayerControl>();
            inventory = player.gameObject.GetComponent<GUI3.Inventories.Inventory>();
        }

        void Update()
        {

        }

        #region Functions
        public void AcceptQuest(Quest _quest)
        {
            currentQuest = _quest;
            currentQuest.goal.state = QuestState.Active;
            NPCs.BaseNPC.showQuest = false;
        }
        public void DeclineQuest(Quest _quest)
        {
            _quest.goal.state = QuestState.Available;
            NPCs.BaseNPC.showQuest = false;
        }
        public void ClaimReward()
        {
            if (currentQuest.goal.Completed())
            {
                currentQuest.goal.state = QuestState.Claimed;
                //add rewards (money,xp)
                
            }
        }
        #endregion
    }
}