using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Inventory/Player Inventory", fileName = "New Player Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();

    public void AddItem(InventoryItem newItem) {
        if (!myInventory.Contains(newItem))
            myInventory.Add(newItem);
    }

    public void RemoveItem(InventoryItem newItem) {
        if (myInventory.Contains(newItem))
            myInventory.Remove(newItem);
    }

    public bool isItemInInventory(InventoryItem newItem) {
        return myInventory.Contains(newItem);
    }

}
