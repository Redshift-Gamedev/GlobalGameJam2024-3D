using UnityEngine.UI;
using UnityEngine;
using TMPro;

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
            PlayerInventory.OnAmmoAmountChanged += UpdateAmmoCount;
        }

        private void OnDestroy()
        {
            PlayerInventory.OnAmmoSelected -= HighlightSlot;
            PlayerInventory.OnAmmoAmountChanged -= UpdateAmmoCount;
        }

        private void HighlightSlot(int index)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                Image slotIcon = slots[i].GetComponent<Image>();
                slotIcon.color = i == index ? highlightColor : defaultColor;
            }
        }


        private void UpdateAmmoCount(int[] ammo)
        {
            for(int i = 0; i < ammo.Length; i++)
            {
                slots[i].GetComponentInChildren<TextMeshProUGUI>().text = ammo[i].ToString();
            }
        }
    }
}