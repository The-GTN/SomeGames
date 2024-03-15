using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Mapping : MonoBehaviour
{

    public Material ground;
    public Material water;
    public GameObject tourelle;
    public LayerMask floorMask;

    public static int nbTourelles = 0;

    public float XZsize = 3.0f;
    public float Ysize = 3.0f;
    float oldXZsize;
    float oldYsize;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OptiPlayer").transform;
        oldXZsize = XZsize;
        oldYsize = Ysize;
        ReadString();
    }

    // Update is called once per frame
    void Update()
    {
        if (oldXZsize != XZsize || oldYsize != Ysize) {
            foreach (Transform child in transform) GameObject.Destroy(child.gameObject);
            ReadString();
            oldXZsize = XZsize;
            oldYsize = Ysize;
        }
    }

    void setObject(char type,Vector3 p) {
        GameObject o;
        if(type == 'T') {
            o = Instantiate(tourelle,p,Quaternion.identity,transform);
            nbTourelles += 1;
        }
        else {
            o = GameObject.CreatePrimitive(PrimitiveType.Cube);
            o.transform.SetParent(transform);
            o.transform.position = p;
            if(type == 'E' ) o.GetComponent<Renderer>().material = ground;
            else if(type == 'W') o.GetComponent<Renderer>().material = water;
        }
        o.transform.localScale = new Vector3(XZsize,Ysize,XZsize);
        o.layer = (int) Mathf.Log(floorMask.value, 2);
    }


   public void ReadString()
   {
       string path = Application.persistentDataPath + "/terrain1.txt";
        try {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                float x = 0.0f;
                float z = 0.0f;
                float y;string[] subs;Vector3 p;
                while ((line = sr.ReadLine()) != null)
                {
                    subs = line.Split(',');
                    for(int i=0;i<subs.Length;i++) {
                        y = Int16.Parse(""+subs[i][0]);
                        p = new Vector3(x,y,z);
                        setObject(subs[i][1],p);
                        if(subs[i].Length == 3) {
                            p.y += 2*Ysize;
                            player.position = p;
                        }
                        x += XZsize;
                    }
                    z += XZsize;
                    x = 0.0f;
                }
            }
        }
        catch (Exception e){
            // Let the user know what went wrong.
            print("The file could not be read:");
            print(e.Message);
        }

   }
}
