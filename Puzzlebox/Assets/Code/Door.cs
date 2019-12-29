using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// There will be multiple kinds of doors. Creating an enum for the types of doors. 
public enum DoorType {
    key,
    enemy,
    button
}



public class Door : Interactable
{
    // Door Variables. 
    public bool hasKey;
    public SpriteRenderer doorSprite;
    public DoorType thisDoorType;
    public bool open = false; 

    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.Z) && hasKey && canActivate) {
            doorSprite.enabled = false;
        }
    }
}
