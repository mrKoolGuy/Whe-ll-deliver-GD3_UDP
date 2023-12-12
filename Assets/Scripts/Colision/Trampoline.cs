using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Trampoline", menuName = "DkIT/Scriptable Objects/Actionbycollision/Trampoline")]
[Serializable]
public class Trampoline : bycolision
{
    [SerializeField]
    private Vector3 jumpDirection = new Vector3(0.0f, 1.0f, 0.0f);
    [SerializeField]
    private float jumpForce = 70.0f;
    [SerializeField]
    

    public override void doaction(GameObject gobj, Collider otherCollider)
    {
        if (gobj.transform.position.y > otherCollider.transform.position.y+2.003)
        {
            Rigidbody rb1 = gobj.GetComponentInParent<Rigidbody>();
            rb1.velocity = Vector3.zero;
            rb1.angularVelocity = Vector3.zero;
            rb1.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
            otherCollider.transform.GetComponent<trampolineanimation>().onColision();
            AudioSource.PlayClipAtPoint(sound, otherCollider.transform.position);

        }


    }

}
