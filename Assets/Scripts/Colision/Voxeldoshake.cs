using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Voxeldoshake", menuName = "DkIT/Scriptable Objects/Actionbycollision/Voxeldoshake")]
[Serializable]
public class Voxeldoshake : bycolision

{
    public override void doaction(GameObject gobj, Collider otherCollider) {
        otherCollider.transform.GetComponent<VertexWavesShaderLogic>().DoShake();
        if (sound is not null)
        {
            AudioSource.PlayClipAtPoint(sound, otherCollider.transform.position);
        }
    }
}
