using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interactable
{
    [SerializeField] private Rigidbody2D boxRgdBody;
    public float speed;
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
        boxRgdBody.velocity = Vector3.zero;
    }
}
