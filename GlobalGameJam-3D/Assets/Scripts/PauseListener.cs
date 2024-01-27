using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class PauseListener : MonoBehaviour
    {
        public static event Action<bool> OnGamePauseStateChanged = delegate { };
        private bool isPaused = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                OnGamePauseStateChanged?.Invoke(isPaused);
            }
        }
    }
}