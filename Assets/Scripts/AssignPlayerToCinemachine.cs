using Cinemachine;
using GD;
using UnityEngine;

public class AssignPlayerToCinemachine : MonoBehaviour
{
    public void FindAndAttachPlayer(Empty empty)
    {
        CinemachineFreeLook freeLook = transform.GetComponent<CinemachineFreeLook>();
        //TODO: implement in a more flexible manner
        Transform playerTransform = GameObject.Find("CapsulePlayer").transform;
        freeLook.LookAt = playerTransform;
        freeLook.Follow = playerTransform;
    }
}
