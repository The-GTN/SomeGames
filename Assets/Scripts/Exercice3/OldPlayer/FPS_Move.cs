using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Move : MonoBehaviour
{

    private Vector3 moveDir;
    private Transform head;
    private Transform player;
    private Jump jump;
    public float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        moveDir = new Vector3(0,0,0);
        head = GameObject.Find("Neck").transform;
        player = GameObject.Find("Player").transform;
        jump = gameObject.GetComponent(typeof(Jump)) as Jump;
    }

    // Update is called once per frame
    void Update()
    {
        moveControls();
        move();
    }

    void moveControls() {
        avant();
        arriere();
        droite();
        gauche();
        moveDir *= Time.deltaTime*speed; //amplitude de déplacement selon vitesse
    }

    void avant() {
        if (Input.GetKey(KeyCode.Z)) {
            moveDir += Vector3.forward; // avant = (0,0,1)
        }
    }

    void arriere() {
        if (Input.GetKey(KeyCode.S)) {
            moveDir -= Vector3.forward;
        }
    }

    void droite() {
        if (Input.GetKey(KeyCode.D)) {
            moveDir += Vector3.right; // droite = (1,0,0)
        }
    }

    void gauche() {
        if (Input.GetKey(KeyCode.Q)) {
            moveDir -= Vector3.right;
        }
    }

    void move() {
        Vector3 move = moveDir;
        move = head.TransformDirection(move);
        move.y = 0.0f;
        player.Translate(move,Space.World);
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if(other.name!="Floor") {
            Vector3 move = other.transform.position - transform.position;
            if(!jump.isJumping) move.y = -1.0f;
            else move.y = 0.0f;
            player.Translate(-0.4f*move,Space.World);
        }
    }

    private void OnTriggerExit(Collider other) {
        
    }


}

