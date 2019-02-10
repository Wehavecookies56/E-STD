﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate : MonoBehaviour
{
    public float anglestop;
    public float speed = 1;
   
    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
     

        
        if(speed < 0)
        {
             if(transform.eulerAngles.y > anglestop)
             {
             transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
             }
             else
             {
             transform.eulerAngles = new Vector3(transform.eulerAngles.x, anglestop, transform.eulerAngles.z);
             }
        }
        else
        {
            if (transform.eulerAngles.y < anglestop)
            {
                transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, anglestop, transform.eulerAngles.z);
            }
        }
      
    
    }

  
}
