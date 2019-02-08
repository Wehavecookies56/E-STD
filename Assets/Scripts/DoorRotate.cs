using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate : MonoBehaviour
{

    public float rotFin = 0;
    public float counter;
    public float time;
    public float timer;
    public bool pause = true;

    // Use this for initialization
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (pause)
            {
                pause = false;
                timer = time;
            }
            else
            {
                pause = true;
                rotate();
                timer = time;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void rotate()
    {
        while(counter <= 90)
        {
            rotFin++;
            transform.Rotate(new Vector3(0, rotFin, 0 ));
            counter++;
        }
    }
}
