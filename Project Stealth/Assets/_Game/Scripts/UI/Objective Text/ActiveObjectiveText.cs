using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectiveText : MonoBehaviour
{
    private ObjectiveText objectiveTextScript;   

    // Start is called before the first frame update
    void Start()
    {
        objectiveTextScript = GameObject.Find("Canvas").transform.Find("TxtObjective").GetComponent<ObjectiveText>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")){
            objectiveTextScript.fadeIn = true;
            Destroy(gameObject);
        }
    }
}
