using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Door door;
    public SpriteRenderer keySprite;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")) {
            this.gameObject.SetActive(false);
            other.GetComponent<PlayerStats>().KeyCounting();
        }
    }
}
