using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Stuff")]
    [SerializeField] private Text itemName; 
    [SerializeField] private Image itemImage;

    [Header("Variable from the item")]
    public Sprite itemSprite;
    public Text itemDescription;
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(InventoryItem newItem, InventoryManager newManager) {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem) {
            itemImage.sprite = thisItem.itemImage;
            itemDescription.text = thisItem.itemDescription;
        }
    }

    public void ClickedOn() {
        if (thisItem) {
            thisManager.SetTextAndButton(thisItem.itemDescription, thisItem.usable);
        }
    }
}
