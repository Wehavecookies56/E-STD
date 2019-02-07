//Script written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderPlayer : MonoBehaviour
{
    //particle system component reference
    ParticleSystem ps;
    //array to hold lightning particles, there can only ever be 1 at a time
    ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1];
    //controls audio call to be once per particle
    bool needReset = false;
    
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        int numOfParticles = ps.GetParticles(particles);

        if (!needReset) //if particle hasn't already been detected
        {

            if (numOfParticles > 0)
            {
                Debug.Log("Triggered");
                needReset = true;
            }
        }
        else
        {
            if(numOfParticles < 1)
            {
                needReset = false;
            }
        }
        
    }
}
