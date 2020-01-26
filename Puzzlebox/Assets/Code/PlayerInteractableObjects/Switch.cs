using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool turnOn = false;
    public string keyName;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switched() {
        GetComponent<SpriteRenderer>().color = new Color(1,0,0,1);
    }
}
