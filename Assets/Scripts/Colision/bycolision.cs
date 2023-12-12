using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bycolision : ScriptableObject
{
    [SerializeField]
    public string tag;
    [SerializeField]
    public AudioClip sound;
    public virtual bool check(Collider otherCollider) {
        return otherCollider.CompareTag(tag); }
    public virtual void doaction(GameObject gobj, Collider otherCollider) { }
}
