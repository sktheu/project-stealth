using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    private Text txtEnd2;

    private float maxTime = 0.35f;
    private float curTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        txtEnd2 = transform.Find("TxtEnd2").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimText(txtEnd2);
    }


    private void AnimText(Text txt)
    {
        curTime += Time.deltaTime;
        if (curTime >= maxTime){
            curTime = 0;
            if (txt.enabled){
                txt.enabled = false;
            }else{
                txt.enabled = true;
            }
        }
    }
}
