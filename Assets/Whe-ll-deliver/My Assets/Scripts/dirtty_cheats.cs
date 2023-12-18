using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD;

public class dirtty_cheats : MonoBehaviour
{
    [SerializeField]
    string Aktivat_by_key_down;
    [SerializeField]
    SearchableObjectKey Target;
    [SerializeField]
    private GameObject subject;
    // Start is called before the first frame update
    void Start()
    {
        if (subject == null)
        {
            if (Target != null)
            {
                subject = SearchableObjects.FindObject(Target);
            } 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (subject != null)
        {
            if (Input.GetKeyDown(Aktivat_by_key_down))
            {
                subject.transform.position = gameObject.transform.position;
                subject.transform.rotation = gameObject.transform.rotation;
            }
        }
    }
}
