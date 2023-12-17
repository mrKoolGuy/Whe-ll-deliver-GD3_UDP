using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //TODO: make this globally accessible in the Unity Inspector
    //game object gets respawned if it is under this y value in its position
    private static float lowerWorldLimit = -10;
    
    //original transform used to reset the player when he falls of the platform
    private Vector3 origPosition;
    private Quaternion origRotation;
    
    void Start()
    {
        SetSpawnPositionAndRotation(transform);
    }

    public void SetSpawnPositionAndRotation(Transform spawnTransform)
    {
        origPosition = spawnTransform.position;
        origRotation = spawnTransform.rotation;
    }

    public void RespawnObject()
    {
            transform.position = origPosition;
            transform.rotation = origRotation;
            if (TryGetComponent<Rigidbody>(out var body))
                body.velocity = Vector3.zero;
    } 
    
    void FixedUpdate()
    {
        //if the object falls below the platform, reset the position, rotation and if it has a rigidbody also it's velocity
        if (transform.position.y < lowerWorldLimit)
        {
            RespawnObject();
        }
    }
}
