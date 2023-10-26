using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collinding with somthing");
        if (other.CompareTag("Player"))
        {
            Debug.Log("collinding with player");

            Rigidbody rbody = other.attachedRigidbody;
            rbody.AddForce(rbody.transform.up * 100);

        }
    }

}
