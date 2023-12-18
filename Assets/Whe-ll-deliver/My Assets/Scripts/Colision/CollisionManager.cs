using System.Collections;
using System.Collections.Generic;
using Colision;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    public List<CollisionBehaviour> actionlist;

    private GameObject gobj;
    void Start()
    {
        // Verweise auf das eigene GameObject
         gobj = this.gameObject;
    }

        void OnCollisionEnter(Collision collision)
    {
        Collider otherCollider = collision.collider; ;
        if (!otherCollider.CompareTag("Untagged"))
        {
            foreach (CollisionBehaviour action in actionlist)
            {
                if (action.check(otherCollider)){
                    action.doaction(gobj, otherCollider); break;
                }
            }
        }
        
        
    }
}
