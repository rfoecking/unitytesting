using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour {
    public const int inventorySlots = 6;

    public Item[] items = new Item[inventorySlots];
    public Image[] itemImages = new Image[inventorySlots];


    public void AddItem(Item itemToAdd)
    {
        foreach (var item in items)
        {
            Debug.Log(item + ",");
        }
        for (int i = 0; i < items.Length; i++)
        {
            Debug.Log("item slot " + items[i]);
            if (items[i] == null)
            {
                Debug.Log("item slot has no item yet, adding it");
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }

    }

    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }

    }

}
