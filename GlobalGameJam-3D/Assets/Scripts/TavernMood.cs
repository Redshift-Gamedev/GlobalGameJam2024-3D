using System;
using UnityEngine;
using GlobalGameJam.AI;

namespace GlobalGameJam
{
    [Serializable]
    public struct Interval
    {
        [Range(0f, 1f)] public float MinValue;
        [Range(0f, 1f)] public float MaxValue;
    }

    public class TavernMood : MonoBehaviour
    {
        public static event Action<float> OnMoodChanged = delegate { };
        public static event Action OnMoodLost = delegate { };

        private float _moodAmount; //Range 0 - 100% represented as 0 - 1 float range
        [SerializeField] private float initialMoodAmount = .5f;

        [Header("Thresholds")]
        [SerializeField] private Interval badInterval;
        [SerializeField] private Interval normalInterval;
        [SerializeField] private Interval goodInterval;

        public float MoodAmount
        {
            get => _moodAmount;
            private set
            {
                _moodAmount = Mathf.Clamp(value, 0f, 1f);
                OnMoodChanged?.Invoke(_moodAmount);
                if(_moodAmount == 0f)
                {
                    OnMoodLost?.Invoke(); //Game lost
                }
            }
        }

        private void Awake()
        {
            EntrancePoint.OnClientEntered += UpdateMood;
        }

        private void Start()
        {
            MoodAmount = initialMoodAmount;
        }

        private void OnDestroy()
        {
            EntrancePoint.OnClientEntered -= UpdateMood;
        }

        private void UpdateMood(NpcMood npcMood)
        {
            if(npcMood.MoodAmount < badInterval.MaxValue)
            {
                MoodAmount -= npcMood.BadMultiplier;
            }
            else if(npcMood.MoodAmount > normalInterval.MaxValue)
            {
                MoodAmount += npcMood.GoodMultiplier;
            }
        }
    }
}