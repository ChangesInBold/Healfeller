using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    //variable to call the Player Health Script
    [SerializeField] PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            Debug.Log("Bird Hit!");
            TakeDamage();
        }
        if (collision.gameObject.CompareTag("Acorn"))
        {
            Debug.Log("Squirrel Hit!");
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        playerHealth.currentHealth = playerHealth.currentHealth -= 1;
        if (playerHealth.currentHealth <= 0)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
