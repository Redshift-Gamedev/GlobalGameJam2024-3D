using UnityEngine.SceneManagement;

namespace GlobalGameJam.UI
{
    public class PauseMenu : Panel
    {
        protected override void Awake()
        {
            base.Awake();
            PauseListener.OnGamePauseStateChanged += SetPanelVisibility;
            TavernMood.OnMoodLost += HidePanel;
        }

        private void Start()
        {
            HidePanel();
        }

        private void OnDestroy()
        {
            PauseListener.OnGamePauseStateChanged -= SetPanelVisibility;
            TavernMood.OnMoodLost -= HidePanel;
        }

        private void HidePanel()
        {
            SetPanelVisibility(false);
        }

        public void OnMenuButton()
        {
            SceneManager.LoadScene(0);
        }

        public override void SetPanelVisibility(bool isVisible)
        {
            if (!PauseListener.isLostGame)
            {
                base.SetPanelVisibility(isVisible);
            }
        }
    }
}