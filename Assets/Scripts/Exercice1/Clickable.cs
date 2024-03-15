using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Math
using System;

using UnityEngine.InputSystem;

public class Clickable : MonoBehaviour
{

    Vector3 dirScroll;
    bool canMove;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        dirScroll = (Camera.main.transform.position - transform.position);
        float norm = (float) Math.Sqrt(Math.Pow(dirScroll.x,2) + Math.Pow(dirScroll.y,2) + Math.Pow(dirScroll.z,2));
        if (norm >= 1) dirScroll = dirScroll.normalized;
        else dirScroll = new Vector3(0,0,1);
        z = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if(Mouse.current.leftButton.wasPressedThisFrame) {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hitInfo);

            if (hit) {
                if (hitInfo.transform.gameObject == transform.gameObject) {
                    canMove = true;
                }
            }
        }
        
        if(Mouse.current.leftButton.wasReleasedThisFrame) {
            canMove = false;
        }

        if(canMove) {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            mousePosition.z = z;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }

    }

    void OnGUI()
    {
        if(canMove) {
            //Vector3 v;
            //v = (Camera.main.transform.position - transform.position);
            //float norm = (float) Math.Sqrt(Math.Pow(v.x,2) + Math.Pow(v.y,2) + Math.Pow(v.z,2));
            //if(norm >= 1) dirScroll = v.normalized;
            //transform.position += dirScroll*Input.mouseScrollDelta.y*0.2f;
            z += Mouse.current.scroll.ReadValue().y*0.001f;
        }
    }


}
