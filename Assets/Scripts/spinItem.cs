using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinItem : MonoBehaviour
{
    public bool go = false;

    private void Update()
    {
        if(gameObject.tag == "armour")
        {
            if(go == true)
            {
                GameObject.FindGameObjectWithTag("armourModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("armourModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }

        if (gameObject.tag == "key")
        {
            if (go == true)
            {
                GameObject.FindGameObjectWithTag("keyModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("keyModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }

        if (gameObject.tag == "axe")
        {
            if (go == true)
            {
                GameObject.FindGameObjectWithTag("axeModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("axeModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }
    }
}
