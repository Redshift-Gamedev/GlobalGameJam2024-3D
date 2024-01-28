using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GlobalGameJam.UI
{
    public class PauseMenuManager : MonoBehaviour
    {
        private void Awake()
        {
            PauseListener.OnGamePauseStateChanged += HandlePanel;
        }

        private void OnDestroy()
        {
            PauseListener.OnGamePauseStateChanged -= HandlePanel;
        }

        private void HandlePanel(bool isPaused)
        {
            gameObject.SetActive(isPaused);
        }

        public void OnMenuButton()
        {
            PauseListener.SetPauseState(false);
            SceneManager.LoadScene(0);
        }
    }
}