using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Saber : MonoBehaviour
{

    public Material red;
    public Material blue;
    public bool isRed;
    private float z;
    private GameObject o;

    // Start is called before the first frame update
    void Start()
    {
        isRed = true;
        z = 0.7f;
        o = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(Mouse.current.leftButton.wasPressedThisFrame) {
            if (isRed) o.GetComponent<Renderer>().material = blue;
            else o.GetComponent<Renderer>().material = red;
            isRed = !isRed;
        }
        

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = z;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        
    }

    void OnGUI()
    {
        z += Mouse.current.scroll.ReadValue().y*0.001f;
    }
}
