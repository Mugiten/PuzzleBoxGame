using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interactable
{
    [SerializeField] private Rigidbody2D boxRgdBody;
    float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        //boxRgdBody.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        pushBox();
    }

    public void pushBox() {
        if (canActivate) {
            // box changes position.
            boxRgdBody.velocity = new Vector3(1f, 1f, 0) * speed; 
        }

        else {
            // movement stops. 
            boxRgdBody.velocity = Vector3.zero;
        }
    }
}
