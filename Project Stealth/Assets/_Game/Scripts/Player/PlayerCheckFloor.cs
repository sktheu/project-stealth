using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckFloor : MonoBehaviour
{
    private PlayerMovement playerMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveScript = GetComponentInParent<PlayerMovement>();
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Floor") && playerMoveScript.enabled){
            playerMoveScript.canJump = true;
        }
    }


    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Floor") && playerMoveScript.enabled){
            playerMoveScript.canJump = false;
        }
    }
}
