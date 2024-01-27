using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace GlobalGameJam.UI
{
    public class PlayerInventoryUI : MonoBehaviour
    {
        [SerializeField]
        PlayerInventory inventory;

        [SerializeField]
        GameObject [] slots;

        [SerializeField]
        Color defaultColor = Color.grey;
        [SerializeField]
        Color highlightColor = Color.yellow;

        private void Awake()
        {
            PlayerInventory.OnAmmoSelected += HighlightSlot;
        }

        private void OnDestroy()
        {
            PlayerInventory.OnAmmoSelected -= HighlightSlot;
        }

        private void HighlightSlot(int index)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                Image slotIcon = slots[i].GetComponent<Image>();
                slotIcon.color = i == index ? highlightColor : defaultColor;
            }
        }
    }
}