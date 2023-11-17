using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    private Vector3 jumpDirection = new Vector3(0.0f, 1.0f, 0.0f);
    [SerializeField]
    private float jumpForce = 70.0f;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.attachedRigidbody;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
        }
    }

}
