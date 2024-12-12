using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthValue = 1; // Amount of health restored by the heart
    public AudioClip healthSound; // Sound clip that plays when the heart is collected
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // If no AudioSource component is found, create a new one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // Check if the player collides with the heart
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>(); // Get the PlayerStats component
            if (playerStats.health < playerStats.maxHealth) // Check if the player's health is not full
            {
                playerStats.CollectHeart(healthValue); // Add health to the player

                // Play the health sound effect
                PlayHealthSound();

                Destroy(this.gameObject); // Destroy the heart GameObject after collection
            }
            else
            {
                Debug.Log("Player's health is full. Cannot collect the heart."); // If health is full, don't destroy
            }
        }
    }

    // Method to play the health sound effect
    private void PlayHealthSound()
    {
        // Check if the healthSound clip is not null
        if (healthSound != null)
        {
            // Play the health sound effect
            audioSource.PlayOneShot(healthSound);
        }
        else
        {
            Debug.LogError("Health sound clip is not assigned in the Inspector.");
        }
    }
}