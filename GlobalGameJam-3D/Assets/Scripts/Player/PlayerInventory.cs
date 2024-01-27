using System;
using UnityEngine;

namespace GlobalGameJam
{
    public class PlayerInventory : MonoBehaviour
    {
        //public static event 
        [Tooltip("Maximum amount of allowed bullets")]
        [SerializeField] private int maxAmmoAmount;

        [Tooltip("Amount of each ammo")]
        [SerializeField] private int[] ammoAmount;

        //Current selected ammo index
        private int _currentSelectedAmmo = 0;

        public int CurrentSelectedAmmo 
        { 
            get => _currentSelectedAmmo;
            set
            {
                int maxAmmo = 2;
                if(value > maxAmmo)
                {
                    value = 0;
                }
                else if(value < 0)
                {
                    value = maxAmmo;
                }
                _currentSelectedAmmo = Mathf.Clamp(value, 0, maxAmmo);
            }
        }

        private void Update()
        {
            HandleMouseScrolling();
            HandleKeyboard();

        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CurrentSelectedAmmo = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CurrentSelectedAmmo = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CurrentSelectedAmmo = 3;
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

        public bool TakeAmmo(BulletType bulletType)
        {
            if (ammoAmount[(int)bulletType] > 0)
            {
                ammoAmount[(int)bulletType]--;
                return true;
            }
            return false;
        }
    }
}