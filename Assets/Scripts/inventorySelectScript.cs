using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySelectScript : MonoBehaviour
{
    public GameObject[] slots;
    [SerializeField]
    private int counter = 0;
    private float timer;
    public float inputDeley;
    private bool complateMove = false;

    private void Update()
    {     
        if (Input.GetAxis("JoystickDpadY") < -0.3f)
        {
            
            if (complateMove == false)
            {
                counter++;
                complateMove = true;
            }
            if (counter > 9) counter = 0;
        }
        if (Input.GetAxis("JoystickDpadY") > 0.3f)
        {
            if (complateMove == false)
            {
                counter--;
                complateMove = true;
            }
            if (counter < 0) counter = 9;
        }

        if(Input.GetAxis("JoystickDpadY") < 0.3f && Input.GetAxis("JoystickDpadY") > -0.3f)
        {
            complateMove = false;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            if (slots[counter].transform.childCount != 0)
            {
                if(slots[counter].transform.GetChild(0).CompareTag("axe"))
                slots[counter].transform.GetChild(0).GetComponent<onAxeClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("key"))
                    slots[counter].transform.GetChild(0).GetComponent<onkeyClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("armour"))
                    slots[counter].transform.GetChild(0).GetComponent<onArmourClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("book"))
                    slots[counter].transform.GetChild(0).GetComponent<onBookClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("candle"))
                    slots[counter].transform.GetChild(0).GetComponent<onCandleClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("feather"))
                    slots[counter].transform.GetChild(0).GetComponent<onFeatherClick>().onClick();

            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        switchControl();

    }
    private void spinTheChild(int index)
    {
       
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].transform.childCount != 0)
            {
                slots[i].GetComponentInChildren<spinItem>().go = false;
            }             
        }

        if (slots[index].transform.childCount != 0)
        {
            slots[index].GetComponentInChildren<spinItem>().go = true;
        }
    }
    private void switchControl()
    {
        switch (counter)
        {

            case 0:
                spinTheChild(0);
                break;

            case 1:
                spinTheChild(1);
                break;

            case 2:
                spinTheChild(2);
                break;

            case 3:
                spinTheChild(3);
                break;

            case 4:
                spinTheChild(4);
                break;

            case 5:
                spinTheChild(5);
                break;

            case 6:
                spinTheChild(6);
                break;

            case 7:
                spinTheChild(7);
                break;

            case 8:
                spinTheChild(8);
                break;

            case 9:
                spinTheChild(9);
                break;
        }
    }
}
