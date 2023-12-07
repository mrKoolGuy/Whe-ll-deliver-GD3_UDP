using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Attach this script to any Object you want to find during playtime.
//To lookup objects use SearchableObjects.StoredObjects["your_key"];
public class SearchableObjects: MonoBehaviour
{
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
            throw new ArgumentException("No SearchableObject found with the given key, did you register it by attaching the script SearchableObjects to the object you want to find and set the key?");

        return foundGameObject;
    }
    private void Start()
    {
        if (!key)
            throw new ArgumentNullException(paramName: nameof(key), message: "The key inside the SearchableObjects script has to be set to an instance of a SearchableObjectKey, otherwise this object won't be findable in the SearchableObjects Dictionary");
        StoredObjects.Add(key, gameObject);
    }
}
