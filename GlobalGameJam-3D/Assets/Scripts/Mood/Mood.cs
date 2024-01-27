using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class Mood : MonoBehaviour
    {
        protected float _moodAmount; //Range 0 - 100% represented as 0 - 1 float range
        [SerializeField, Range(0f, 1f)] protected float initialMoodAmount = .5f;

        public virtual float MoodAmount
        {
            get => _moodAmount;
            protected set
            {
                _moodAmount = Mathf.Clamp(value, 0f, 1f);          
            }
        }


        protected virtual void OnEnable()
        {
            MoodAmount = initialMoodAmount;
        }
    }
}