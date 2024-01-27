using UnityEngine;

namespace GlobalGameJam.AI
{
    public class NpcMood : MonoBehaviour
    {
        [SerializeField, Range(.001f, 1f)] private float goodMultiplier;
        [SerializeField, Range(.001f, 1f)] private float badMultiplier;
        [SerializeField, Range(0f, 1f)] private float initialMoodAmount;
        private float _moodAmount;

        public float MoodAmount => _moodAmount;

        public float GoodMultiplier => goodMultiplier;
        public float BadMultiplier => badMultiplier;

        private void Start()
        {
            _moodAmount = initialMoodAmount;
        }
    }
}