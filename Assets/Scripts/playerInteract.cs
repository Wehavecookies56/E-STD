using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour {

    public Transform playerLookCamera;
    //Raycast distance
    public float distance = 500;
    GameObject lastLookedAt;

    void Start() {
        
    }

    void Update() {
        RaycastHit rh;
        //Raycast from camera
        var r = new Ray(playerLookCamera.position, playerLookCamera.forward);
        //Raycast only for objects with items layer
        if (Physics.Raycast(r, out rh, distance, 1 << LayerMask.NameToLayer("items"))) {
            GameObject lookedAt = rh.transform.gameObject;
            lastLookedAt = lookedAt;
            //Boolean_446AB9C2 is the id for the "enabled" property in the item highlight shader
            lookedAt.GetComponent<MeshRenderer>().material.SetFloat("Boolean_446AB9C2", 1);
        } else {
            if (lastLookedAt != null) {
                lastLookedAt.GetComponent<MeshRenderer>().material.SetFloat("Boolean_446AB9C2", 0);
                lastLookedAt = null;
            }
        }
    }
}
