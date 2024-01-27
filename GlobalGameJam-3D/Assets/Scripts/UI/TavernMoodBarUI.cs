namespace GlobalGameJam.UI
{
    public class TavernMoodBarUI : MoodBarUI
    {
        protected override void Awake()
        {
            base.Awake();
            TavernMood.OnMoodChanged += UpdateBarImage;
        }

        private void OnDestroy()
        {
            TavernMood.OnMoodChanged -= UpdateBarImage;
        }
    }
}