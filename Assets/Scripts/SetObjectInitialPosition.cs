using Cinemachine;
using UnityEngine;

public class SetObjectInitialPosition : MonoBehaviour
{
    [SerializeField]
    private SearchableObjectKey spawnPointKey;

    //This copies the position and rotation from a transform found through the key
    public void SetInitialPosition()
    {
        Transform spawnPointTransform = SearchableObjects.FindObject(spawnPointKey).transform;

        if (TryGetComponent(out Respawn respawn))
        {
            //this makes sure the object will also respawn here if it falls
            respawn.SetSpawnPositionAndRotation(spawnPointTransform);
            respawn.RespawnObject();
        } else if(TryGetComponent(out CinemachineFreeLook cinemachine)) //if it is a cinemachine camera setting position normally doesn't work
        {
            cinemachine.ForceCameraPosition(spawnPointTransform.position, spawnPointTransform.rotation);
        }
        else
        {
            //revert back to just setting the values here if there is no respawn script.
            transform.position = spawnPointTransform.position;
            transform.rotation = spawnPointTransform.rotation;
        }
    }
}
