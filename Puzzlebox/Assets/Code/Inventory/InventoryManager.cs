using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject useButton;
    public Text nameText; 
    public InventoryItem currentItem;
    public InventorySlot slots;


    public static InventoryManager instance; 



    // Start is called before the first frame update
    void Start()
    {
        SetTextAndButton("", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTextAndButton(string description, bool buttonActive) {
        descriptionText.text = description;
        if (buttonActive) {
            useButton.SetActive(true);
        }
        else {
            useButton.SetActive(false);
        }
    }

    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem) {
        descriptionText.text = newDescriptionString;
        nameText.text = newItem.itemName;
        useButton.SetActive(isButtonUsable);
        currentItem = newItem;
    }
}
