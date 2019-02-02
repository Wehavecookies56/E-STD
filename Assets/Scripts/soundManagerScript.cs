using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour
{
    public static soundManagerScript audioPlayer { get; private set; }

    public enum enviromentSounds { DOOROPEN, THUNDER1, THUNDER2, GHOSTSCREAM, POTBREAK };
    public GameObject[] enviromentAudio;

    public enum backgroundSounds { HORRORLOOP };
    public GameObject[] backroundSounds;

    public enum footsteps { WOOD };
    public GameObject[] footstepsSound;
    public float MaxFootstepVolume;
    private GameObject footstepsInstance;
    bool created = false;

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
    }

    public void playOnce(enviromentSounds sound, Transform position)
    {
        GameObject instance = Instantiate(enviromentAudio[(int)sound]);
        instance.transform.position = transform.position;
        instance = null;
    }

    public void startLoop(backgroundSounds sound, Transform parent)
    {
        GameObject instance = Instantiate(backroundSounds[(int)sound]);
        instance.transform.SetParent(parent);
    }

    public void FootSteps(footsteps type, Transform parent, float speed)
    {
        
        if(created == false)
        {
            footstepsInstance = Instantiate(footstepsSound[(int)type]);
            footstepsInstance.transform.SetParent(parent);
            created = true;
        }
        
        if(Mathf.Abs(speed) > 0.1f)
        {
            footstepsInstance.GetComponent<AudioSource>().volume = MaxFootstepVolume;
        }
        else if(Mathf.Abs(speed) < 0.1f)
        {
            footstepsInstance.GetComponent<AudioSource>().volume = 0f;
        }
    }

    

}
