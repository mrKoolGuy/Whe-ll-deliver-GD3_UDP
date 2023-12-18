using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "DkIT/Scriptable Objects/SearchableObjects/Key")]
[Serializable]
//this is mostly empty, because it just serves as a reference to look stuff up in the dictionary
public class SearchableObjectKey: ScriptableObject
{
    //This just serves the user as description, not used in code
    [SerializeField]
    [MultiLineProperty(4)]
    private string description;
}
