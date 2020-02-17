using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerHP;
    public int fullHP;
    public int attackPwr;
    public float playerStamina;
    public float fullStamina;

    // Creating an array of hearts.
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Text keyCountText;
    public int totKeys;




    public static PlayerStats instance; 
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UIHearts();
        UIKeys();
    }

    // Checks to see how many hearts the player has. 
    public void UIHearts() {
        for (int x = 0; x < hearts.Length; x++) {

            if (x < playerHP)
            {
                hearts[x].sprite = fullHeart;
            }
            else {
                hearts[x].sprite = emptyHeart;
            }

            if (x < fullHP)
            {
                hearts[x].enabled = true;
            }
            else {
                hearts[x].enabled = false;
            }
        }
    }

    public void UIKeys() {
        keyCountText.text = "x " + totKeys.ToString();
    }

    public void KeyCounting() {
        totKeys++;
    }
}
