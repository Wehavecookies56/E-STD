//Script Written By Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlayerDetector : MonoBehaviour
{
    private Light l;

    private void Start()
    {
        l = GetComponent<Light>();
        l.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        l.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        l.enabled = false;
    }
}
