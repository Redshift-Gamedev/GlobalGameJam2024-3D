#define DEBUG
#undef DEBUG

using System;
using System.Collections;
using UnityEngine;

namespace GlobalGameJam
{
    public enum MoodState { Sober, Dizzy, Drunk }

    public class NpcMood : Mood
    {
        public event Action<float, MoodState> OnMoodChanged = delegate { };

        [Tooltip("Amount of mood to increase Tavern's Mood")]
        [SerializeField, Range(.001f, 1f)] private float _goodAmount;

        [Tooltip("Amount of mood to decrease Tavern's Mood")]
        [SerializeField, Range(.001f, 1f)] private float _badAmount;

        [Header("Thresholds")]
        private static Interval badInterval;
        private static Interval normalInterval;

        [Header("Timer")]
        [Tooltip("Time to wait after last change of mood before decrementing")]
        [SerializeField] private float timeToWait;
        [Tooltip("Amount to decrease each second")]
        [SerializeField] private float decreaseRate = .05f;
        private bool canDecreaseMood = true;

        [Header("Favorite stats")]
        [SerializeField] private BulletType favoriteDrink;
        [Tooltip("Multiplicative Bonus (x2, x3, etc.)")]
        [SerializeField] private float favoriteDrinkBonus;

        private Animator npcAnimator;

        private MoodState _moodState;

        public float GoodAmount => _goodAmount;
        public float BadAmount => _badAmount;

        public override float MoodAmount
        {
            get => base.MoodAmount;
            protected set
            {
                base.MoodAmount = value;
                if(_moodAmount >= badInterval.MinValue && _moodAmount <= badInterval.MaxValue)
                {
                    _moodState = MoodState.Sober;
                }
                else if(_moodAmount >= normalInterval.MinValue && _moodAmount <= normalInterval.MaxValue)
                {
                    _moodState = MoodState.Dizzy;
                }
                else if (_moodAmount > normalInterval.MaxValue )
                {
                    _moodState = MoodState.Drunk;
                }
                OnMoodChanged?.Invoke(MoodAmount, MoodState);
            }
        }

        public MoodState MoodState => _moodState;

        protected override void OnEnable()
        {
            MoodAmount = initialMoodAmount;
        }

        private void Awake()
        {
            npcAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            badInterval.MinValue = 0f;
            badInterval.MaxValue = .33f;

            normalInterval.MinValue = .331f;
            normalInterval.MaxValue = .66f;
        }

        private void Update()
        {
            if(canDecreaseMood)
            {
                if(MoodAmount > 0f)
                {
                    MoodAmount -= decreaseRate * Time.deltaTime;
                }
                if(MoodAmount == 0f)
                {
                    canDecreaseMood = false;
                }
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            canDecreaseMood = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.gameObject.TryGetComponent(out Bullet bullet))
            {
                if(favoriteDrink == bullet.BulletType)
                {
                    MoodAmount += bullet.Efficiency * favoriteDrinkBonus;
#if DEBUG
                    Debug.Log($"{MoodAmount} = {bullet.Efficiency} * {favoriteDrinkBonus} ({favoriteDrink})");
#endif
                }
                else
                {
                    MoodAmount += bullet.Efficiency;
#if DEBUG
                    Debug.Log($"{MoodAmount} = {bullet.Efficiency} ({bullet.BulletType})");
#endif
                }
                StartCoroutine(WaitForDecrease());
            }
        }

        private IEnumerator WaitForDecrease()
        {
            canDecreaseMood = false;
            yield return new WaitForSeconds(timeToWait);
            canDecreaseMood = true;
        }
    }
}