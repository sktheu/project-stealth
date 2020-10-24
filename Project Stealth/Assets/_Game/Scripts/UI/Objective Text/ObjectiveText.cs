using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveText : MonoBehaviour
{
    [SerializeField] private float fadeInSpeed = 0;
    [SerializeField] private float fadeOutSpeed = 0;


    private Text txtObjective;

    [HideInInspector] public bool fadeIn = false;
    private bool fadeOut = false;


    private float curA = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        txtObjective = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Fade in Text
        if (fadeIn){
            curA += fadeInSpeed * Time.deltaTime;
            txtObjective.color = new Color(255, 255, 255, curA);

            if (curA >= 1){
                curA = 1;
                fadeOut = true;
                fadeIn = false;
            }
        }

        // Fade out Text
        if (fadeOut){
            curA -= fadeOutSpeed * Time.deltaTime;
            txtObjective.color = new Color(255, 255, 255, curA);

            if (curA <= 0){
                Destroy(gameObject);
            }
        }

        
    }

}
