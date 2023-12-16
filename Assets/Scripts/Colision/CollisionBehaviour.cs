using UnityEngine;

namespace Colision
{
    public class CollisionBehaviour : AudioBehaviour
    {
        [SerializeField]
        public string tag;
    
        public virtual bool check(Collider otherCollider) {
            return otherCollider.CompareTag(tag);
        }

        public virtual void doaction(GameObject gobj, Collider otherCollider)
        {
            PlayRandomSound(otherCollider.transform.position);
        }
    }
}
