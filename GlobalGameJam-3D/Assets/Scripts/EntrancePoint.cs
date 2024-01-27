using System;
using UnityEngine;
using GlobalGameJam.AI;

namespace GlobalGameJam
{
    public class EntrancePoint : MonoBehaviour
    {
        public static event Action<NpcMood> OnClientEntered = delegate { };

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out NpcMood npcMood))
            {
                OnClientEntered?.Invoke(npcMood);

                npcMood.gameObject.SetActive(false); //Disable Npc
            }
        }
    }
}