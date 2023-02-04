using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("LV1"))
        {
            Debug.Log("Loading Level 2");
            SceneManager.LoadScene("Level 2");
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("LV2"))
        {
            Debug.Log("Loading Level 3");
            SceneManager.LoadScene("Level 3");
        }
    }
}
