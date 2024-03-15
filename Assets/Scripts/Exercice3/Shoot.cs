using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float duration = 150.0f; 
    float lifeTime = 0.0f;
    float stepLife = 1.0f;


    void Start() {}

    // Update is called once per frame
    void Update()
    {   
        lifeTime += stepLife;
        if(lifeTime > duration) Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    { 
        RandomShooting rs = other.gameObject.GetComponent(typeof(RandomShooting)) as RandomShooting;
        if(rs != null) Mapping.nbTourelles -= 1;
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }


}
