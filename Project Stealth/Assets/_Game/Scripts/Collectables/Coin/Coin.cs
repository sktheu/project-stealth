using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private PlayerHUDScript playerHudScript;

    void Awake()
    {
        playerHudScript = GameObject.Find("Canvas").transform.Find("Player HUD").GetComponent<PlayerHUDScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            SetCoins();
            Destroy(gameObject);
        }
    }


    private void SetCoins()
    {
        playerHudScript.curCoins++;
        playerHudScript.txtCoin.text = "X " + playerHudScript.curCoins.ToString();
    }
}
