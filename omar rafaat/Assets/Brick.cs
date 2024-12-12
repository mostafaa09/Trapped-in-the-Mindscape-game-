using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite explodedBlock;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // This function is called when a collision happens
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collider is tagged as "Player" and the contact point is below the brick
        if (other.gameObject.tag == "Player" && other.GetContact(0).point.y  transform.position.y)
        {
            // Change the sprite to explodedBlock
            sr.sprite = explodedBlock;

            // Destroy the brick after a short delay
            Destroy(gameObject, 0.2f);
        }
    }
}
