using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire_Screeching : MonoBehaviour
{
    public AudioClip movementTurnSound;
    private AudioSource audioSource;
    private Rigidbody rbody;

    [SerializeField]
    private float movementThreshold = 0.1f; // Adjust this threshold to control when the sound should play

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Play_Tire_Screeching();
    }

    private void Play_Tire_Screeching()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Is the player is both moving and turning
        if (Mathf.Abs(horizontalInput) > movementThreshold && Mathf.Abs(verticalInput) > movementThreshold)
        {
            // Is sound not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.clip = movementTurnSound;
                audioSource.Play();
            }
        }
        else
        {
            // Stop the sound if the player is not moving and turning
            audioSource.Stop();
        }
    }
}