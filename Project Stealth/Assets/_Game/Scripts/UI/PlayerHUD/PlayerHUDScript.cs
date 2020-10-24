using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDScript : MonoBehaviour
{
    [HideInInspector] public Text txtCoin;
    [HideInInspector] public int curCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        txtCoin = transform.Find("TxtCoin").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
