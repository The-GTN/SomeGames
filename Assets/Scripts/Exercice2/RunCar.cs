using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RunCar : MonoBehaviour
{

    float rotate = 2.0f;
    public float speed = 0.2f;
    public static bool crash = false;

    public Transform BL, BR, FR, FL, Circle;
    public Camera MyCam;

    // Start is called before the first frame update
    void Start()
    {
        BL = this.gameObject.transform.GetChild(0).GetChild(0);
        BR = this.gameObject.transform.GetChild(0).GetChild(1);
        Circle = this.gameObject.transform.GetChild(0).GetChild(2);
        FL = this.gameObject.transform.GetChild(0).GetChild(29);
        FR = this.gameObject.transform.GetChild(0).GetChild(30);
        MyCam = this.gameObject.transform.GetChild(4).gameObject.GetComponent(typeof(Camera)) as Camera;
    }

    // Update is called once per frame
    void Update()
    {
        BL.Rotate(rotate, 0, 0, Space.Self);
        BR.Rotate(rotate, 0, 0, Space.Self);
        Circle.Rotate(rotate, 0, 0, Space.Self);
        FL.Rotate(rotate, 0, 0, Space.Self);
        FR.Rotate(rotate, 0, 0, Space.Self);

        transform.Translate(Vector3.forward*speed, Space.Self);

        if(!crash) {
            float random = UnityEngine.Random.Range(0.1f,0.5f);
            rotate += 0.2f*random;
            speed += random;
        }
        else {
            MyCam.rect = new Rect(0.0f, 0.0f, 1.0f, 0.5f);
            MyCam.depth = 1;
                
            if(speed > 0.0f) speed -= 0.2f;
            if(speed < 0.0f) speed = 0.0f;
            rotate = 0.0f;
        }
    }
}
