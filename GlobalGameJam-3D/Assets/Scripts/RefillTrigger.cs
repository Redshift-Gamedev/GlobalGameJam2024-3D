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

        [Tooltip("Animator of the corresponding window")]
        [SerializeField] private Animator animator;

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
                    animator.SetTrigger("OpenWindow");
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
                    animator.SetTrigger("CloseWindow");
                    canRefill = false;
                }
                //OnPlayerEnterTrigger?.Invoke();
            }
        }
    }
}