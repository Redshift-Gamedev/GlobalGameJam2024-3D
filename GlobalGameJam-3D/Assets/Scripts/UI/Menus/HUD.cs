namespace GlobalGameJam.UI
{
    public class HUD : Panel
    {
        protected override void Awake()
        {
            base.Awake();
            PauseListener.OnGamePauseStateChanged += SetPanel;
        }


        private void Start()
        {
            SetPanelVisibility(true);
        }

        private void OnDestroy()
        {
            PauseListener.OnGamePauseStateChanged -= SetPanel;
        }

        private void SetPanel(bool isPaused)
        {
            SetPanelVisibility(!isPaused);
        }
    }
}