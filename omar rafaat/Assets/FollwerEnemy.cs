using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwerEnemy : EnemyController
{
    public float speedtowardplayer;  // Speed at which the enemy moves towards the player

    private PlayerController player; // Reference to the PlayerController script

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>(); // Find the PlayerController object in the scene
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedtowardplayer * Time.deltaTime); // Move the enemy towards the player's position at a constant speed

    }
}
