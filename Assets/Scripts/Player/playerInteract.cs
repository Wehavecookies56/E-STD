using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractEvent : UnityEvent<GameObject> {
    
}

public class playerInteract : MonoBehaviour {

    public Transform playerLookCamera;
    public GameObject inv;
    //Raycast distance
    public float distance = 500;
    public GameObject lastLookedAt;

    public LayerMask mask;

    [SerializeField]
    public InteractEvent onInteract;

    void Start() {
        if (onInteract == null)
            onInteract = new InteractEvent();
    }

    void Update() {
        RaycastHit rh;
        //Raycast from camera
        var r = new Ray(playerLookCamera.position, playerLookCamera.forward);
        //Raycast only for objects with items layer
        if (Physics.Raycast(r, out rh, distance, mask)) {
            if (1 << rh.transform.gameObject.layer == 1 << LayerMask.NameToLayer("items")) {
                GameObject lookedAt = rh.transform.gameObject;
                lastLookedAt = lookedAt;
                //Boolean_446AB9C2 is the id for the "enabled" property in the item highlight shader
                lookedAt.GetComponent<MeshRenderer>().material.SetFloat("Boolean_446AB9C2", 1);
                if (Input.GetButtonDown("Fire1")) {
                    onInteract.Invoke(lookedAt);
                }
            } else {
                if (lastLookedAt != null) {
                    lastLookedAt.GetComponent<MeshRenderer>().material.SetFloat("Boolean_446AB9C2", 0);
                    lastLookedAt = null;
                }
            }
        } else {
            if (lastLookedAt != null) {
                lastLookedAt.GetComponent<MeshRenderer>().material.SetFloat("Boolean_446AB9C2", 0);
                lastLookedAt = null;
            }
        }
    }

    public void pickUpItem(GameObject item) {
        //Add to inventory here
        if (item.GetComponent<objectScript>().data.Type == ObjectType.PICKUP) {
            Debug.Log("Pick up " + item.name);
            item.GetComponent<InventoryItemPickUp>().pickUpItem();
        }

        if (item.GetComponent<objectScript>().data.Type == ObjectType.TOUCH) {
            if (item.GetComponent<objectScript>().data.name.Equals("Vase")) {
                item.GetComponent<breakVase>().Break();
            }
        }

        if (item.GetComponent<objectScript>().data.Type == ObjectType.OPEN)
        {
            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Door"))
            {

                if (item.GetComponent<DoorRotate>().needskey)
                {
                    if (inv.GetComponent<inventorySelectScript>().isThereAKey() == true)
                    {

                        item.GetComponent<DoorRotate>().opening = true;
                        soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.DOOROPEN, item.transform);
                        item.layer = 1 << LayerMask.NameToLayer("Default");
                        item.GetComponent<BoxCollider>().isTrigger = true;
                        inv.GetComponent<inventorySelectScript>().deleteKey();
                    }
                }
                else
                {
                    item.GetComponent<DoorRotate>().opening = true;
                    soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.DOOROPEN, item.transform);
                    item.layer = 1 << LayerMask.NameToLayer("Default");
                    item.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            else if(item.GetComponent<objectScript>().data.ObjectName.Equals("Window"))
            {
                item.GetComponent<windowOpenClose>().opening = true;
                soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.WINDOW, item.transform);
                item.layer = 1 << LayerMask.NameToLayer("Default");
               
            }
        }
    }
    
  
}

