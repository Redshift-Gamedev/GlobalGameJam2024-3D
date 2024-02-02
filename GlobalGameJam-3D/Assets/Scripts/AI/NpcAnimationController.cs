using UnityEngine;

namespace GlobalGameJam.AI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NpcMood))]
    public class NpcAnimationController : MonoBehaviour
    {
        [SerializeField] private float drunkSpeedMultiplier = .6f;
        [SerializeField] private float buzzedSpeedMultiplier = .7f;
        [SerializeField] private float soberSpeedMultiplier = 1f;

        private Animator animator;
        private NpcMood npcMood;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            npcMood = GetComponent<NpcMood>();
            npcMood.OnMoodChanged += SetAnimation;
        }

        private void OnDestroy()
        {
            npcMood.OnMoodChanged -= SetAnimation;
        }

        private void SetAnimation(float newMoodAmount, MoodState newMoodState)
        {
            float newSpeedMultiplier = newMoodState switch
            {
                MoodState.Dizzy => buzzedSpeedMultiplier,
                MoodState.Drunk => drunkSpeedMultiplier,
                MoodState.Sober => soberSpeedMultiplier,
                _ => 1f
            };
            animator.SetFloat("Speed", newSpeedMultiplier);
            animator.SetFloat("Mood", newMoodAmount);
        }
    }
}