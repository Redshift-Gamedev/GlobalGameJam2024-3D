using UnityEngine;
using TMPro;

namespace GlobalGameJam
{
    public class Timer : MonoBehaviour
    {
        public float timeRemaining = 0;
        public bool timerIsRunning = false;
        public TextMeshProUGUI timeText;
        private void Start()
        {
            // Starts the timer automatically
            timerIsRunning = true;
        }
        private void Update()
        {
            if (timerIsRunning)
            {
                if (timeRemaining >= 0)
                {
                    timeRemaining += Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
            }
        }
        void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}