using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class RefillTrigger : MonoBehaviour
    {
        //public static event Action OnPlayerEnterTrigger = delegate { };
        [SerializeField] private float reloadTime;
        [SerializeField] private WindowAnimation windowAnimator;
        private bool _canRefill = true;
        private float currentTime;

        public bool CanRefill 
        {
            get => _canRefill;
            set
            {
                _canRefill = value;
                if(_canRefill)
                {
                    windowAnimator.OpenWindow();
                }
                else
                {
                    windowAnimator.CloseWindow();
                }
            }
        }

        private void Start()
        {
            currentTime = reloadTime;
            CanRefill = true;
        }

        private void Update()
        {
            if(!CanRefill)
            {
                currentTime -= Time.deltaTime;
                if(currentTime < 0f)
                {
                    CanRefill = true;
                    currentTime = reloadTime;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerInventory playerInventory))
            {
                if (CanRefill)
                {
                    if (!playerInventory.IsFull())
                    {
                        playerInventory.RefillAmmo();
                        CanRefill = false;
                    }
                }
                //OnPlayerEnterTrigger?.Invoke();
            }
        }
    }
}