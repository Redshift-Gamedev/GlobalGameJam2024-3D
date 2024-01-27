using UnityEngine;

namespace GlobalGameJam.UI
{
    public class NpcMoodBarUI : MoodBarUI
    {
        [SerializeField] private NpcMood npcMood;

        protected override void Awake()
        {
            base.Awake();
            npcMood.OnMoodChanged += UpdateBarImage;
        }

        private void OnDestroy()
        {
            npcMood.OnMoodChanged -= UpdateBarImage;
        }
    }
}