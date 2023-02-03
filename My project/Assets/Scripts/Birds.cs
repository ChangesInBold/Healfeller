using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    //variable to control the bird's speed
    public int birdSpeed;

    //variable to control the bird's properties such as its Rigidbody to allow gravity to affect their movement
    private Rigidbody2D birdRb;
    

    //variable to control bird's direction when moving in the scene
    private bool headingRight = true;
    private float xDirection = 1f;
    private float yDirection = 0.5f;
    private float leftLimit = -10f;
    private float rightLimit = 20f;
    public float startY;

    //variables concerning attacking

    public Transform playerObject;
    public Vector3 target;
    private Vector3 direction;
    public float aggroDist = 15f;
    private bool birdAttacking = false;
    private bool birdReturning = false;
    public float characterDistance = 30f;
    public float targetX;
    public float targetY;
  
    //variables for determining if the bird is grounded and checks if the empty groundCheck variable
    //private bool isGrounded = false;
    //public Transform groundCheck;
    //public LayerMask groundObjects;
    //public float radiusCheck;


    private void Awake()
    {
        //Gets the Rigidbody for the bird before the game starts
        birdRb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        birdSpeed = 2;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        DetectCharacter();
        
    }

    private void FixedUpdate()
    {
        //Allows the bird to move 
        Movebird();
    }

    /*private void birdRotate()
    {
        //Determines if the bird is facing either right or left with the headingRight variable and calculating the xDirection variable to flip the character accordingly.
        if (xDirection > 0 && !headingRight)
        {
            TurnCharacter();
        }
        else if (xDirection < 0 && headingRight)
        {
            TurnCharacter();
        }
    }*/

    private void DetectCharacter()
    {
        //Checks to see if the character is within a certain distance
        if (!birdReturning)
        {
            characterDistance = Vector3.Distance(birdRb.position, playerObject.transform.position);
            if (characterDistance <= aggroDist)
            {
                //birdAttacking = true;
                birdSpeed = 4;
                target = playerObject.transform.position;
                
                //targetX = playerObject.transform.position.x;
                //targetY = playerObject.transform.position.y;
            }
        }


    }

    private void TurnCharacter()
    {
        //Rotates the character to the opposite side when they are moving a certain direction
        headingRight = !headingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Movebird()
    {
        //Allows the bird to move forward based on velocity and if the bird jumps, adds force to make them move in the air while taking away a jump.
        birdRb.velocity = new Vector2(birdSpeed * xDirection, birdSpeed * yDirection);
        if (birdAttacking)
        {
            direction = Vector2.MoveTowards(transform.position, target, birdSpeed);


            transform.position = transform.position + direction;

        }
        else
        {
            //see if bird has passed right or left boundaries
            if (transform.position.x > rightLimit)
            {
                xDirection = -1f;
            }
            else
            {
                if (transform.position.x < leftLimit)
                {
                    xDirection = 1f;
                }
            }
            //see if bird is too high or low
            if (transform.position.y > startY + 0.2)
            {
                yDirection = 0f;
            }
            else
            {
                if (transform.position.y < startY - 0.2)
                {
                    yDirection = 0.5f;
                }
            }
            birdRb.MovePosition(birdRb.position + birdRb.velocity * Time.fixedDeltaTime);
        }
    }

   
}
