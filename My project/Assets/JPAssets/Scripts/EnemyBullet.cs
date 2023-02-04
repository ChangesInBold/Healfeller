using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //variable for the movement speed of the bullet.
    float bulletSpeed = 5f;

    private Rigidbody2D bulletRb;
    private GameObject player;
    Vector2 bulletDirection;


    // Start is called before the first frame update
    void Start()
    {
        //Gets the Rigidbody for the bullet prefab
        bulletRb = GetComponent<Rigidbody2D>();

        //Finds the player object within the scene
        player = GameObject.FindGameObjectWithTag("Player");

        //Determines the direction of the bullet based on the player's position from the position of the bullet which is attached to the bullet position on the enemy squirrel
        bulletDirection = player.transform.position - transform.position;
        bulletRb.velocity = new Vector2(bulletDirection.x, bulletDirection.y).normalized * bulletSpeed;

        //Rotates the bullet prefab based on the degrees and destroys the object after a second.
        float rotation = Mathf.Atan2(-bulletDirection.x, -bulletDirection.y) * Mathf.Rad2Deg;
        Quaternion.Euler(0, 0, rotation);
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision to detect if the player has been hit and destroys the game object on collision.
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
            Destroy(gameObject);
        }
    }
}
