using System;
using System.Collections;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public event Action OnDoorOpened = delegate { };
    public event Action OnDoorClosed = delegate { };
    [SerializeField] private float lerpDuration = 0.5f;

    public void OpenDoor()
    {
        StartCoroutine(OpenDoorAnimation());
    }

    private IEnumerator OpenDoorAnimation()
    {
        float timeElapsed = 0;
        Quaternion startRotation = transform.localRotation;
        Quaternion targetRotation = transform.localRotation * Quaternion.Euler(0, -90, 0);
        while (timeElapsed < lerpDuration)
        {
            transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = targetRotation;
        OnDoorOpened?.Invoke();
    }

    public void CloseDoor()
    {
        StartCoroutine(CloseDoorAnimation());
    }

    private IEnumerator CloseDoorAnimation()
    {
        float timeElapsed = 0;
        Quaternion startRotation = transform.localRotation;
        Quaternion targetRotation = transform.localRotation * Quaternion.Euler(0, 90, 0);
        while (timeElapsed < lerpDuration)
        {
            transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = targetRotation;
        OnDoorClosed?.Invoke();
    }
}
