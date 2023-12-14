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
        }
        else
        {
            //revert back to just setting the values here if there is no respawn script.
            transform.position = spawnPointTransform.position;
            transform.rotation = spawnPointTransform.rotation;
        }
    }
}
