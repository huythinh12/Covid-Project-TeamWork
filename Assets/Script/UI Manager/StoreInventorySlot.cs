using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class StoreInventorySlot : MonoBehaviour
{
    public Image icon;
    TextMeshProUGUI txtCountItem;
    Button btnItemButton;
    Item item;  // Current item in the slot
    string countEnd = "0";

    private void Start()
    {
        btnItemButton = GetComponentInChildren<Button>();
    }
    // Add item to the slot
    public void AddItem(Item newItem)
    {
        item = newItem;
        if (item.numberItem <= 0)
        {
            ClearSlot();
            return;
        }
        txtCountItem = GetComponentInChildren<TextMeshProUGUI>();
        txtCountItem.text = item.numberItem.ToString();
        icon.sprite = item.icon;
        icon.enabled = true;

    }
    public void RemoveItem()
    {
        StoreInventory.Instance.Remove(item);
    }
    // Clear the slot 
    public void ClearSlot()
    {
        icon.sprite = item.icon;
        if (txtCountItem)
            txtCountItem.text = countEnd;
        else
            GetComponentInChildren<TextMeshProUGUI>().text = countEnd;
        if (btnItemButton)
            btnItemButton.interactable = false;
        else
        {
            GetComponentInChildren<Button>().interactable = false;
        }
        //Destroy(gameObject);
    }


    // Use the item
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
