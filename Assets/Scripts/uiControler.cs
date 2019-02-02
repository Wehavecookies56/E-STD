using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiControler : MonoBehaviour
{
    public GameObject deathPannel;

    public GameObject getHurtPannel;
    public GameObject getHurtRed;
    private Color hurtPannelColour;

    public GameObject sanityPannel;
    private Color sanityColour;

    public float hardIntesity = 0.6f;
    public float mediumIntesity = 0.4f;
    public float softIntesity = 0.2f;
    public float lerpSpeed = 0.1f;

    public GameObject menu;

    private void Start()
    {
        hurtPannelColour = getHurtPannel.GetComponent<Image>().color;
        sanityColour = sanityPannel.GetComponent<Image>().color;
    }

    private void FixedUpdate()
    {

        //you died screen
        if (playerData.INSTANCE.Health <= 0)
        {
            deathPannel.SetActive(true);
        }

        //screen fade to red
        if (playerData.INSTANCE.Health <= 1)
        {
            hurtPannelColour.a = Mathf.Lerp(hurtPannelColour.a, hardIntesity, lerpSpeed);
            getHurtPannel.GetComponent<Image>().color = hurtPannelColour;
            getHurtRed.GetComponent<Image>().color = hurtPannelColour;
        }
        else if (playerData.INSTANCE.Health <= 3)
        {
            hurtPannelColour.a = Mathf.Lerp(hurtPannelColour.a, mediumIntesity, lerpSpeed);
            getHurtPannel.GetComponent<Image>().color = hurtPannelColour;
            getHurtRed.GetComponent<Image>().color = hurtPannelColour;
        }
        else if (playerData.INSTANCE.Health <= 5)
        {
            hurtPannelColour.a = Mathf.Lerp(hurtPannelColour.a, softIntesity, lerpSpeed);
            getHurtPannel.GetComponent<Image>().color = hurtPannelColour;
        }
        else if (playerData.INSTANCE.Health > 5)
        {
            hurtPannelColour.a = Mathf.Lerp(hurtPannelColour.a, 0f, lerpSpeed);
            getHurtPannel.GetComponent<Image>().color = hurtPannelColour;
            getHurtRed.GetComponent<Image>().color = hurtPannelColour;
        }

        //loosing sanity
        if (playerData.INSTANCE.Sanity <= 1)
        {
            sanityColour.a = Mathf.Lerp(sanityColour.a, hardIntesity, lerpSpeed);
            sanityPannel.GetComponent<Image>().color = sanityColour;
        }
        else if (playerData.INSTANCE.Sanity <= 3)
        {
            sanityColour.a = Mathf.Lerp(sanityColour.a, mediumIntesity, lerpSpeed);
            sanityPannel.GetComponent<Image>().color = sanityColour;
        }
        else if (playerData.INSTANCE.Sanity <= 5)
        {
            sanityColour.a = Mathf.Lerp(sanityColour.a, softIntesity, lerpSpeed);
            sanityPannel.GetComponent<Image>().color = sanityColour;

        }
        else if (playerData.INSTANCE.Sanity > 5)
        {
            sanityColour.a = Mathf.Lerp(sanityColour.a, 0f, lerpSpeed);
            sanityPannel.GetComponent<Image>().color = sanityColour;
        }
        
    }


    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}


