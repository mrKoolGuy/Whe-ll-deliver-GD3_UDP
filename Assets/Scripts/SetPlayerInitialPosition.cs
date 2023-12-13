using Cinemachine;
using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerInitialPosition : MonoBehaviour
{
    [SerializeField]
    private SearchableObjectKey spawnPointKey;

    public void SetInitialPosition()
    {
        Debug.Log("setting player position");
        GameObject spawnPointObject = SearchableObjects.FindObject(spawnPointKey);
        Transform spawnPointTransform = SearchableObjects.FindObject(spawnPointKey).transform;
        Debug.Log($"Hash value of object {spawnPointObject.GetHashCode()}");
        transform.position = spawnPointTransform.position;
        transform.rotation = spawnPointTransform.rotation;
    }
}
