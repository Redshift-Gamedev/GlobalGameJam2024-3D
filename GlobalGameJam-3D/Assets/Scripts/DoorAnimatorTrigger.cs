using UnityEngine;

namespace GlobalGameJam
{
    public class DoorAnimatorTrigger : MonoBehaviour
    {
        [SerializeField] private DoorAnimation doorAnimator;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out NpcMood npc))
            {
                doorAnimator.OpenDoor();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out NpcMood npc))
            {
                doorAnimator.CloseDoor();
            }
        }
    }
}