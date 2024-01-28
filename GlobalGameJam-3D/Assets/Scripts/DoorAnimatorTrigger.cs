using UnityEngine;

namespace GlobalGameJam
{
    public class DoorAnimatorTrigger : MonoBehaviour
    {
        [SerializeField] private DoorAnimation doorAnimator;
        private bool isDoorOpen;

        private void Awake()
        {
            doorAnimator.OnDoorClosed += AvailableToOpen;
        }

        private void OnDestroy()
        {
            doorAnimator.OnDoorClosed -= AvailableToOpen;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out NpcMood npc))
            {
                if (!isDoorOpen)
                {
                    doorAnimator.OpenDoor();
                    isDoorOpen = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out NpcMood npc))
            {
                doorAnimator.CloseDoor();
            }
        }

        private void AvailableToOpen()
        {
            isDoorOpen = false;
        }
    }
}