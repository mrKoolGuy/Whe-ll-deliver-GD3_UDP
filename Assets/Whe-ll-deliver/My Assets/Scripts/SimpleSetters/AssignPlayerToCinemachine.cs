using Cinemachine;
using GD;
using UnityEngine;

public class AssignPlayerToCinemachine : MonoBehaviour
{
    [SerializeField]
    private SearchableObjectKey playerKey;
    
    public void FindAndAttachPlayer(GameLevel level)
    {
        CinemachineFreeLook freeLook = transform.GetComponent<CinemachineFreeLook>();
        Transform playerTransform = SearchableObjects.FindObject(playerKey).transform;
        freeLook.LookAt = playerTransform;
        freeLook.Follow = playerTransform;
    }
}
