using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings:")]
    [SerializeField] private float moveHSpeed = 0;
    [SerializeField] private float moveVSpeed = 0;
    [SerializeField] private float jumpForce = 0;
    
    
    // Components
    private Rigidbody2D rb;


    private float moveH = 0;
    [HideInInspector] public bool canJump = false;

    private float defaultGravity = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();
    }


    void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveH * moveHSpeed, rb.velocity.y);
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Ladder")){
            rb.gravityScale = 0;
            canJump = false;
        }
    }


    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Ladder")){
            VerticalMovement();
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Ladder")){
            rb.gravityScale = defaultGravity;
        }
    }


    private void HorizontalMovement()
    {
        moveH = Input.GetAxisRaw("Horizontal");
    }

    private void VerticalMovement()
    {
        float moveV = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveV * moveVSpeed);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump){
            canJump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
