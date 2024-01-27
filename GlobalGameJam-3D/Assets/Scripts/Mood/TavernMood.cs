using System;
using UnityEngine;

namespace GlobalGameJam
{

    public class TavernMood : Mood
    {
        public static event Action<float> OnMoodChanged = delegate { };
        public static event Action OnMoodLost = delegate { };

        public override float MoodAmount
        {
            get => base.MoodAmount;
            protected set
            {
                base.MoodAmount = value;
                OnMoodChanged?.Invoke(MoodAmount);
                if (_moodAmount == 0f)
                {
                    OnMoodLost?.Invoke(); //Game lost
                }
            }
        }

        private void Awake()
        {
            EntrancePoint.OnClientEntered += UpdateMood;
        }


        private void OnDestroy()
        {
            EntrancePoint.OnClientEntered -= UpdateMood;
        }

        private void UpdateMood(NpcMood npcMood)
        {
            if(npcMood.MoodState is MoodState.Sober)
            {
                MoodAmount -= npcMood.BadAmount;
            }
            else if(npcMood.MoodState is MoodState.Drunk)
            {
                MoodAmount += npcMood.GoodAmount;
            }
        }
    }
}