using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class TavernMood : MonoBehaviour
    {
        public static event Action<float> OnMoodChanged = delegate { };
        public static event Action OnMoodLost = delegate { };

        private float _moodAmount; //Range 0 - 100% represented as 0 - 1 float range
        [SerializeField, Range(0f, 1f)] private float initialMoodAmount = .5f;

        public float MoodAmount
        {
            get => _moodAmount;
            set
            {
                _moodAmount = Mathf.Clamp(value, 0f, 1f);
                OnMoodChanged?.Invoke(_moodAmount);
                if(_moodAmount == 0f)
                {
                    OnMoodLost?.Invoke(); //Game lost
                }
            }
        }

        private void Start()
        {
            MoodAmount = initialMoodAmount;
        }
    }
}