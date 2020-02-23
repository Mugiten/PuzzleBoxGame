using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{

    private Animator anim;
    public InventoryItem TrsrItem; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Open();
    }

    public void Open() {
        if (Input.GetKey(KeyCode.Z) && canActivate) {
            //Debug.Log("opened");
            anim.SetBool("opened", true);
        }
    }
}
