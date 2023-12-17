using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shader.Collision
{
    [CreateAssetMenu(fileName = "Collision", menuName = "DkIT/Scriptable Objects/Other/Responses/CollisionEffect")]
 
    public class CollisionEffect : ScriptableObject
    {
        /*
         This object stores all the necessary data for the shake effect. When a collision is detected.
        */
        [SerializeField]
        public AnimationCurve shakegraph;
        [SerializeField]
        public Vector2 offset_Range_X ;
        [SerializeField]
        public Vector2 offset_Range_Y;
        [SerializeField]
        public Vector2 offset_Range_Z;

        public AnimationCurve getshake(){ return shakegraph; }
        public Vector2 get_ofset_Range_X() { return offset_Range_X; }
        public Vector2 get_ofset_Range_Y() { return offset_Range_Y; }
        public Vector2 get_ofset_Range_Z() { return offset_Range_Z; }


    }
}
