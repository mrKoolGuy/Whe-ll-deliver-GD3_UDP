using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Characteranimator : MonoBehaviour
{
    [SerializeField]
    private GameObject WheelRight;
    [SerializeField]
    private GameObject WheelLeft;
    [SerializeField]
    float Animation_speed_coration = 1;
    [SerializeField]
    float Animation_Rotationdelta_coration = 1;

    private Rigidbody rbody;
    private void AnimateWheels()
    {
        //get speed properties 
        float speed = transform.InverseTransformDirection(rbody.velocity).z * Animation_speed_coration;
        float rotationdelta = rbody.angularVelocity.y * Animation_Rotationdelta_coration;

        //Apply Wheel the rotation 
        WheelLeft.transform.Rotate(Vector3.up * (speed + rotationdelta));
        WheelRight.transform.Rotate(Vector3.up * (speed - rotationdelta));
    }
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        AnimateWheels();
    }
}
