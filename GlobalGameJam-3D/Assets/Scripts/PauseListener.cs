using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class PauseListener : MonoBehaviour
    {
        public static event Action<bool> OnGamePauseStateChanged = delegate { };
        private static bool isPaused = false;
        private bool canListenInput = true;

        public static bool isLostGame;

        private void Awake()
        {
            TavernMood.OnMoodLost += LostGame;
        }

        private void Start()
        {
            isLostGame = false;
            SetPauseState(false);
            canListenInput = true;
        }

        private void Update()
        {
            if (canListenInput && Input.GetKeyDown(KeyCode.Escape))
            {
                SetPauseState(!isPaused);
            }
        }

        private void OnDestroy()
        {
            TavernMood.OnMoodLost -= LostGame;
            SetPauseState(false);
        }

        private void LostGame()
        {
            isLostGame = true;
            SetPauseState(true);
            canListenInput = false;
        }

        public void UnpauseGame()
        {
            SetPauseState(false);
        }

        public static void SetPauseState(bool newPausedState)
        {
            isPaused = newPausedState;
            OnGamePauseStateChanged?.Invoke(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}