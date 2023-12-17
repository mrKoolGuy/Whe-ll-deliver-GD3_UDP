using System;
using UnityEngine;


namespace Colision
{
    [CreateAssetMenu(fileName = "TrampolineCollisionBehaviour", menuName = "DkIT/Scriptable Objects/Behaviours/CollisionBehaviour/Trampoline")]
    [Serializable]
    public class Trampoline : CollisionBehaviour
    {
        [SerializeField]
        private Vector3 jumpDirection = new Vector3(0.0f, 1.0f, 0.0f);
        [SerializeField]
        private float jumpForce = 70.0f;
    
        public override void doaction(GameObject gobj, Collider otherCollider)
        {
            if (gobj.transform.position.y > otherCollider.transform.position.y+2.003)
            {
                Rigidbody rb1 = gobj.GetComponentInParent<Rigidbody>();
                rb1.velocity = Vector3.zero;
                rb1.angularVelocity = Vector3.zero;
                rb1.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
                otherCollider.transform.GetComponent<trampolineanimation>().onColision();
                //call the action implemented in CollisionBehaviour
                base.doaction(gobj, otherCollider);
            }
        }

    }
}
