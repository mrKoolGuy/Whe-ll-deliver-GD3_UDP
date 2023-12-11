using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GD.Selection
{
    //This selection response allows the player to select an object with a key and drag or push it with him.
    //It also signal the state of the object to the user with different materials.
    [CreateAssetMenu(fileName = "SO_GrabRigidbodySelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/GrabRigidbody")]
    [Serializable]
    public class SO_GrabRigidbodySelectionResponse : ScriptableObject, ISelectionResponse
    {
        // Old meterial
        [SerializeField]
        private Material onSelectMaterial;
        
        [SerializeField]
        private Material onPickupMaterial;

        //Outline Setup
        [SerializeField]
        private Color onSelectColor = Color.yellow;

        [SerializeField]
        private Color onPickupColor = Color.blue;

        [SerializeField]
        private float OutlineWidth = 10;
        [SerializeField]
        private float OutlineDistanceMultipy = 10;
        
        [SerializeField]
        Outline.Mode OutlineMode = Outline.Mode.OutlineAll;

        [SerializeField]
        private AudioClip pickupAudioClip;
        [SerializeField]
        private AudioClip setDownAudioClip;

        //Empty Game Event to handle OnPlayerGrabbed
        [SerializeField] EmptyGameEvent onGrabbed;

        [SerializeField]
        [Tooltip("This key will be used to find the player in the dictionary of SearchableObjects")]
        private SearchableObjectKey playerKey;
        
        //This is pointing from the player to the point where the pushable object is attached to the player
        private Vector3 relativePushablePosition = Vector3.zero;
        private Material originalMaterial;
        private float originalMass;

        //this is used to make the pushable object light so the player is able to move it
        private float featherWeight = 0.1f;

        //True whenever the player grabs something, which means the grabbed object can be pushed or pulled
        private bool grabbing = false;
        
        public void OnSelect(Transform transform)
        {
            //Save original material and apply the onSelectMaterial
            Renderer renderer = transform.GetComponent<Renderer>();
            if (renderer is not null)
            {
                Rigidbody pushableBody = transform.GetComponent<Rigidbody>();
                originalMaterial = transform.GetComponent<Renderer>()?.material;
                originalMass = pushableBody.mass;
                renderer.material = onSelectMaterial;
            }
            Outline outline = transform.GetComponent<Outline>();
            if (outline is null)
            {
                outline = transform.AddComponent<Outline>();
                
            }
            if(outline is not null)
            {
                outline.OutlineColor = onSelectColor;
                outline.OutlineWidth = OutlineWidth;
                outline.OutlineMode = OutlineMode;
                outline.OutlineDistanceMultipy = OutlineDistanceMultipy;
                outline.enabled = true;
            }
        }

        public void WhileSelected(Transform transform)
        {
            Rigidbody pushableBody = transform.GetComponent<Rigidbody>();
            
            //Gets the underlying physics representation of the player (the capsule)
            //TODO: do it more modular, but setting a SerializeField for a property doesn't work
            //      because this is a scriptable object, which can not contain reverences to in game objects 
            GameObject playerObject = SearchableObjects.FindObject(playerKey);
            Rigidbody playerBody = playerObject.GetComponent<Rigidbody>();
            Outline outline = transform.GetComponent<Outline>();
            //pressing the configured grab button toggles if a object is grabbable and pushable
            if (Input.GetButtonDown("Grab"))
            {
                Renderer renderer = transform.GetComponent<Renderer>();
                if (!grabbing)
                {
                    //reduces the mass of the rigidbody, and allows it to be pushed around
                    grabbing = true;
                    if(onGrabbed)
                        onGrabbed.Raise(new Empty());
                    pushableBody.mass = featherWeight;
                    //Allows movement in x and z of the pushable object by unfreezing
                    //this works through clearing the bits for freezing x and z position, it is not affecting any other bits
                    pushableBody.constraints &= ~(RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ);

                    if (renderer is not null)
                        renderer.material = onPickupMaterial;
                    if(outline is not null)
                        outline.OutlineColor = onPickupColor;
                    AudioSource.PlayClipAtPoint(pickupAudioClip, transform.position);
                }
                else
                {
                    //restores the original mass and constraints, which blocks any movement from the player on it.
                    grabbing = false;
                    pushableBody.mass = originalMass;
                    pushableBody.constraints |= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                    if (renderer is not null)
                        renderer.material = onSelectMaterial;
                    if (outline is not null)
                        outline.OutlineColor = onSelectColor;
                    AudioSource.PlayClipAtPoint(setDownAudioClip, transform.position);
                }
                relativePushablePosition = pushableBody.position - playerBody.transform.position;
            }
            
            //makes the selected object follow the players position
            if (grabbing)
            {
                //The position change should be mirrored between the player and the selected object.
                //To avoid bugging through objects we don't set the desired position, but instead calculate a velocity to bring the ramp there.
                //This enables the physics system to stop the pushable object on collisions.
                Vector3 optimalPushablePosition = playerBody.position + relativePushablePosition;
                //this calculates the velocity needed to get to the optimalPushablePosition
                //even so this is called indirectly in an update function, we have to use fixedDeltaTime, because physics is only updated in the fixed intervals 
                Vector3 pushableVelocity = (optimalPushablePosition - pushableBody.position) / Time.fixedDeltaTime;
                //The y velocity of the selected object is unchanged, so it follows the terrain.
                pushableBody.velocity = new Vector3(pushableVelocity.x, pushableBody.velocity.y, pushableVelocity.z);
            }
        }

        public void OnDeselect(Transform transform)
        {
            
            if (transform.TryGetComponent(out Rigidbody body))
            {
                if (grabbing)
                {
                    grabbing = false;
                    //restores the original mass in the pushable object
                    body.mass = originalMass;
                    //This freezes position in x and z but still allows the pushable object to fall down through gravity
                    body.constraints |= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                    
                    AudioSource.PlayClipAtPoint(setDownAudioClip, transform.position);
                }
                
                //change back to original Material
                if (transform.TryGetComponent<Renderer>(out var renderer))
                    renderer.material = originalMaterial;

                if (transform.TryGetComponent<Outline>(out var outline))
                {
                    outline.OutlineColor = Vector4.zero;
                    outline.enabled = false;
                }
            }
        }
    }
}