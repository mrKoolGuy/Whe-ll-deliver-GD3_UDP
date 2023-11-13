using System;
using Unity.Collections;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    [SerializeField]
    private float rotationTorque;
    [SerializeField]
    private float movementForce; // force in newton
    [SerializeField]
    private float maxSpeed; //maximum Speed in m/s
    [SerializeField]
    private float sidewaysFriction;
    [SerializeField]
    private float breakingForce;
    

    private Rigidbody rbody;
    
    //original transform used to reset the player when he falls of the platform
    private Vector3 origPosition;
    private Quaternion origRotation;



    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        origPosition = transform.position;
        origRotation = transform.rotation;
    }

    // limit the maximum reachable speed of the player
    void LimitMaxSpeed()
    {
        Vector3 xzSpeed = rbody.velocity;
        //ignore the y, we alone want the speed along the flat speed
        xzSpeed.y = 0;

        xzSpeed = Vector3.ClampMagnitude(xzSpeed, maxSpeed);
        rbody.velocity = new Vector3(xzSpeed.x, rbody.velocity.y, xzSpeed.z);
    }
    
    //if the player falls below the platform, reset the position
    private void ResetFallenPlayer()
    {
        if (rbody.transform.position.y < -10)
        {
            transform.position = origPosition;
            transform.rotation = origRotation;
            rbody.velocity = Vector3.zero;
        }
    }

    //This simulates the sideways friction on the wheels off the wheelchair, and applies brakes to the wheels when the player is not controlling the speed
    private void ApplyBreakingAndSidewaysFriction()
    {
        //objectVelocity is the current velocity viewed from the direction of the player
        Vector3 objectVelocity = transform.InverseTransformDirection(rbody.velocity);
        float sidewaysSpeed = objectVelocity.x;
        float forwardSpeed = objectVelocity.z;

        //apply the sideways friction as force proportional to sideways speed
        rbody.AddForce(transform.TransformDirection(sidewaysFriction * sidewaysSpeed * Vector3.left));
        
        //if the player is not actively going forward or backward, apply a braking force
        if (Mathf.Approximately(Input.GetAxis("Vertical"), 0))
            rbody.AddForce(transform.TransformDirection(breakingForce * forwardSpeed * Vector3.back));
    }



    private void FixedUpdate()
    {
        // get vertical user input and apply a force to create back and forth movement
        rbody.AddForce(rbody.transform.forward * (Input.GetAxis("Vertical") * movementForce));
        
        // get horizontal user input and apply a force to rotate the player
        rbody.angularVelocity = Vector3.up * (Input.GetAxis("Horizontal") * rotationTorque);

        ApplyBreakingAndSidewaysFriction();
        LimitMaxSpeed();
        ResetFallenPlayer();
        
    }
}
