using UnityEngine;

namespace GlobalGameJam
{
    public class LookAtCamera : MonoBehaviour
    {
        Camera cam;

        private void Awake()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            transform.LookAt(cam.transform);
        }
    }
}