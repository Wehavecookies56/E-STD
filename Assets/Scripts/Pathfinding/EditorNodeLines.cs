﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]

public class EditorNodeLines : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        foreach (GameObject target in GetComponent<PathNode>().connectedNodes)
        {
            if (target != null)
            {
                // Draws a blue line from this transform to the target
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, target.transform.position);
            }
        }
    }
}