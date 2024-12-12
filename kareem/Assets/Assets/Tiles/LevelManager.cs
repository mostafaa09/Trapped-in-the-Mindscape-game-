using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckPoint;

    //create new function RespawnPlayer()

public void RespawnPlayer(){

    FindObjectOfType<PlayerController>().transform.position = CurrentCheckPoint.transform.position;
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
