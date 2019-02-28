using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject text;
    public GameObject cutCam;
    public GameObject startPos;
    public GameObject startCam;
    public GameObject player;
    public GameObject[] lightning;

    void Update()
    {
        if(Input.anyKeyDown == true)
        {
            //lighing sound
            //TODO
            //lighning prefab activates
            //pann the camer to player 
            cutCam.GetComponent<cutsceneHandler>().StartCutscene(startPos);
            //instaciate the player 
            //destroy the canvas
            for (int i = 0; i < lightning.Length; i++)
            {
                lightning[i].GetComponent<LightningTriggerer>().CreateLightning();
            }
            gameObject.SetActive(false);
            startCam.SetActive(false);
            player.SetActive(true);
        }
    }
}
