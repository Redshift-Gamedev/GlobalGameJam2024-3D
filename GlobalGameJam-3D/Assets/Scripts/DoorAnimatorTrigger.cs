using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class DoorAnimatorTrigger : MonoBehaviour
    {
        public event Action OnDoorTriggerEnter = delegate { };
        public event Action OnDoorTriggerExit = delegate { };

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent)
            {
                if (other.transform.parent.TryGetComponent(out NpcMood npc))
                {
                    OnDoorTriggerEnter?.Invoke();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.parent)
            {
                if (other.transform.parent.TryGetComponent(out NpcMood npc))
                {
                    OnDoorTriggerExit?.Invoke();
                }
            }
        }
    }
}