using UnityEngine;

namespace GlobalGameJam.UI
{
    public class NpcMoodBarUI : MoodBarUI
    {
        [SerializeField] private NpcMood npcMood;

        private static Color low = Color.red;
        private static Color medium = Color.yellow;
        private static Color high = Color.green;


        protected override void Awake()
        {
            base.Awake();
            npcMood.OnMoodChanged += UpdateBarImage;
        }

        private void OnDestroy()
        {
            npcMood.OnMoodChanged -= UpdateBarImage;
        }

        protected override void UpdateBarImage(float newAmount, MoodState moodState)
        {
            base.UpdateBarImage(newAmount);
            barImage.color = moodState switch
            {
                MoodState.Sober => low,
                MoodState.Dizzy => medium,
                MoodState.Drunk => high,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}