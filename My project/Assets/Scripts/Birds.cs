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
    private bool headingLeft = true;
    private float xDirection = 1f;
    private float yDirection = 0.5f;
    private float leftLimit;
    private float rightLimit;
    public float startX;
    public float startY;

    //variables concerning attacking

    public Transform playerObject;
    public Vector3 target;
    private Vector3 direction;
    public Vector2 point;
    public float aggroDist = 10f;
    public bool birdAttacking = false;
    public float characterDistance = 30f;
    public float pointDistance = 30f;
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
        startX = transform.position.x;
        startY = transform.position.y;
        rightLimit = startX + 20;
        leftLimit = startX - 20;
        target = new Vector2(0.0f, 0.0f);
        point = new Vector2();
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
        //Determines if the bird is facing either right or left with the headingLeft variable and calculating the xDirection variable to flip the character accordingly.
        if (xDirection > 0 && !headingLeft)
        {
            FlipBird();
        }
        else if (xDirection < 0 && headingLeft)
        {
            FlipBird();
        }
    }*/

    private void DetectCharacter()
    {
        //Checks to see if the character is within a certain distance
        
        characterDistance = Vector3.Distance(birdRb.position, playerObject.transform.position);
        if (birdAttacking)
        {
            pointDistance = Vector3.Distance(birdRb.position, point);
            if (pointDistance <= 0.1f || characterDistance >= aggroDist +10)
            {
                birdAttacking = false;
                birdSpeed = 2;
            }
        }
        else
        {
            if (characterDistance <= aggroDist && (!birdAttacking))
            {
                birdAttacking = true;
                birdSpeed = 6;
                //targetX = playerObject.transform.position.x;
                //targetY = playerObject.transform.position.y;
                point = new Vector2(playerObject.transform.position.x, playerObject.transform.position.y);
                if (headingLeft && (transform.position.x - point.x <=0))
                {
                    FlipBird();
                }
                else
                {
                    if (!headingLeft && (transform.position.x - point.x > 0))
                    {
                        FlipBird();
                    }
                }
            }
        }
       


    }

    private void FlipBird()
    {
        //Flips the bird (HA!) when they change direction
        headingLeft = !headingLeft;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Movebird()
    {
        //Allows the bird to move forward based on velocity and if the bird jumps, adds force to make them move in the air while taking away a jump.
        birdRb.velocity = new Vector2(birdSpeed * xDirection, birdSpeed * yDirection);
        if (birdAttacking)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, point, Time.deltaTime * birdSpeed);
            birdRb.MovePosition(newPosition);




            float step = birdSpeed * Time.deltaTime;


            // move bird towards the target location
            // transform.position = Vector2.MoveTowards(transform.position, point, step);


            //direction = Vector2.MoveTowards(transform.position, target, birdSpeed);
            //transform.position = transform.position + direction;

        }
        else
        {
            
            //see if bird has passed right or left boundaries
            if (transform.position.x > rightLimit)
            {
                if (!headingLeft)
                {
                    FlipBird();
                }
                xDirection = -1f;
            }
            else
            {
                if (transform.position.x < leftLimit)
                {
                    if (headingLeft)
                    {
                        FlipBird();
                    }
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
