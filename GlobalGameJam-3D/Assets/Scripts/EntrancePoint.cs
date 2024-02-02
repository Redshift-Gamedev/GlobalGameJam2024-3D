using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class EntrancePoint : MonoBehaviour
    {
        public static event Action<NpcMood> OnClientEntered = delegate { };

        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.parent.TryGetComponent(out NpcMood npcMood))
            {
                OnClientEntered?.Invoke(npcMood);

                npcMood.gameObject.SetActive(false); //Disable Npc
            }
        }
    }
}