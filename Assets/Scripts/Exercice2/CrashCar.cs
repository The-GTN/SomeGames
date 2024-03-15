using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCar : MonoBehaviour
{

    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {

        RunCar myRun = gameObject.GetComponent(typeof(RunCar)) as RunCar;
        if (myRun != null) {
            RunCar hisRun = other.gameObject.GetComponent(typeof(RunCar)) as RunCar;
            if(hisRun != null) {
                if(myRun.speed <= hisRun.speed) {
                    if(!RunCar.crash) {
                        //Instantiate(fire, Vector3.zero, Quaternion.identity);
                        Instantiate(fire, transform.position, Quaternion.identity);
                    }
                    Destroy(this.transform.gameObject);
                    RunCar.crash = true;
                }
            }
        }
            
    }

}
