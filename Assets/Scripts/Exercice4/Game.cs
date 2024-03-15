using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject[] cases;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float alea = UnityEngine.Random.Range(0.0f, 100.0f);
        if (alea < 1.0f) Instantiate(cases[UnityEngine.Random.Range(0,cases.Length)], 
            new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f),
                        UnityEngine.Random.Range(1.5f, 2.0f),
                        25.0f), 
            Quaternion.identity);
    }
}
