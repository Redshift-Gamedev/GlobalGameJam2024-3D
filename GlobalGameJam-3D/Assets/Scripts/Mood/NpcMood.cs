using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class NpcMood : Mood
    {
        public event Action<float> OnMoodChanged = delegate { };

        [Tooltip("Amount of mood to increase Tavern's Mood")]
        [SerializeField, Range(.001f, 1f)] private float _goodAmount;

        [Tooltip("Amount of mood to decrease Tavern's Mood")]
        [SerializeField, Range(.001f, 1f)] private float _badAmount;

        public float GoodAmount => _goodAmount;
        public float BadAmount => _badAmount;

        public override float MoodAmount
        {
            get => base.MoodAmount;
            protected set
            {
                base.MoodAmount = value;
                OnMoodChanged?.Invoke(MoodAmount);
            }
        }
    }
}