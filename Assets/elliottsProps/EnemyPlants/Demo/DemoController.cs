using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoController : MonoBehaviour
{
    public Transform plant1, plant2, plant3, plant4;
    public Transform camera1, camera2, camera3, camera4;
    public GameObject sporePlant1, sporePlant2, sporePlant31, sporePlant32, sporePlant33, sporePlant34;
    public bool isOnPlant1, isOnPlant2, isOnPlant3, isOnPlant4;
    private Animator animator;
    public SimpleRotate simpleRotateR;
    public SimpleRotate simpleRotateL;
    public bool lightOn = true;
    public Transform camLookAt;
    private Light lt;
    private bool idleReadyOn;

    private void Start()
    {
        lt = GameObject.Find("/DirectionalLight").GetComponent<Light>();
    }

    private void Update()
    {
        if(animator == null)
        {
            animator = plant1.gameObject.GetComponentInChildren<Animator>();
        }
        camera1.Translate(Vector3.right * Time.deltaTime);
        camera1.LookAt(camLookAt);
        camera2.Translate(Vector3.right * Time.deltaTime);
        camera2.LookAt(camLookAt);
        camera3.Translate(Vector3.right * Time.deltaTime);
        camera3.LookAt(camLookAt);
        camera4.Translate(Vector3.right * Time.deltaTime);
        camera4.LookAt(camLookAt);

        if (lightOn)
        {
            lt.intensity = 1.5f;
        }
        else 
        {
            lt.intensity = 0.1f;
        }

        if (!idleReadyOn)
        {
            animator.SetFloat("IdleStance", 0f, 0.1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("IdleStance", 1f, 0.1f, Time.deltaTime);
        }
    }

    public void ToggleLight()
    {
        lightOn = !lightOn;
    }

    //Choosing plant view

    public void SetPlant1Camera()
    {
        DisableSpores();
        isOnPlant2 = false;
        isOnPlant3 = false;
        isOnPlant4 = false;
        isOnPlant1 = true;
        simpleRotateR.target = plant1;
        simpleRotateL.target = plant1;
        animator = plant1.gameObject.GetComponentInChildren<Animator>();
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
    }

    public void SetPlant2Camera()
    {
        DisableSpores();
        isOnPlant1 = false;
        isOnPlant3 = false;
        isOnPlant4 = false;
        isOnPlant2 = true;
        simpleRotateR.target = plant2;
        simpleRotateL.target = plant2;
        animator = plant2.gameObject.GetComponentInChildren<Animator>();
        camera2.gameObject.SetActive(true);
        camera1.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
    }

    public void SetPlant3Camera()
    {
        DisableSpores();
        isOnPlant1 = false;
        isOnPlant2 = false;
        isOnPlant3 = true;
        isOnPlant4 = false;
        simpleRotateR.target = plant3;
        simpleRotateL.target = plant3;
        animator = plant3.gameObject.GetComponentInChildren<Animator>();
        camera3.gameObject.SetActive(true);
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
    }

    public void SetPlant4Camera()
    {
        DisableSpores();
        isOnPlant1 = false;
        isOnPlant2 = false;
        isOnPlant3 = false;
        isOnPlant4 = true;
        simpleRotateR.target = plant4;
        simpleRotateL.target = plant4;
        animator = plant4.gameObject.GetComponentInChildren<Animator>();
        camera3.gameObject.SetActive(false);
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(false);
        camera4.gameObject.SetActive(true);
    }

    public void DisableSpores()
    {
        sporePlant1.SetActive(false);
        sporePlant2.SetActive(false);
        sporePlant31.SetActive(false);
        sporePlant32.SetActive(false);
        sporePlant33.SetActive(false);
        sporePlant34.SetActive(false);
    }

    //Animations

    public void PlayIdle()
    {
        idleReadyOn = false;
        animator.SetTrigger("Idle");
        animator.SetFloat("IdleStance", 0f, 1, Time.deltaTime);
        sporePlant1.SetActive(false);
        sporePlant2.SetActive(false);
        sporePlant31.SetActive(false);
        sporePlant32.SetActive(false);
        sporePlant33.SetActive(false);
        sporePlant34.SetActive(false);
    }

    public void PlayIdleReady()
    {
        idleReadyOn = true;
        animator.SetTrigger("Idle");
        animator.SetFloat("IdleStance", 1f, 1, Time.deltaTime);
        sporePlant1.SetActive(false);
        sporePlant2.SetActive(false);
        sporePlant31.SetActive(false);
        sporePlant32.SetActive(false);
        sporePlant33.SetActive(false);
        sporePlant34.SetActive(false);
    }

    public void PlayMeleeAttack()
    {
        animator.SetTrigger("MeleeAttack");
        sporePlant1.SetActive(false);
        sporePlant2.SetActive(false);
        sporePlant31.SetActive(false);
        sporePlant32.SetActive(false);
        sporePlant33.SetActive(false);
        sporePlant34.SetActive(false);
    }

    public void PlayRangeAttack()
    {
        animator.SetTrigger("RangeAttack");
        sporePlant1.SetActive(false);
        sporePlant2.SetActive(false);
        sporePlant31.SetActive(false);
        sporePlant32.SetActive(false);
        sporePlant33.SetActive(false);
        sporePlant34.SetActive(false);
    }

    public void PlaySpell()
    {
        animator.SetTrigger("Spell");
        if (isOnPlant1)
        {
            sporePlant1.SetActive(true);
            sporePlant2.SetActive(false);
            sporePlant31.SetActive(false);
            sporePlant32.SetActive(false);
            sporePlant33.SetActive(false);
            sporePlant34.SetActive(false);
        }
        if (isOnPlant2)
        {
            sporePlant1.SetActive(false);
            sporePlant2.SetActive(true);
            sporePlant31.SetActive(false);
            sporePlant32.SetActive(false);
            sporePlant33.SetActive(false);
            sporePlant34.SetActive(false);
        }
        if (isOnPlant3)
        {
            sporePlant1.SetActive(false);
            sporePlant2.SetActive(false);
            sporePlant31.SetActive(true);
            sporePlant32.SetActive(true);
            sporePlant33.SetActive(true);
            sporePlant34.SetActive(true);
        }
        if (isOnPlant4)
        {
            sporePlant1.SetActive(false);
            sporePlant2.SetActive(false);
            sporePlant31.SetActive(false);
            sporePlant32.SetActive(false);
            sporePlant33.SetActive(false);
            sporePlant34.SetActive(false);
        }

    }

    public void PlayDeath()
    {
        animator.SetTrigger("Death");
        sporePlant1.SetActive(false);
        sporePlant2.SetActive(false);
        sporePlant31.SetActive(false);
        sporePlant32.SetActive(false);
        sporePlant33.SetActive(false);
        sporePlant34.SetActive(false);
    }
}
