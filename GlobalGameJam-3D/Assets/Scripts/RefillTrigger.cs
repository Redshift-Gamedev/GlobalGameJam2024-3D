using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class RefillTrigger : MonoBehaviour
    {
        //public static event Action OnPlayerEnterTrigger = delegate { };

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerInventory playerInventory))
            { 
                playerInventory.RefillAmmo();
                //OnPlayerEnterTrigger?.Invoke();
            }
        }
    }
}