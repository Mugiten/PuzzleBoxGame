﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rgdbdy;
    [SerializeField]
    private Animator playerAnimator;
    public static Player instance;
    public string areaTransitionName;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public bool canMove = true;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the movement.
        if (canMove)
        {
            rgdbdy.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        }

        else {
            rgdbdy.velocity = Vector2.zero;
        }

        playerAnimator.SetFloat("moveX", rgdbdy.velocity.x);
        playerAnimator.SetFloat("moveY", rgdbdy.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxis("Vertical") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == -1) {

            if (canMove)
            {
                playerAnimator.SetFloat("lastDirX", Input.GetAxisRaw("Horizontal"));
                playerAnimator.SetFloat("lastDirY", Input.GetAxisRaw("Vertical"));
            }
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);


        // Bullet Time.
        SlowTime();

    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight) {
        bottomLeftLimit = botLeft + new Vector3(1f, 0f, 0f);
        topRightLimit = topRight + new Vector3(-1f, -1f, 0f);
            
    }

    public void SlowTime() {
        if (Input.GetKey("x"))
        {
            // Have another condition with a timer.
            if (PlayerStats.instance.playerStamina != 0) {
                Time.timeScale = 0.2F;
                PlayerStats.instance.playerStamina -= 1;
            }
        }
        else {
            Time.timeScale = 1;
            if(PlayerStats.instance.playerStamina < PlayerStats.instance.fullStamina)
            PlayerStats.instance.playerStamina += 0.5f;
        }
    }
}
