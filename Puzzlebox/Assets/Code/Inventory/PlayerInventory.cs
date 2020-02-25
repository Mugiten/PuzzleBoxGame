using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Player Inventory")]
public class PlayerInventory : ScriptableObject
{

    public List<InventoryItem> myInventory = new List<InventoryItem>();
    public InventoryItem currentItem;

    public void AddItem(InventoryItem newItem)
    {
        if (!newItem.isKey) {
            if (!myInventory.Contains(newItem))
                myInventory.Add(newItem);
        }
        else {
            PlayerStats.instance.KeyCounting();
        }
    }

    public void RemoveItem(InventoryItem newItem)
    {
        if (myInventory.Contains(newItem))
            myInventory.Remove(newItem);
    }

    public bool isItemInInventory(InventoryItem newItem)
    {
        return myInventory.Contains(newItem);
    }
}
