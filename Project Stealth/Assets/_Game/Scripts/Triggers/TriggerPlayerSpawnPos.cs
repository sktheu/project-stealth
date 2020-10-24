using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerSpawnPos : MonoBehaviour
{
    private GameObject playerSpawnPos;

    void Awake()
    {
        playerSpawnPos = GameObject.Find("Player Spawn Position");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")){
            playerSpawnPos.transform.position = this.transform.position;
            Destroy(gameObject);
        }
    }
}
