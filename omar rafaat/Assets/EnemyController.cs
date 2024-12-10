using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isFacingRight = false; // Indicates whether the enemy is facing right

    public float maxSpeed = 3f; // Maximum speed of the enemy's movement

    public int damage = 3; // Amount of damage the enemy affects to the player

    public AudioClip hit1; // Audio clips for enemy hit sounds

    public AudioClip hit2;

    public void Flip()  // Flips the enemy's facing direction
    {

        isFacingRight = !isFacingRight; // Invert the isFacingRight flag

        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);   // Scale the enemy's X-axis to flip its sprite horizontally
    }
    // Start is called before the first frame update
void OnTriggerEnter2D(Collider2D other){

if (other.tag == "Player") // Check if the collision is with the player
    {

    FindObjectOfType<PlayerStats>().TakeDamage(damage);  // Deal damage to the player

    AudioManager.instance.RandomizeSfx(hit1, hit2); // Play a random hit sound effect
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
