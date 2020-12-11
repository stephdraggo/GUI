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
        [SerializeField] private Quest currentQuest;


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
            if (_quest.goal.state == QuestState.Available)
            {
                currentQuest = _quest;
                currentQuest.goal.state = QuestState.Active;
                NPCs.BaseNPC.showQuest = false;
            }
            else
            {
                Debug.LogError("Quest not available.");
            }
        }
        public void DeclineQuest(Quest _quest)
        {
            _quest.goal.state = QuestState.Available;
            if (currentQuest == _quest)
            {
                currentQuest = null;
            }
            NPCs.BaseNPC.showQuest = false;
        }
        public void ClaimReward(Quest _quest)
        {
            if (_quest.goal.Completed() && _quest.goal.state == QuestState.Active)
            {
                _quest.goal.state = QuestState.Claimed;
                //add rewards (money,xp)
                _quest.goal.Claim();
                NPCs.BaseNPC.showQuest = false;
                currentQuest = null;
            }
        }
        #endregion
    }
}