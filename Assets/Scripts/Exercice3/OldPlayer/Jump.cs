using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{

    public float jumpForce=5;
    public float gravity = -9.81f;
    float velocity;
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!isJumping) {
            if (Keyboard.current[Key.Space].wasPressedThisFrame){
                velocity = jumpForce;
                isJumping = true;
            }
        }
        if(isJumping) {
            velocity += gravity * Time.deltaTime;
            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isJumping) isJumping = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(!isJumping) isJumping = true;
    }


}
