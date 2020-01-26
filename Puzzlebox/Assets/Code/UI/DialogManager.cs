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

                    Player.instance.canMove = true;
                }
                else {
                    CheckIfName();

                    dialogText.text = dialogLines[currentLine];
                    currentLine++;
                }
                
            }
        }
    }


    public void ShowDialog(string[] newLines, bool isPerson) {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogText.text = dialogLines[currentLine];
        dialogbox.SetActive(true);

        nameBox.SetActive(isPerson);

        Player.instance.canMove = false;
    }

    public void CheckIfName() {
        if (dialogLines[currentLine].StartsWith("n-")) {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
