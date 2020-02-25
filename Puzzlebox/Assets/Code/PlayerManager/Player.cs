using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Creating a state machine. Calling enum.
public enum PlayerState
{
    walk,
    attack,
    interact
}

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rgdbdy;
    [SerializeField] private Animator playerAnimator;
    public static Player instance;
    public string areaTransitionName;
    public SpriteRenderer receivedItem;
    public PlayerInventory playerInventory; 

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    // Created a usingStamina bool
    private bool usingStamina = false;

    public bool canMove = true;

    public Slider playerStaminaBar;

    // Ghost effect
    public Ghost ghost;

    //Creating a PlayerState
    public PlayerState currentState;

    // This is used to test the stoptime.
    public Switch StopTimeObject;
    bool timeFreeze;


    void Start()
    {
        currentState = PlayerState.walk;
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

        // initializing stamina
        playerStaminaBar.value = PlayerStats.instance.playerStamina;
        timeFreeze = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == PlayerState.interact) {
            return; 
        }

        if (Input.GetKey("c") && currentState != PlayerState.attack) {
            StartCoroutine(AttackCo());
        }

        if (currentState == PlayerState.walk)
        {
            PlayerMovement();
        }


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);


        Dash();

        TimeStop();

    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight) {
        bottomLeftLimit = botLeft + new Vector3(1f, 0f, 0f);
        topRightLimit = topRight + new Vector3(-1f, -1f, 0f);
            
    }

    public void PlayerMovement() {
        // Get the movement.
        if (canMove)
        {
            rgdbdy.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * speed;
        }

        else
        {
            rgdbdy.velocity = Vector3.zero;
        }

        playerAnimator.SetFloat("moveX", rgdbdy.velocity.x);
        playerAnimator.SetFloat("moveY", rgdbdy.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxis("Vertical") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == -1)
        {

            if (canMove)
            {
                playerAnimator.SetFloat("lastDirX", Input.GetAxisRaw("Horizontal"));
                playerAnimator.SetFloat("lastDirY", Input.GetAxisRaw("Vertical"));
            }
        }
    }



    private IEnumerator AttackCo() {
        playerAnimator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        playerAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        if (currentState != PlayerState.interact) {
            currentState = PlayerState.walk;
        }
    }

    public void RaiseItem() {
        if (currentState != PlayerState.interact) {
            playerAnimator.SetBool("openChest", true);
            currentState = PlayerState.interact;
            receivedItem.sprite = playerInventory.currentItem.itemImage;
        }
        else {
            playerAnimator.SetBool("openChest", false);
            currentState = PlayerState.walk;
            receivedItem.sprite = null;
        }
    }

    /*
     When you push on the X key, it will decrement the player stamina, and change the bool usingStamina to true. Speed will increase, until the 
     X key is released, then the stamina will increment, and speed will change back to the normal speed. 
         */
    public void Dash() {
        usingStamina = false;

        if (Input.GetKey("x"))
        {
            playerStaminaBar.value -= 3;
            if (playerStaminaBar.value > 0F)
            {
                usingStamina = true;
            }
        }
        else {
            if (playerStaminaBar.value < PlayerStats.instance.fullStamina)
            {
               playerStaminaBar.value += 1;
            }
        }

        if (usingStamina)
        {
            speed = 7;
            ghost.makeGhost = true;
            playerAnimator.speed = 1.2f;
        }
        else {
            speed = 3;
            ghost.makeGhost = false;
            playerAnimator.speed = 1;
        }
    }

    public void TimeStop() {
        /* When button is pressed
            Try using Time.timescale to stop time like pausing or create a class where you can have object.enabled = false.
            If the player presses the button again or the stamina bar runs out, then object activities resume normally. 
        */

        // Make an array of switches that use the TimeParentScript
        TimeParentScript [] pSwitches = FindObjectsOfType<TimeParentScript>();
        usingStamina = false;
        if (Input.GetKeyDown("v")) {
            if (timeFreeze) {
                foreach (TimeParentScript pswitch in pSwitches) {
                    pswitch.GetComponent<Switch>().enabled = false;
                }
                timeFreeze = false;
            }
            else {
                foreach (TimeParentScript pswitch in pSwitches) {
                    pswitch.GetComponent<TimeParentScript>().enabled = true;
                }
                timeFreeze = true;
            }
        }
    }

    public void SlowTime() {
        usingStamina = false;
        
        if (Input.GetKey("b")) {
            playerStaminaBar.value--;
            if (playerStaminaBar.value > 0F) {
                usingStamina = true;
            }
        }
        else {
            if (playerStaminaBar.value < PlayerStats.instance.fullStamina) {
                playerStaminaBar.value++;
            }
        }

        if (usingStamina) {
            speed = 15;
            ghost.makeGhost = true;
            Time.timeScale = 0.1F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            playerAnimator.speed = 10f;
        }
        else {
            speed = 3;
            ghost.makeGhost = false;
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            playerAnimator.speed = 1;
        }
    }
}
