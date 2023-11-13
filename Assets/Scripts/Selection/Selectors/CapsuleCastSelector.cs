using System;
using UnityEngine;

namespace GD.Selection
{
    public class CapsuleCastSelector : MonoBehaviour, ISelector
    {
        [SerializeField]
        private string selectableTag = "Selectable";
    
        [SerializeField]
        private LayerMask layerMask;
    
        [SerializeField]
        [Range(0.01f, 10)]
        private float radius = 1;
    
        [SerializeField]
        [Range(0, 1000)]
        private float maxDistance = 10;

        [SerializeField]
        [Tooltip("offset from first sphere of the capsule, which is defined by the ray origin to the second sphere of the capsule")]
        private Vector3 secondSphereOffset;
    
        private Transform selection;
        private RaycastHit hitInfo;
    
        public Transform GetSelection()
        {
            return selection;
        }
    
        public RaycastHit GetHitInfo()
        {
            return hitInfo;
        }
    
        public void Check(Ray ray)
        {
            selection = null;
            if (Physics.CapsuleCast(ray.origin, ray.origin + secondSphereOffset, radius, ray.direction, out hitInfo, maxDistance, layerMask.value))
            {
                var currentSelection = hitInfo.transform;
                if (currentSelection.CompareTag(selectableTag))
                    selection = currentSelection;
            }
        }
    }
}