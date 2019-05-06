using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] lines;

    private bool canActivate;

    public bool isPerson = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.Z) && !DialogManager.instance.dialogbox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialog(lines, isPerson);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            canActivate = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
