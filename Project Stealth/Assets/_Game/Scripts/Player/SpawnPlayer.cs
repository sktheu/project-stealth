using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    void Awake()
    {
        CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreatePlayer()
    {
        GameObject player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Camera.main.gameObject.GetComponent<FollowCamera>().target = player.transform;
    }
}
