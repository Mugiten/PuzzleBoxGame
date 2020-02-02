﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSwitch : MonoBehaviour
{
    public bool turnOn = false;
    [SerializeField] private Color originalColor;
    public GameObject switchObject;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = this.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        Switched();
    }

    public void Switched()
    {
        StartCoroutine(ColorCo());
        if (turnOn) {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
        else {
            this.GetComponent<SpriteRenderer>().color = originalColor;
        }
    }

    IEnumerator ColorCo()
    {
        yield return new WaitForSeconds(0.5f);
        if (turnOn) {
            turnOn = false;
            switchObject.SetActive(false);
        }
        else {
            turnOn = true;
            switchObject.SetActive(true);
        }
    }
}
