using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerHP;
    public int fullHP;
    public int attackPwr;
    public float playerStamina;
    public float fullStamina;

    public static PlayerStats instance; 
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
