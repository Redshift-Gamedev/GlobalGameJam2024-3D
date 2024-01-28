using UnityEngine;
using TMPro;

namespace GlobalGameJam.UI
{
    public class TimerDisplayer : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        private TextMeshProUGUI timerText;

        private void Awake()
        {
            timerText = GetComponent<TextMeshProUGUI>();
            TavernMood.OnMoodLost += SetTimerText;
        }

        private void SetTimerText()
        {
            DisplayTime(timer.TimeElapsed);
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}