using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Tilemap theMap;

    private Vector3 topRightLimit;
    private Vector3 bottomLeftLimit;

    private float halfHeight;
    private float halfWidth;


    void Start()
    {
        //target = Player.instance.transform;
        target = FindObjectOfType<Player>().transform;


        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

        Player.instance.SetBounds(theMap.localBounds.min, theMap.localBounds.max);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //keep the camera inside the bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
