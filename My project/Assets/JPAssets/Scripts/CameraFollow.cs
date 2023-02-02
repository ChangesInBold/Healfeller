using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //player variable that the camera will follow
    public Transform playerTransform;

    public float yOffset = 1f;
    public float cameraSpeed = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Syncs the camera's z position to the player's x and y position in the scene 
        Vector3 newPos = new Vector3(playerTransform.position.x, playerTransform.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, cameraSpeed * Time.deltaTime);
    }
}
