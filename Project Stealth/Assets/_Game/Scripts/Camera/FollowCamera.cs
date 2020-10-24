using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [HideInInspector] public Transform target;
    
    [Header("Camera Clamp:")]
    [SerializeField] private float minX = 0;
    [SerializeField] private float maxX = 0;
    [SerializeField] private float minY = 0;
    [SerializeField] private float maxY = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        if (target != null){
            transform.position = target.position + new Vector3(0, 0, -10f);
        }

        CameraClamp();
        
    }


    private void CameraClamp()
    {
        float xx = Mathf.Clamp(transform.position.x, minX, maxX);
        float yy = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(xx, yy, transform.position.z);
    }
}
