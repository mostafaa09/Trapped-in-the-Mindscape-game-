using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barell : MonoBehaviour
{
    private SpriteRenderer sr; // used to change the sprite

public Sprite explodedBlock; // the new sprite
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    //create onCollisionEnter2D()

void OnCollisionEnter2D(Collision2D other){

//when player touch the sprite from bottom only
    if(other.gameObject.tag == "Player" && other.GetContact(0).point.y > transform.position.y){

        sr.sprite = explodedBlock;
        
        Object.Destroy(gameObject, 0.2f); //wait for a fraction time the destroy old block
    }
}
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
