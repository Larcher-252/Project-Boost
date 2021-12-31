using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource boostAudio;
    [SerializeField] float thrustSpeed = 250f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] AudioClip boostSound;
    [SerializeField] ParticleSystem leftParticle;
    [SerializeField] ParticleSystem rightParticle;
    [SerializeField] ParticleSystem mainParticle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boostAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else
        {
            EndThrust();
        }
    }

    void StartThrust()
    {
        // Add force movement
        rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        // Play booster SFX
        if (!boostAudio.isPlaying)
        {
            boostAudio.PlayOneShot(boostSound);
        }
        // Start booster's particle
        if (!mainParticle.isPlaying)
        {
            mainParticle.Play();
        }
    }

    void EndThrust()
    {
        // Stop SFX
        if (boostAudio.isPlaying) 
        {
            boostAudio.Stop();
        }
        // Stop particle
        if (mainParticle.isPlaying)
        {
            mainParticle.Stop();   
        }
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.RightArrow))
        {
            leftParticle.Stop();
            rightParticle.Stop();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            StartRotating(rightParticle, leftParticle, rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            StartRotating(leftParticle, rightParticle, -rotateSpeed);
        }
        else
        {
            leftParticle.Stop();
            rightParticle.Stop();
        }
    }

    void StartRotating(ParticleSystem currentParticle, ParticleSystem otherParticle, float speed)
    {
        // Turn on particle on this side
         if (!currentParticle.isPlaying)
         {
            currentParticle.Play();
         }
         // Turn off particle on other side
         if (otherParticle.isPlaying)
         {
            otherParticle.Stop();
         }
        // Rotate
        RocketRotation(speed);
    }

    void RocketRotation(float currentRotate)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * currentRotate * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
