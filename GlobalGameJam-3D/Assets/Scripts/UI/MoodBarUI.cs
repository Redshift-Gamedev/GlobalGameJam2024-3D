using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam.UI
{
    public class MoodBarUI : MonoBehaviour
    {
        protected Image barImage;

        protected virtual void Awake()
        {
            barImage = GetComponent<Image>();
        }

        protected virtual void UpdateBarImage(float newAmount)
        {
            barImage.fillAmount = newAmount;
        }

        protected virtual void UpdateBarImage(float newAmount, MoodState moodState)
        {
            barImage.fillAmount = newAmount;
        }
    }
}