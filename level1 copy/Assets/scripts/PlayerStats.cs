using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Added for UI functionality

public class PlayerStats : MonoBehaviour
{
    public int health = 6; // Player's starting health
    public int maxHealth = 6; // Player's maximum health
    public int lives = 3; // Player's starting lives
    private float flickerTime = 0f; // Timer for sprite flickering
    public float flickerDuration = 0.1f; // Time for each flicker cycle

    private SpriteRenderer spriteRenderer; // Reference to the player's SpriteRenderer component 
    public bool isImmune = false; // Flag indicating player's immunity status
    private float immunityTime = 0f; // Timer for immunity duration
    public float immunityDuration = 1.5f; // Length of immunity period
    public int HealthCollected = 0;

    public AudioClip GameOverSound; // The audio for game over
    public Image healthBar; // Reference to the health bar UI element

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>(); // Get a reference to the SpriteRenderer component attached to the Player GameObject
    }

    void SpriteFlicker() // Method to create a flickering effect on the player's sprite during immunity
    {
        if (this.flickerTime < this.flickerDuration) // Check if the flicker timer hasn't reached the maximum duration yet
        {
            this.flickerTime += Time.deltaTime; // Update the flicker timer based on time passed since last frame
        }
        else if (this.flickerTime >= this.flickerDuration) // Check if the flicker timer has reached or exceeded the duration
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled); // Toggle the player's sprite visibility
            this.flickerTime = 0; // Reset the flicker timer for the next cycle
        }
    }

    public void CollectHeart(int healthValue)
    {
        if (health < maxHealth) // Check if health is not full
        {
            health = Mathf.Min(health + healthValue, maxHealth); // Add health and cap it at maxHealth
            healthBar.fillAmount = (float)health / maxHealth; // Update the health bar UI
            Debug.Log("Heart collected! Player Health: " + health);
        }
        else
        {
            Debug.Log("Health is full! Cannot collect the heart.");
        }
    }

    public void TakeDamage(int damage) // Public method to handle damage taken by the player
    {
        if (this.isImmune == false) // Check if the player is not currently immune
        {
            this.health -= damage; // Decrease the player's health by the damage amount
            if (this.health < 0) this.health = 0; // Ensure health doesn't go below zero

            // Update health bar
            healthBar.fillAmount = (float)this.health / maxHealth; // Adjust the fill amount

            if (this.lives > 0 && this.health == 0) // Check if the player has lives remaining and health is zero
            {
                FindObjectOfType<LevelManager>().RespawnPlayer(); // Call the respawn method
                this.health = maxHealth; // Reset player health
                this.lives--; // Decrease player lives by one
            }
            else if (this.lives == 0 && this.health == 0) // Game over condition
            {
                Debug.Log("Gameover");
                AudioManager.instance.PlaySingle(GameOverSound); // Play game over sound
                AudioManager.instance.musicSource.Stop(); // Stop background music
                Destroy(this.gameObject); // Destroy the player GameObject
            }
            Debug.Log("Player Health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());
        }
        PlayHitReaction();
    }

    void PlayHitReaction() // Method to trigger immunity and reset timers when the player takes damage
    {
        this.isImmune = true; // Set the player to immune
        this.immunityTime = 0f; // Reset the immunity timer
    }

    void Update()
    {
        if (this.isImmune) // Check if the player is currently immune
        {
            SpriteFlicker(); // Create a flickering effect
            immunityTime += Time.deltaTime; // Update immunity timer
            if (immunityTime >= immunityDuration) // Check if immunity duration has ended
            {
                this.isImmune = false; // Disable immunity
                this.spriteRenderer.enabled = true; // Make the player's sprite visible again
                Debug.Log("Immunity has ended");
            }
        }
    }
}