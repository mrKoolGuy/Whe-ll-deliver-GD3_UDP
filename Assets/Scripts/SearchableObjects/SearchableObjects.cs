using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

//Attach this script to any Object you want to find during playtime.
//To lookup objects use SearchableObjects.StoredObjects["your_key"];
public class SearchableObjects: MonoBehaviour
{
    [ShowInInspector][ReadOnly]
    [Tooltip("These are all the SearchableObjects currently findable with the static method FindObject")]
    private static readonly Dictionary<SearchableObjectKey, GameObject> StoredObjects = new();
    
    [SerializeField]
    [Tooltip("This is the key to look this object up in the dictionary of the SearchableObjects")]
    private SearchableObjectKey key;


    public static GameObject FindObject(SearchableObjectKey key)
    {
        if (key == null)
            throw new ArgumentNullException(paramName: nameof(key),
                "You cannot search the SearchableObjects with a key that's null! Did you set the key to an instance of SearchableObjectKey?");
        
        if (!StoredObjects.TryGetValue(key, out var foundGameObject))
            throw new ArgumentException($"No SearchableObject found with the given key {key.name}, did you register it by attaching the script SearchableObjects to the object you want to find and set the key?");

        return foundGameObject;
    }
    
    private void OnEnable()
    {
        if (!key)
            throw new ArgumentNullException(paramName: nameof(key), message: "The key inside the SearchableObjects script has to be set to an instance of a SearchableObjectKey, otherwise this object won't be findable in the SearchableObjects Dictionary");
        StoredObjects[key] = gameObject;
    }

    private void OnDisable()
    {
        if (!key)
            throw new ArgumentNullException(paramName: nameof(key), message: "The key inside the SearchableObjects script has to be set to an instance of a SearchableObjectKey, otherwise this object can't be removed from the SearchableObjects Dictionary");
        StoredObjects.Remove(key);
    }
}
