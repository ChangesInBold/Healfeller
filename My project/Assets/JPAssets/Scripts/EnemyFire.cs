using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    //creates a field in the inspector for the prefab that the enemy will spawn
    [SerializeField]
    GameObject acornBullet;

    //variable for the position of the acorn being fired by the enemy squirrel
    public Transform acornPosition;

    //variable for the time in which an acorn is fired by the enemy squirrel
    float shotTimer;

    //variable to detect the player's position to begin firing at the player
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the location of the player based on their tag
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        BulletCheck();
    }

    public void BulletCheck()
    {
        //Checks the player's distance from the enemy sprite and if they are in a certain range, then the enemy will spawn an acorn to throw at the player
        float playerDistance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(playerDistance);

        if (playerDistance < 10)
        {
            //If the player is at a certain distance from the enemy and 1 second has passed, then the enemy will create the acorn bullet and the timer for when they shoot will reset.
            shotTimer += Time.deltaTime;
            if (shotTimer > 1)
            {
                shotTimer = 0;
                CreateBullet();
            }
        }
       
    }

    public void CreateBullet()
    {
        //creates an acorn prefab to spawn at the acorn's location that's attached to the enemy squirrel sprite.
        Instantiate(acornBullet, acornPosition.position, Quaternion.identity);
    }
}
