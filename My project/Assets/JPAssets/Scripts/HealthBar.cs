using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public PlayerHealth playerHealth;
    private Slider healthSlider;
    public Image fillImage;

    void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateHealth();
    }

    public void CalculateHealth()
    {
        float remainingHealth = playerHealth.currentHealth / playerHealth.maxHealth;
        healthSlider.value = remainingHealth;
        if (healthSlider.value <= remainingHealth / 3)
        {
            fillImage.color = Color.blue;
        }
        else if (healthSlider.value >= remainingHealth / 3)
        {
            fillImage.color = Color.black;
        }
    }
}
