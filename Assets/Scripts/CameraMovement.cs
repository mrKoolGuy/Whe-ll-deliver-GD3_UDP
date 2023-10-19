using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject target;

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {   
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(target.transform.position, target.transform.up, Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(target.transform.position, -target.transform.up, Time.deltaTime * speed);
        }
    }
}
