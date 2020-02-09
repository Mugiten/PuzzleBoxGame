using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : TimeParentScript
{
    public enum SwitchType {
        normal,
        blinker
    }

    public bool turnOn = false;
    public string keyName;
    private Color originalColor;
    public GameObject switchObject;
    public SwitchType switchtype; 
   
    // Start is called before the first frame update
    void Start()
    {
        originalColor = this.GetComponent<SpriteRenderer>().color;
        //this.transform.tag = "Untagged";
    }

    // Update is called once per frame
    void Update()
    {
        WhatSwitchType();
    }

    public void WhatSwitchType() {
        if (switchtype == SwitchType.normal) {
            this.transform.tag = "Button";
        }

        if (switchtype == SwitchType.blinker) {
            this.transform.tag = "Untagged";
            BlinkSwitched();
        }
    }

    public void HitSwitched() {
        if (turnOn) {
            turnOn = false;
            switchObject.SetActive(false);
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
        else {
            turnOn = true;
            switchObject.SetActive(true);
            this.GetComponent<SpriteRenderer>().color = originalColor;
        }
    }

    public void BlinkSwitched()
    {
        if (turnOn) {
            turnOn = false;
            switchObject.SetActive(false);
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }

        else {
            turnOn = true;
            switchObject.SetActive(true);
            this.GetComponent<SpriteRenderer>().color = originalColor;
        }
    }

    IEnumerator ColorCo() {
        yield return new WaitForSeconds(1f);
        if (turnOn) {
            turnOn = false;
            switchObject.SetActive(false);
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
        else {
            turnOn = true;
            switchObject.SetActive(true);
            this.GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
}
