using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    float speedRotate = 2.0f;
    Vector3 origin = new Vector3(0.0f,0.0f,0.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(origin, Vector3.up, speedRotate);
        transform.LookAt(origin);
    }
}
