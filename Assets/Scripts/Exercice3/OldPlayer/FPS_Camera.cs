using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Camera : MonoBehaviour
{

    private Transform head;
    private Transform spine;
    private Transform player;
    private Transform arm;

    private Vector2 deltaMouse;
    
    public float sensitivity = 25.0f;
    public bool inversion = false;

    public float spineRotate = 0.25f;
    public float spineNegRotate = -0.1f;
    public float headBottomRot = 0.4f;
    public float headTopRot = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        head = GameObject.Find("Neck").transform;
        spine = GameObject.Find("Spine").transform;
        player = GameObject.Find("Player").transform;
        arm = GameObject.Find("UpperArm.r").transform;

        deltaMouse = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
    }

    // Update is called once per frame
    void Update()
    {
        deltaMouse = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        deltaMouse *= Time.deltaTime * sensitivity;
        playerRotate();
    }

    void playerRotate() {
        float rotate = deltaMouse.x;
        if(inversion) rotate *= -1.0f;
        player.Rotate(0,rotate,0);
        playerRotateUpDown();
    }

    void playerRotateUpDown() {
        playerRotateUp();
        playerRotateDown();
    }

    void playerRotateUp() {
        bool isup = (deltaMouse.y < 0);
        if (isup && spineNegRotate < spine.localRotation.x) spine.Rotate(deltaMouse.y,0,0);
        else if (isup && headTopRot <= head.localRotation.x) head.Rotate(deltaMouse.y,0,0);
        else if (isup && -spineRotate <= spine.localRotation.x) spine.Rotate(deltaMouse.y,0,0);
    }

    void playerRotateDown() {
        bool isdown = (deltaMouse.y > 0);
        if (isdown && spineNegRotate > spine.localRotation.x) spine.Rotate(deltaMouse.y,0,0);
        else if (isdown && headBottomRot >= head.localRotation.x) head.Rotate(deltaMouse.y,0,0);
        else if (isdown && spineRotate >= spine.localRotation.x) spine.Rotate(deltaMouse.y,0,0);
    }
 
}