using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{

    private Animator anim;
    public InventoryItem TrsrItem;
    public PlayerInventory playerInventory;
    public Signal raisedItem;
    //public GameObject dialogWindow;
    //public Text dialogText;
    protected string[] lines = new string[1];
    public bool isOpened;
    public bool signaled; 
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lines[0] = TrsrItem.itemDescription;
        signaled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        Open();
    }

    public void Open() {
        if (Input.GetKey(KeyCode.Z) && canActivate) {
            if (!isOpened) {
                DialogManager.instance.ShowDialog(lines, isPerson);
                playerInventory.AddItem(TrsrItem);
                playerInventory.currentItem = TrsrItem;
                anim.SetBool("opened", true);
                isOpened = true;
                raisedItem.Raise();
            }
        }
        else {
            ChestIsOpened();
        }
        
    }

    public void ChestIsOpened() {
        if (!DialogManager.instance.dialogbox.activeInHierarchy && isOpened) {
            if (!signaled) {
                raisedItem.Raise();
                signaled = true; 
            }
            playerInventory.currentItem = null;
        }
    }
}
