using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
#pragma warning disable 108

    public Transform camera;
    public float MinRotation = -20.0f;
    public float MaxRotation = 90.0f;
    public float MaxHeadRotation = 90.0f;
    public float MinHeadRotation = -5.0f;
    public bool inversed = false;

    public float sensitivityX = 3.0f;
    public float sensitivityY = 0.5f;

    float mouseX,mouseY;
    float rotX = 0.0f;

    private Transform head;
    private Transform spine;

    void Start() {
        head = GameObject.Find("Neck").transform;
        spine = GameObject.Find("Spine").transform;
    }

    public void receiveInput(Vector2 mouseInput) {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

    void Update() { 
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
        RotateYCamera();
        RotateBody();
    }

    void RotateYCamera() {
        float i = -1.0f;
        if(inversed) i *= -1.0f;
        rotX += i*mouseY;
        rotX = Mathf.Clamp(rotX,MinRotation-MinHeadRotation,MaxRotation+MaxHeadRotation);
        Vector3 rotation = transform.eulerAngles;
        rotation.x = rotX;
        //camera.eulerAngles = rotation;
    }

    void RotateBody() {
        Vector3 rotation = transform.eulerAngles;
        float tmp = Mathf.Clamp(rotX,MinRotation,MaxRotation);
        rotation.x = tmp;
        spine.eulerAngles = rotation;
        rotation.x = 2*rotX-tmp;
        head.eulerAngles = rotation;
    }


}
