﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController cc;
    public float speed = 10f;
    // gravity
    float yspeed = 0;
    float gravity = -15f;
    public Transform fpscamera;
    float pitch = 0f;

    [Range(5, 15)]
    public float mouseSensitivity = 10f;

    [Range(45, 85)]
    public float pitchRange = 45f;

    // member input values
    float xInput = 0f;
    float zInput = 0f;
    float xMouse = 0f;
    float yMouse = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        UpdateMovement();
        soundManagerScript.audioPlayer.FootSteps(soundManagerScript.footsteps.WOOD, gameObject.transform, cc.velocity.x + cc.velocity.z);

    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal") * speed;
        zInput = Input.GetAxis("Vertical") * speed;
        xMouse = Input.GetAxis("Mouse X") * mouseSensitivity * Time.timeScale;
        yMouse = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.timeScale;
    }

    void UpdateMovement()
    {
        Vector3 move = new Vector3(xInput, 0, zInput);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        if (cc.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yspeed = 15f;
            }
            else
            {
                yspeed = gravity * Time.deltaTime;
            }
        }
        else
        {
            yspeed += gravity * Time.deltaTime;
        }
        // applys the movement

        cc.Move(move + new Vector3(0, yspeed, 0) * Time.deltaTime);
        transform.Rotate(0, xMouse, 0);
        pitch -= yMouse;
        pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);
        Quaternion camRotation = Quaternion.Euler(pitch, 0, 0);
        fpscamera.localRotation = camRotation;
    }
}


