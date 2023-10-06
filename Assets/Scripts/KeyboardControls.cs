using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed; // in degrees per second
    [SerializeField]
    private float movementSpeed; // in m per second

    void Update()
    {
        if(Input.GetKey("d"))
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        if(Input.GetKey("a"))
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        if (Input.GetKey("w"))
            transform.Translate(Vector3.back * (movementSpeed * Time.deltaTime));
        if(Input.GetKey("s"))
            transform.Translate(Vector3.forward * (movementSpeed * Time.deltaTime));
    }
}
