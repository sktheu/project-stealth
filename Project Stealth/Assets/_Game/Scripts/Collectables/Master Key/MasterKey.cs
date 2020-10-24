using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterKey : MonoBehaviour
{
    [SerializeField] private GameObject panelEnd;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")){
            StopPlayer(other.gameObject);
            panelEnd.SetActive(true);
            Destroy(gameObject);
        }
    }


    private void StopPlayer(GameObject player)
    {
        Rigidbody2D rbPlayer = player.GetComponent<Rigidbody2D>();
        rbPlayer.velocity = new Vector2(0, rbPlayer.velocity.y);
        
        player.GetComponent<PlayerMovement>().enabled = false;
    }
    
}
