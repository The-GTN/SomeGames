using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Top : MonoBehaviour
{
    void Start() {}

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector3.forward*(-0.05f), Space.Self);
        if (transform.position.z < -5) {
            changeScore(-10);
            Destroy(this.gameObject);
        }
    }

/*
    void OnCollisionEnter(Collision collision)
    {
        bool touch = false;
        foreach (ContactPoint contact in collision.contacts)
        {
            touch = true;
        }
        if (touch) {
            changeScore(10);
            Destroy(this.gameObject);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        GameObject his_o = other.gameObject.transform.GetChild(1).gameObject;
        GameObject my_o = transform.GetChild(1).gameObject;
        Material his = his_o.GetComponent<Renderer>().material;
        Material my = my_o.GetComponent<Renderer>().material;
        if (his.color == my.color) { 
            if(transform.position.y - other.gameObject.transform.position.y < 0) changeScore(10);
            else changeScore(5);
        }
        else changeScore(-5);
        Destroy(this.gameObject);
    }
    void changeScore(int points) {
        GameObject score = GameObject.Find("Score");
        Text text = score.GetComponent<Text>();
        text.text = ""+(int.Parse(text.text)+points);
    }
}
