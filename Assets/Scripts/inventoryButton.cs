using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryButton : MonoBehaviour
{
    public GameObject description;

    private void Start()
    {
        description = GameObject.FindGameObjectWithTag("UIkey");
    }

    private void OnMouseOver()
    {
        description.SetActive(true);
        Debug.Log("mouse over");
    }

    private void OnMouseExit()
    {
        description.SetActive(false);
    }
}
