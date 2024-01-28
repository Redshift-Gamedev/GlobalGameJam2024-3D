using UnityEngine.SceneManagement;

namespace GlobalGameJam.UI
{
    public class LostMenu : Panel
    {
        protected override void Awake()
        {
            base.Awake();
            TavernMood.OnMoodLost += ShowMenu;
        }

        private void Start()
        {
            SetPanelVisibility(false);
        }

        private void OnDestroy()
        {
            TavernMood.OnMoodLost -= ShowMenu;
        }

        private void ShowMenu()
        {
            SetPanelVisibility(true);
        }

        public void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}