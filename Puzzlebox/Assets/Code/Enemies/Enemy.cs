using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public static Enemy instance;
    public int EnemyHealth;

    void Start()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        IsDead();
    }

    public void IsDead() {
        if (EnemyHealth <= 0) {
            Destroy(this.gameObject);
        }
    }


}
