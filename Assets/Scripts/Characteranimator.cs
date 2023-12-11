using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;



public class Characteranimator : MonoBehaviour
{
    [SerializeField]
    private GameObject Wheel_Right;
    [SerializeField]
    private GameObject Arm_Right;
    [SerializeField]
    private GameObject Wheel_Left;
    [SerializeField]
    private GameObject Arm_Left;
    [SerializeField]
    float Animation_Wheel_speed_correction = 1;
    [SerializeField]
    float Animation_Wheel_delta_correction = 1;
    [SerializeField]
    float Animation_Arm_speed_correction = 1;
    [SerializeField]
    float Animation_Arm_delta_correction = 1.5f;

    [SerializeField]
    private int restIndex;


    float Frame_Right = 0;
    float Frame_Left = 0;


    private Rigidbody rbody;
    private void AnimateWheels()
    {
        //get speed properties 
        float speed = transform.InverseTransformDirection(rbody.velocity).z * Animation_Wheel_speed_correction;
        float rotationdelta = rbody.angularVelocity.y * Animation_Wheel_delta_correction;

        //Apply Wheel the rotation 
        Wheel_Left.transform.Rotate(Vector3.up * (speed + rotationdelta));
        Wheel_Right.transform.Rotate(Vector3.up * (speed - rotationdelta));

        voxelanimator right = Arm_Right.GetComponent<voxelanimator>();  
        voxelanimator left = Arm_Left.GetComponent<voxelanimator>();
        float speedarme =0f;
        float indeltarme = 0f;
        float outdeltarme = 0f;



            speedarme = 1 / (right.famecount * Animation_Arm_speed_correction) * speed;
            indeltarme = 1 / (right.famecount * Animation_Arm_delta_correction) * rotationdelta /(1+ speed);
            outdeltarme = 1 / (right.famecount * Animation_Arm_delta_correction) * rotationdelta/(1+speed);

        if (rotationdelta > 0) {
                Frame_Right += speedarme  + outdeltarme;
                Frame_Left += speedarme  - indeltarme;

        } 
        else if (rotationdelta < 0) { 
            Frame_Right += speedarme - indeltarme;
            Frame_Left += speedarme + outdeltarme;
        }
        else {
            Frame_Right += speedarme;
            Frame_Left = Frame_Right;
        }


        Frame_Right = (8 + Frame_Right) % 8;
        Frame_Left = (8 + Frame_Left) % 8;
        if (speed < 0.0000001 && speed > -0.0000001 && rotationdelta==0)
        {
            Frame_Right = restIndex;
            Frame_Left = restIndex;
        }

        Arm_Right.GetComponent<voxelanimator>().setframe((int)Frame_Left);
        Arm_Left.GetComponent<voxelanimator>().setframe((int)Frame_Right);

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
