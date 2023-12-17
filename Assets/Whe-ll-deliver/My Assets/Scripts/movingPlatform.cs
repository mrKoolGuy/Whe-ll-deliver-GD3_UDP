using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class movingPlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3 moveDirection;
    [SerializeField]
    private double duration;
    [SerializeField]
    private float moveSpeed;

    private bool movingForward;
    private Vector3 movingDirection;
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 aToB;
    private Vector3 bToA;


    private void Awake()
    {
        movingDirection = GameObject.Find("Move Direction").transform.forward;
        pos1 = GameObject.Find("Point a").transform.position;
        pos2 = GameObject.Find("Point b").transform.position;

        aToB = pos2 - pos1;
        bToA = pos1 - pos2;

        aToB.Normalize();
        bToA.Normalize();

        movingForward = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingForward)
        {
            transform.position += aToB * moveSpeed * Time.deltaTime;
            if (transform.position.x <= pos2.x)
            {
                transform.position = pos2;
                movingForward = false;
            }
        }
        else
        {
            transform.position += bToA * moveSpeed * Time.deltaTime;
            if (transform.position.x >= pos1.x)
            {
                transform.position = pos1;
                movingForward = true;
            }
        }
    }
}
