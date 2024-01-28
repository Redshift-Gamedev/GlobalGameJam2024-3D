using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class PauseListener : MonoBehaviour
    {
        public static event Action<bool> OnGamePauseStateChanged = delegate { };
        private static bool isPaused = false;
        private bool canListenInput = true;

        private void Awake()
        {
            TavernMood.OnMoodLost += PauseGame;
        }

        private void Start()
        {
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
            TavernMood.OnMoodLost -= PauseGame;
            SetPauseState(false);
        }

        private void PauseGame()
        {
            SetPauseState(true);
            canListenInput = false;
        }

        public void UnpauseGame()
        {
            SetPauseState(false);
        }

        public static void SetPauseState(bool newPausedState)
        {
            Debug.Log($"Before {isPaused}");
            isPaused = newPausedState;
            OnGamePauseStateChanged?.Invoke(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
            Debug.Log($"After {isPaused}");
        }
    }
}