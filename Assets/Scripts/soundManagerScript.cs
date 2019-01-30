using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour
{
    public static soundManagerScript audioPlayer { get; private set; }

    public enum characterSounds { };
    public GameObject[] characterAudio;

    public enum enviromentSounds { DOOROPEN, THUNDER1, THUNDER2};
    public GameObject[] enviromentAudio;

    public enum backgroundSounds { HORRORLOOP };
    public GameObject[] backroundSounds;

    private void Awake()
    {
        if (audioPlayer == null)
        {
            audioPlayer = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        startLoop(backgroundSounds.HORRORLOOP, gameObject.transform);
        playOnce(enviromentSounds.THUNDER2, gameObject.transform);
        
    }

    public void playOnce(enviromentSounds sound, Transform position)
    {
       
               GameObject instance =  Instantiate(enviromentAudio[(int)sound]);
                instance.transform.position = transform.position;
                instance = null;
       
    }

    public void startLoop(backgroundSounds sound, Transform parent)
    {
        switch(sound)
        {
            case backgroundSounds.HORRORLOOP:
                GameObject instance = Instantiate(backroundSounds[(int)sound]);
                instance.transform.SetParent(parent);
                break;
        }
    }

}
