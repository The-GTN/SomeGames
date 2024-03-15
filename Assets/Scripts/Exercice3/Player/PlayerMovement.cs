using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public LayerMask floorMask;
    public float speed = 5.0f;
    public float gravity = -9.81f;
    public float jumpForce = 2.0f;
    public float treshFall = -20.0f;

    Vector2 horizontalInput;

    Vector3 horizontalVelocity = Vector3.zero;
    Vector3 verticalVelocity = Vector3.zero;

    public GameObject init;
    public GameObject win;
    public GameObject fall;
    public GameObject loose;

    bool isFloor;
    bool jump;
    public bool hurt = false;

    public void receiveInput(Vector2 _horizontalInput) {
        horizontalInput = _horizontalInput;
    }

    void Start(){}

    void Update(){

        ui();

        isFloor = Physics.CheckSphere(transform.position-(new Vector3(0.0f,1.0f,0.0f)),0.1f,floorMask);
        if(isFloor) verticalVelocity = Vector3.zero;

        horizontalVelocity = speed * (horizontalInput.x * transform.right + horizontalInput.y * transform.forward);
        controller.Move(horizontalVelocity * Time.deltaTime);
  
        if(jump && isFloor) {
            verticalVelocity.y = Mathf.Sqrt(-2.0f * jumpForce * gravity);
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void onJump() {
        if(isFloor) jump = true;
    }

    public void ui() {
        if(hurt) {
            init.SetActive(false);
            win.SetActive(false);
            fall.SetActive(false);
            loose.SetActive(true);
        }
        else if(Mapping.nbTourelles == 0) {
            fall.SetActive(false);
            init.SetActive(false);
            loose.SetActive(false);
            win.SetActive(true);
        }
        else if(transform.position.y < treshFall) {
            init.SetActive(false);
            win.SetActive(false);
            loose.SetActive(false);
            fall.SetActive(true);
        }


    }

}
