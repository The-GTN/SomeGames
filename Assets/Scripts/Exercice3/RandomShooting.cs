using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShooting : MonoBehaviour
{

    public GameObject fire;
    public float minpower = 50.0f;
    public float maxpower = 250.0f;
    int step = 0;
    public int intervalFire = 50; 
    public Transform optiplayer;

    // Start is called before the first frame update
    void Start()
    {
        optiplayer = GameObject.Find("OptiPlayer").transform;
    }

    void Update() {
        transform.LookAt(optiplayer.position);
        step += 1;
        if(step > intervalFire) {
            step = 0;
            shoot();
        }
    }

    void shoot() {
        GameObject s = Instantiate(fire, transform.position + 2*transform.up, Quaternion.identity);
        Rigidbody r = s.GetComponent(typeof(Rigidbody)) as Rigidbody;
        float p = UnityEngine.Random.Range(minpower, maxpower);
        Vector3 dir = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f));
        r.AddForce(dir*p);
    }
}
