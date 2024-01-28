using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class PauseListener : MonoBehaviour
    {
        public static event Action<bool> OnGamePauseStateChanged = delegate { };
        private static bool isPaused = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPauseState(!isPaused);
            }
        }

        public static void SetPauseState(bool newPausedState)
        {
            isPaused = newPausedState;
            OnGamePauseStateChanged?.Invoke(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}