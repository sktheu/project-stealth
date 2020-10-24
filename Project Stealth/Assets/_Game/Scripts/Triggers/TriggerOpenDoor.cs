using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpenDoor : MonoBehaviour
{

    // References
    [SerializeField] private GameObject triggerNextLevel;
    private Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        doorAnim = GameObject.Find("Environment").transform.Find("Door").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            triggerNextLevel.SetActive(true);
            doorAnim.Play("Door Opening");
            Destroy(gameObject);
        }
    }
}
