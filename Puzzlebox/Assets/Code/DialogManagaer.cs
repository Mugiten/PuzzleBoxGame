using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagaer : MonoBehaviour
{
    // Initializing text dialog system. 
    public Text dialogText;
    public Text nameText;
    public GameObject dialogbox;
    public GameObject nameBox;

    // Initializing an array for character's dialog lines, and a counter. 
    public string[] dialogLines;
    public int currentLine;

    void Start()
    {
        dialogText.text = dialogLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
