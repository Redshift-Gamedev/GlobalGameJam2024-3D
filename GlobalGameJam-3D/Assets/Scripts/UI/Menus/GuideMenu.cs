namespace GlobalGameJam.UI
{
    public class GuideMenu : Panel
    {
        protected override void Awake()
        {
            base.Awake();
            PauseListener.OnPauseButtonPressed += HidePanelOnResume;
        }

        private void Start()
        {
            SetPanelVisibility(false);
        }

        private void OnDestroy()
        {
            PauseListener.OnGamePauseStateChanged -= HidePanelOnResume;
        }

        public void HidePanelOnResume(bool isGamePaused)
        {
            if (!isGamePaused)
            {
                base.SetPanelVisibility(false);
            }
        }
    }
}