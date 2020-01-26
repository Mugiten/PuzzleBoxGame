using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    [SerializeField] private Door door;
    public SpriteRenderer keySprite;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public override void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name.Equals("Player")) {
            door.hasKey = true;
            keySprite.enabled = false;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player")) {
            door.hasKey = false;
            keySprite.enabled = true;
        }
    }

}
