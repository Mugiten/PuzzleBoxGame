using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Initializing text dialog system. 
    public Text dialogText;
    public Text nameText;
    public GameObject dialogbox;
    public GameObject nameBox;

    // Initializing an array for character's dialog lines, and a counter. 
    public string[] dialogLines;
    public int currentLine;

    public static DialogManager instance;

    void Start()
    {
        instance = this;
        //dialogText.text = dialogLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogbox.activeInHierarchy) {
            if (Input.GetKeyUp(KeyCode.Z)) {
                if (currentLine >= dialogLines.Length)
                {
                    dialogbox.SetActive(false);
                }
                else {
                    dialogText.text = dialogLines[currentLine];
                    currentLine++;
                }
                
            }
        }
    }


    public void ShowDialog(string[] newLines) {
        dialogLines = newLines;

        currentLine = 0;

        dialogText.text = dialogLines[0];
        dialogbox.SetActive(true);
    }
}
