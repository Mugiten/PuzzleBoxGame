using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool hasKey;
    public SpriteRenderer doorSprite;
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
