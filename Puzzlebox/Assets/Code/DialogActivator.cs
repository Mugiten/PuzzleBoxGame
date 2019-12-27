using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : Interactable
{
    // Start is called before the first frame update
    public string[] lines;


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


}
