using UnityEngine;
using TMPro;

namespace GlobalGameJam
{
    public class Timer : MonoBehaviour
    {
        private float _timeElapsed = 0;
        public bool timerIsRunning = false;
        public TextMeshProUGUI timeText;

        public float TimeElapsed 
        { 
            get => _timeElapsed;
            private set => _timeElapsed = value;
        }

        private void Start()
        {
            // Starts the timer automatically
            timerIsRunning = true;
        }

        private void Update()
        {
            if (timerIsRunning)
            {
                if (TimeElapsed >= 0)
                {
                    TimeElapsed += Time.deltaTime;
                    DisplayTime(TimeElapsed);
                }
            }
        }

        public void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}