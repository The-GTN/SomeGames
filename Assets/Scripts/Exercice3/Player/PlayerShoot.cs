using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

#pragma warning disable 108

    public GameObject fire;
    public float power = 55.0f;
    bool loading = false;
    float energy = 0.0f;

    private Transform hand;
    private Transform camera;

    void Start() {
        hand = GameObject.Find("Hand.R").transform;
        camera = GameObject.Find("Camera").transform;
        }

    // Update is called once per frame
    void Update()
    {
        if(loading) energy += power;
    }

    public void onShoot() {
        if(!loading) loading = true;
        else shoot();
    }

    void shoot() {
        GameObject s = Instantiate(fire, hand.position + camera.forward, Quaternion.identity);
        Rigidbody r = s.GetComponent(typeof(Rigidbody)) as Rigidbody;
        Vector3 dir = (camera.forward + camera.up*0.3f)*energy;
        r.AddForce(dir);
        loading = false;
        energy = 0.0f;
    }
}
