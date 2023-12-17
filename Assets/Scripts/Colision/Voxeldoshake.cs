using System;
using Colision;
using UnityEngine;


[CreateAssetMenu(fileName = "VoxeldoshakeCollisionBehaviour", menuName = "DkIT/Scriptable Objects/Behaviours/CollisionBehaviour/Voxeldoshake")]
[Serializable]
public class Voxeldoshake : CollisionBehaviour
{
    public override void doaction(GameObject gobj, Collider otherCollider) {
        otherCollider.transform.GetComponent<VertexWavesShaderLogic>().DoShake();
        //call the action implemented in CollisionBehaviour
        base.doaction(gobj, otherCollider);
    }
}
