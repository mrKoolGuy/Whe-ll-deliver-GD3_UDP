using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;



public class Characteranimator : MonoBehaviour
{
    [SerializeField]
    private GameObject WheelRight;
    [SerializeField]
    private GameObject ArmRight;
    [SerializeField]
    private GameObject WheelLeft;
    [SerializeField]
    private GameObject ArmLeft;
    [SerializeField]
    float Animation_speed_coration = 1;
    [SerializeField]
    float Animation_Rotationdelta_coration = 1;
    [SerializeField]
    float Animation_Arm_coration = 1;
    [SerializeField]
    float Animation_Armdelta_coration = 1.5f;






    float framer = 0;
    float framel = 0;


    private Rigidbody rbody;
    private void AnimateWheels()
    {
        //get speed properties 
        float speed = transform.InverseTransformDirection(rbody.velocity).z * Animation_speed_coration;
        float rotationdelta = rbody.angularVelocity.y * Animation_Rotationdelta_coration;

        //Apply Wheel the rotation 
        WheelLeft.transform.Rotate(Vector3.up * (speed + rotationdelta));
        WheelRight.transform.Rotate(Vector3.up * (speed - rotationdelta));

        voxelanimator right = ArmRight.GetComponent<voxelanimator>();  
        voxelanimator left = ArmLeft.GetComponent<voxelanimator>();
        float speedarme =0f;
        float indeltarme = 0f;
        float outdeltarme = 0f;



            speedarme = 1 / (right.famecount * Animation_Arm_coration) * speed;
            indeltarme = 1 / (right.famecount * Animation_Armdelta_coration) * rotationdelta /(1+ speed);
            outdeltarme = 1 / (right.famecount * Animation_Armdelta_coration) * rotationdelta/(1+speed);

        if (rotationdelta > 0) {
                framer += speedarme  + outdeltarme;
                framel += speedarme  - indeltarme;

            } 
            else if (rotationdelta < 0) { 
                framer += speedarme - indeltarme;
                framel += speedarme + outdeltarme;
            }
            else {
                framer += speedarme;
                framel = framer;


            }


        framer = (8 + framer) % 8;
        framel = (8 + framel) % 8;
        if (speed < 0.0000001 && speed > -0.0000001 && rotationdelta==0)
        {
            framer = 0;
            framel = 0;
        }

        ArmRight.GetComponent<voxelanimator>().setframe((int)framel);
        ArmLeft.GetComponent<voxelanimator>().setframe((int)framer);

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
