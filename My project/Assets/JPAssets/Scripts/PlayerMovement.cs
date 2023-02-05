using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variable to control the player's speed and jumping
    public float movementSpeed;
    public float jumpingForce;

    //variable to control the player's properties such as its Rigidbody to allow gravity to affect their movement
    private Rigidbody2D playerRb;
    public Transform headCheck;

    //variable to control character's direction when moving in the scene
    private bool headingRight = true;
    private float movementDirection;

    //variable for controlling the player's jumping
    private bool isJumping = false;
    public int jumpingLimit;
    private int jumpAmount;

    //variables for determining if the player is grounded and checks if the empty groundCheck variable
    private bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float radiusCheck;

    //variable for the animator
    public Animator animator;
   private SpriteRenderer sprite;

    private void Awake()
    {
        //Gets the Rigidbody for the player before the game starts
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Adjusts the amount of jumps available to the player based on the jumping limit in the inspector with the default being 2 jumps for the player
        jumpAmount = jumpingLimit;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Player's Input upon pressing keys
        PlayerInputs();

        //Determine the direction the player is facing when moving
        PlayerRotate();

    }

    private void FixedUpdate()
    {
        //Checks if the player is grounded by using the groundCheck, radiusCheck, and groundObject variables and if they are, allow the player to jump based on the jump amount
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, groundObjects);
        if (isGrounded)
        {
            jumpAmount = jumpingLimit;
        }

        //Allows the player to move 
        MovePlayer();
    }

    private void PlayerRotate()
    {
        //Determines if the player is facing either right or left with the headingRight variable and calculating the movementDirection variable to flip the character accordingly.
        if (movementDirection > 0)
        {
            //flips saprite if heading to right >
            sprite.flipX = true;
            //headingRight = false;

        }
        else if (movementDirection < 0 )
        { 
            //flips saprite if heading to left <
            sprite.flipX = false;
           // headingRight = true;

        }
    }

    private void TurnCharacter()
    {
       
    }

    private void MovePlayer()
    {
        //Allows the player to move forward based on velocity and if the player jumps, adds force to make them move in the air while taking away a jump.
        playerRb.velocity = new Vector2(movementSpeed * movementDirection, playerRb.velocity.y);
        if (isJumping && jumpAmount > 0)
        {
            playerRb.AddForce(new Vector2(0f, jumpingForce));
            jumpAmount--;

        }
        isJumping = false;
    }

    private void PlayerInputs()
    {
        //Allows the player to move based on the keyboard inputs and if the player presses the button corresponding with jump and they have a jump available, the player will be able to jump.
        movementDirection = Input.GetAxisRaw("Horizontal");
        if  (movementSpeed > 2)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        if (Input.GetButtonDown("Jump") && jumpAmount > 0)
        {
            isJumping = true;
        }
    }

}
