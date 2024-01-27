using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class RefillTrigger : MonoBehaviour
    {
        //public static event Action OnPlayerEnterTrigger = delegate { };
        [SerializeField] private float reloadTime;
        private bool canRefill = true;
        private float currentTime;

        private void Start()
        {
            currentTime = reloadTime;
        }

        private void Update()
        {
            if(!canRefill)
            {
                currentTime -= Time.deltaTime;
                if(currentTime < 0f)
                {
                    canRefill = true;
                    currentTime = reloadTime;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerInventory playerInventory))
            {
                if (canRefill)
                {
                    playerInventory.RefillAmmo();
                    canRefill = false;
                }
                //OnPlayerEnterTrigger?.Invoke();
            }
        }
    }
}