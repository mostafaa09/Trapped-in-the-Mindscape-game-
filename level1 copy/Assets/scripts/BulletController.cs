using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
public float Speed; /// the speed of the bullet
public float timeremaining; ///the time will spend before the bullet destroy itself 
    // Start is called before the first frame update
    void Start()
    {
        
PlayerController player;
player = FindObjectOfType<PlayerController>();

if(player.transform.localScale.x < 0)  ////if the player way on the left (for the start of the game only)
{

Speed = -Speed;

transform.localScale = new Vector3(-(transform.localScale.x),transform.localScale.y,transform.localScale.z);
}

    }

    // Update is called once per frame
    void Update()
    {
        
GetComponent<Rigidbody2D>().velocity = new Vector2(Speed ,GetComponent<Rigidbody2D>().velocity.y);

if(timeremaining > 0){

timeremaining -= Time.deltaTime;

}else if(timeremaining <= 0){

Destroy(this.gameObject);
}
    }

    
void OnTriggerEnter2D(Collider2D other){

if(other.tag == "Enemy"){

Destroy(other.gameObject); ///destroy the enemy

Destroy(this.gameObject);///destroy the bullet on the enemy
}
}


}
