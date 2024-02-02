using UnityEngine;

namespace GlobalGameJam
{ 
    public class DoorAnimation : MonoBehaviour
    {
        [SerializeField] private DoorAnimatorTrigger doorTrigger;
        [SerializeField] private float animationSpeedMultiplier = 1f;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            doorTrigger.OnDoorTriggerEnter += OpenDoor;
            doorTrigger.OnDoorTriggerExit += CloseDoor;
        }

        private void OnDestroy()
        {
            doorTrigger.OnDoorTriggerEnter -= OpenDoor;
            doorTrigger.OnDoorTriggerExit -= CloseDoor;
        }

        private void OpenDoor()
        {
            animator.SetFloat("Speed", animationSpeedMultiplier);
            animator.SetTrigger("OpenDoor");
        }

        private void CloseDoor()
        {
            animator.SetFloat("Speed", animationSpeedMultiplier);
            animator.SetTrigger("CloseDoor");
        }
    }
}