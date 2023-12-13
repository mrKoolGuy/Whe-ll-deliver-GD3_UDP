using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangeMaterialBySelectionChildren : MonoBehaviour
{
    [SerializeField]
    private GameObject OnGameObject;
    [SerializeField]
    private Material onSelectMaterial;

    [SerializeField]
    private Material onPickupMaterial;
    [SerializeField]
    private Material onDefault;
    
    private Renderer renderer;

    private int oldstatus;
    selectstatus selectstatus;
    // Start is called before the first frame update
    void Start()
    {
        oldstatus = 0;
        selectstatus = transform.GetComponent<selectstatus>();
        renderer = OnGameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (selectstatus.startus != oldstatus)
        {
            oldstatus = selectstatus.startus;
            if (oldstatus==1)
            {
                renderer.material = onSelectMaterial;
            }
            else if (oldstatus == 2)
            {
                renderer.material = onPickupMaterial;
            }
            else
            {
                renderer.material = onDefault;
            }

        }
    }
}
