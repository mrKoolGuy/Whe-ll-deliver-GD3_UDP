using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    public List<bycolision> actionlist;

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
            foreach (bycolision action in actionlist)
            {
                if (action.check(otherCollider)){
                    action.doaction(gobj, otherCollider); break;
                }
            }
        }
        
        
    }
}
