using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlobalGameJam.UI
{
    public class MainMenu : Panel
    {
        public void OnPlayButton()
        {
            SceneManager.LoadScene(1);
        }

        public void OnQuitButton()
        {
            Application.Quit();
        }
    }
}