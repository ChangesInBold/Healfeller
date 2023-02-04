using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    //variables for what targets are affected by the background image when scrolling
    public Rigidbody2D player;
    public float scrollSpeed;
    private float startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        //gets the starting position of the object
        startingPosition = transform.position.x;
        //Creates a clone of the object the script is attached to.
        GameObject objectCopy = GameObject.Instantiate(this.gameObject);
        Destroy(objectCopy.GetComponent<ScrollBackground>());
        //Sets the location of the sprite within the background based on its position.
        objectCopy.transform.SetParent(this.transform);
        objectCopy.transform.localPosition = new Vector3(GetWidth(), 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gathers the velocity from the Rigidbody of the player.
        float targetVelocity = player.velocity.x;
        this.transform.Translate(new Vector3(-scrollSpeed * targetVelocity, 0, 0) * Time.deltaTime);
        float width = GetWidth();

        if (targetVelocity > 0)
        {
            //Shifts the scrolling of the background to the left.
            if (startingPosition - this.transform.localPosition.x > width)
            {
                this.transform.Translate(new Vector3(width, 0, 0));
            }
        }
        else
        {
            //Shifts the scrolling of the background to the right.
            if (startingPosition - this.transform.position.x < 0)
            {
                this.transform.Translate(new Vector3(-width, 0, 0));
            }
        }
    }

    float GetWidth()
    {
        //Gets the width of the sprite.
        return this.GetComponent<SpriteRenderer>().bounds.size.x;
    }

}
