using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam.UI
{
    public class TavernMoodBarUI : MonoBehaviour
    {
        private Image barImage;

        private void Awake()
        {
            barImage = GetComponent<Image>();
            TavernMood.OnMoodChanged += UpdateBarImage;
        }

        private void OnDestroy()
        {
            TavernMood.OnMoodChanged -= UpdateBarImage;
        }

        private void UpdateBarImage(float newAmount)
        {
            barImage.fillAmount = newAmount;
        }
    }
}