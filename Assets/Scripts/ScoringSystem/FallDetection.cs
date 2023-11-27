using GD;
using UnityEngine;

//This script measures if the player fell down a distance greater than a specified threshold and raises an event.
//It requires a Collider in Trigger on the player, which also can be in a child.
namespace ScoringSystem
{
    public class FallDetection : MonoBehaviour
    {
        [SerializeField]
        private EmptyGameEvent onPlayerFallen;
    
        [SerializeField] [Range(0, 10)]
        private float fallDamageHeightThreshold;
    
        //Stores the position of the player where he last lost contact to a collider.
        //If this is not zero this also implies, that the player is falling.
        //(Or on a edge, but that doesn't matter for this implementation)
        private Vector3 lastContactPosition = Vector3.zero;

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger) return; //ignore triggers
        
            if (lastContactPosition != Vector3.zero &&
                lastContactPosition.y - transform.position.y > fallDamageHeightThreshold &&
                onPlayerFallen)
            {
                onPlayerFallen.Raise(new Empty());
            }

            lastContactPosition = Vector3.zero; //clear fall state
        }

        private void OnTriggerExit(Collider other)
        {
            if(!other.isTrigger) //ignore triggers
                lastContactPosition = transform.position;
        }
    }
}
