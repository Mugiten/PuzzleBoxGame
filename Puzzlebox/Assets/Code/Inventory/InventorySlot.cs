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
        itemImage.sprite = thisItem.itemImage;
        itemDescription.text = thisItem.itemDescription;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedOn() {
        if (thisItem) {
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription, thisItem.usable, thisItem);
        }
    }
}
