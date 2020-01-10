using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    //[SerializeField] private GameObject blankInventorySlot;
    //[SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject useButton;
    [SerializeField] private GameObject itemObject;
    [SerializeField] private Button currentButton;
    [SerializeField] private InventoryItem currentItem;

    public static InventoryManager instance; 



    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        showDescription();
    }

    public void showDescription() {
        descriptionText.text = currentItem.itemDescription;
    }
}
