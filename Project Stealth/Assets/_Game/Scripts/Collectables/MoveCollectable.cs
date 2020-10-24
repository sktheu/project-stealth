using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCollectable : MonoBehaviour
{
    [Header("Movement Settings:")]
    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float maxTime = 0;

    private float curTime = 0;

    private float dirY = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeDirY();
    }




    private void ChangeDirY()
    {
        curTime += Time.deltaTime;
        if (curTime >= maxTime){
            curTime = 0;
            dirY *= -1;
        }
    }

    private void Move() 
    {
        transform.position += Vector3.up * moveSpeed * dirY * Time.deltaTime;
    }
}
