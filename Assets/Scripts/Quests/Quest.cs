using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.Quests
{
    [System.Serializable]
    public class Quest
    {
        #region Variables
        [Header("Details")]
        public string title;
        public string description;
        public NPCs.QuestNPC questGiver;
        public QuestGoal goal;
        public QuestType type;

        [Header("Rewards")]
        public int experienceGain;
        public int goldGain;

        [Header("Requirements")]
        public int requiredLevel;

        #endregion
    }
}