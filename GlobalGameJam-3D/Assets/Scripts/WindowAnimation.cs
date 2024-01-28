using System.Collections;
using UnityEngine;

namespace GlobalGameJam
{
    public class WindowAnimation : MonoBehaviour
    {
        [SerializeField] private float lerpDuration = 0.5f;

        public void OpenWindow()
        {
            StartCoroutine(OpenWindowAnimation());
        }

        private IEnumerator OpenWindowAnimation()
        {
            float timeElapsed = 0;
            Quaternion startRotation = transform.localRotation;
            Quaternion targetRotation = transform.localRotation * Quaternion.Euler(0, 0, 90);
            while (timeElapsed < lerpDuration)
            {
                transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localRotation = targetRotation;
        }

        public void CloseWindow()
        {
            StartCoroutine(CloseWindowAnimation());
        }

        private IEnumerator CloseWindowAnimation()
        {
            float timeElapsed = 0;
            Quaternion startRotation = transform.localRotation;
            Quaternion targetRotation = transform.localRotation * Quaternion.Euler(0, 0, -90);
            while (timeElapsed < lerpDuration)
            {
                transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localRotation = targetRotation;
        }
    }
}