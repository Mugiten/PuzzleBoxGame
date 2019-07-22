using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Erase() {
        anim.SetBool("ifHit", true);
        StartCoroutine(breakCo());
    }

    IEnumerator breakCo() {
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }
}
