using System;
using UnityEngine;

namespace GD.Selection
{
    //This selection response allows the player to select an object with a key and drag or push it with him.
    //It also signal the state of the object to the user with different materials.
    [CreateAssetMenu(fileName = "SO_GrabRigidbodySelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/GrabRigidbody")]
    [Serializable]
    public class SO_GrabRigidbodySelectionResponse : ScriptableObject, ISelectionResponse
    {
        [SerializeField]
        private Material onSelectMaterial;
        [SerializeField]
        private Material onPickupMaterial;
        
        private Vector3 relativePosition = Vector3.zero;
        private Material originalMaterial;
        public void OnSelect(Transform transform)
        {
            //Save original material and apply the onSelectMaterial
            Renderer renderer = transform.GetComponent<Renderer>();
            if (renderer is not null)
            {
                originalMaterial = transform.GetComponent<Renderer>()?.material;
                renderer.material = onSelectMaterial;
            }
        }

        public void WhileSelected(Transform transform)
        {
            Rigidbody body = transform.GetComponent<Rigidbody>();
            
            //Gets the underlying physics representation of the player (the capsule)
            //TODO: do it more modular, but setting a SerializeField for a property doesn't work
            //      because this is a scriptable object, which can not contain reverences to in game objects 
            GameObject playerObject = GameObject.Find("Capsule");
            
            //pressing the configured drag button toggles if a object is draggable and pushable
            if (Input.GetButtonDown("Drag"))
            {
                Renderer renderer = transform.GetComponent<Renderer>();
                if (body.isKinematic)
                {
                    //sets the selected object to a normal rigidbody which applies gravity, and allows it to be pushed around
                    body.isKinematic = false;
                    if (renderer is not null)
                        renderer.material = onPickupMaterial;
                }
                else
                {
                    //sets the rigidbody of the selected object to kinematic, which disables gravity and blocks any movement on it.
                    body.isKinematic = true;
                    if (renderer is not null)
                        renderer.material = onSelectMaterial;
                }
                relativePosition = transform.position - playerObject.transform.position;
            }

            //makes the selected object follow the players position
            //TODO: somehow prevent pushable objects from being able to be pushed into walls
            Rigidbody playerBody = playerObject.GetComponent<Rigidbody>();
            if (!body.isKinematic)
            {
                //gets the player velocity in the direction the player faces.
                Vector3 playerVelocity = playerObject.transform.InverseTransformDirection(playerBody.velocity); 
                if (playerVelocity.z > 0)//control ramp by velocity
                {
                    //If the player is moving forward, the selected object mimic the velocity of the player.
                    //The position approach from below makes it too easy for the player to bug objects into walls
                    //TODO: some bugging into walls is still present, prevent it somehow
                    body.velocity = playerBody.velocity;
                }
                else //control ramp by position
                {
                    //If the player is moving backward, mimicking the the velocity doesn't work because of the acceleration in the player.
                    //Instead the position change is mirrored between the player and the selected object.
                    //The y position of the selected object is unchanged, so it follows the terrain.
                    Vector3 newPosition = playerObject.transform.position + relativePosition;
                    transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
                }
            }
        }

        public void OnDeselect(Transform transform)
        {
            if (transform.TryGetComponent(out Rigidbody body))
            {
                //sets the rigidbody of the selected object to kinematic, which disables gravity and blocks any movement on it.
                body.isKinematic = true;
                
                //change back to original Material
                Renderer renderer = transform.GetComponent<Renderer>();
                if (renderer is not null)
                    renderer.material = originalMaterial;
            }
        }
    }
}