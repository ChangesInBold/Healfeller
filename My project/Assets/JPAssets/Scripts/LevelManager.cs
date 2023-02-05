using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LV1"))
        {
            
            SceneManager.LoadScene("Level 2");
        }

        if (collision.gameObject.CompareTag("LV2"))
        {
            
            SceneManager.LoadScene("Level 3");
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            
            SceneManager.LoadScene("Win Scene");
        }

    }
}
