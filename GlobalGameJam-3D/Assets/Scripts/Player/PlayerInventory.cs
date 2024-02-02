#define DEBUG
#undef DEBUG

using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class PlayerInventory : MonoBehaviour
    {
        public static event Action<int[]> OnAmmoAmountChanged = delegate { };
        public static event Action OnAmmoRefilled = delegate { };
        public static event Action<int> OnAmmoSelected = delegate { };

        [Tooltip("Maximum amount of variety of bullets")]
        [SerializeField] private int maxAmmoVariety = 3;

        [Tooltip("Maximum amount of allowed bullets")]
        [SerializeField] private int maxAmmoAmount;

        [Tooltip("Amount of each ammo")]
        [SerializeField] private int[] ammoAmounts;

        //Current selected ammo index
        [SerializeField] private int _currentSelectedAmmo = 0;

        public int CurrentSelectedAmmo 
        { 
            get => _currentSelectedAmmo;
            set
            {
                if(value >= maxAmmoVariety)
                {
                    value = 0;
                }
                else if(value < 0)
                {
                    value = maxAmmoVariety-1;
                }
                _currentSelectedAmmo = Mathf.Clamp(value, 0, maxAmmoVariety-1);
                OnAmmoSelected?.Invoke(_currentSelectedAmmo);
            }
        }

        private void Awake()
        {
            //RefillTrigger.OnPlayerEnterTrigger += RefillAmmo; //Subscribe to RefillTrigger event
            PauseListener.OnGamePauseStateChanged += HandleComponent;
        }

        private void Start()
        {
            OnAmmoSelected?.Invoke(_currentSelectedAmmo);
            OnAmmoAmountChanged?.Invoke(ammoAmounts);
            RefillAmmo();
        }

        private void Update()
        {
            HandleMouseScrolling();
            HandleKeyboard();

        }

        private void OnDestroy()
        {
            //RefillTrigger.OnPlayerEnterTrigger -= RefillAmmo; //Unsubscribe to RefillTrigger event
            PauseListener.OnGamePauseStateChanged -= HandleComponent;

        }

        private void HandleComponent(bool isPaused)
        {
            enabled = !isPaused;
        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CurrentSelectedAmmo = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CurrentSelectedAmmo = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CurrentSelectedAmmo = 2;
            }
        }

        private void HandleMouseScrolling()
        {
            if (Input.mouseScrollDelta.y > 0f)
            {
                CurrentSelectedAmmo++;
            }
            else if (Input.mouseScrollDelta.y < 0f)
            {
                CurrentSelectedAmmo--;
            }
        }

        public int TakeAmmo()
        {
            if (ammoAmounts[CurrentSelectedAmmo] > 0)
            {
                ammoAmounts[CurrentSelectedAmmo]--;
                OnAmmoAmountChanged?.Invoke(ammoAmounts);
                return CurrentSelectedAmmo;
            }
            else
            {
                //Ammo is empty
#if DEBUG
                Debug.Log($"ammoAmounts[CurrentSelectedAmmo {CurrentSelectedAmmo}]: {ammoAmounts[CurrentSelectedAmmo]}");
#endif
                return -1;
            }
        }

        public bool IsFull()
        {
            foreach(int ammoAmount in ammoAmounts)
            {
                if(ammoAmount < maxAmmoAmount)
                {
                    return false;
                }
            }
            return true;
        }

        public void RefillAmmo()
        {
            bool refilled = false;
            for (int i = 0; i < ammoAmounts.Length; i++)
            {
                if(ammoAmounts[i] != maxAmmoAmount)
                {
                    ammoAmounts[i] = maxAmmoAmount;
                    OnAmmoAmountChanged?.Invoke(ammoAmounts);

                    refilled = true;
                }
            }
            if (refilled)
            {
                OnAmmoRefilled?.Invoke();
            }
        }
    }
}