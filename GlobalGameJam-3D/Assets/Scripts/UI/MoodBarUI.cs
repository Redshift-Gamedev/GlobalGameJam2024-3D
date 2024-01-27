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

        protected void UpdateBarImage(float newAmount)
        {
            barImage.fillAmount = newAmount;
        }
    }
}