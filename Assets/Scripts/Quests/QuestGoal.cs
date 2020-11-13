using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.Quests
{
    [System.Serializable]
    public abstract class QuestGoal : MonoBehaviour
    {
        #region Variables
        [Header("Completion details")]
        public QuestType type;
        public QuestState state;

        #endregion

        #region Abstract Functions
        public abstract bool Completed();
        #endregion
    }

    #region Quest enums
    public enum QuestType
    {
        Gather,
        Kill,
        Escort,
    }
    public enum QuestState
    {
        Available,
        Active,
        Claimed,
    }
    #endregion
}