using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Settings:")]
    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float rayRange = 0;
    [SerializeField] private LayerMask rayIgnoreLayer;

    // Components
    private Rigidbody2D rb;
    private LineRenderer line;


    private float dirX = 1;
    private Vector3 rayOffset;

    private float lineEndPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rayOffset = new Vector3(0.5f * dirX, 0);

        SearchPlayer();
        DrawEnemyRay();
    }


    void FixedUpdate() 
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            ResetPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy Direction")){
            this.dirX *= -1;
        }
    }


    private void SearchPlayer()
    {   
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, new Vector2(dirX, 0), rayRange, ~rayIgnoreLayer);

        if (hit){
            if (hit.collider.gameObject.CompareTag("Player")){
                Destroy(hit.collider.gameObject);
                ResetPlayer();
            }

            lineEndPos = hit.distance;
        }else{
            lineEndPos = rayRange;
        }
        
    }


    private void DrawEnemyRay()
    {
        line.SetPosition(0, transform.position + rayOffset);
        line.SetPosition(1, (transform.position + rayOffset) + new Vector3(lineEndPos * dirX, 0, 0));
    }

    private void ResetPlayer()
    {
        GameObject.Find("Player Spawn Position").GetComponent<SpawnPlayer>().CreatePlayer();
    }

}
