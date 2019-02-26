using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInventoryDeleteThisScriptLater : MonoBehaviour
{
    public GameObject inventory;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(inventory.GetComponent<inventorySelectScript>().isThereAKey() == true)
            {
                inventory.GetComponent<inventorySelectScript>().deleteKey();
            }

            inventory.GetComponent<inventorySelectScript>().dropAxe();
        }
    }
}
