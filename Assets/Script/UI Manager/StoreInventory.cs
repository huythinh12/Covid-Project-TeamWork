using System;
using System.Collections.Generic;
using UnityEngine;
public class StoreInventory : MonoBehaviour
{
    public int space = 10;  // Amount of item spaces
    public static StoreInventory Instance;

    // Our current list of items in the inventory
    public ListItem storeInventory;
    List<Item> items = new List<Item>();
    Item item;

    private void Awake()
    {
        items = storeInventory.listFood;
        Instance = this;
    }
    private void OnEnable()
    {
        if (items.Count > 0)
            UpdateUI();
    }


    //// Add a new item if enough room
    //public void Add(Item item)
    //{
    //	if (item.showInInventory)
    //	{
    //		if (items.Count >= space)
    //		{
    //			Debug.Log("Not enough room.");
    //			return;
    //		}

    //		items.Add(item);
    //		UpdateUI();

    //	}
    //}
    // Remove an item
    public void Remove(Item newItem)
    {
        item = newItem;
        if (item?.numberItem > 0)
        {
            item.numberItem--;
            print("co add vao");
            Inventory.instance.Add(item);
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        StoreInventorySlot[] slots = GetComponentsInChildren<StoreInventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].AddItem(items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
