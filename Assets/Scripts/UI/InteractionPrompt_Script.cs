using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPrompt_Script : MonoBehaviour
{
    //[Header("Main Camera")]
    /*[SerializeField]*/ private Camera _mainCam;
    [SerializeField] private Canvas ui_InteractPrompt;
    //[Tooltip("This is where to input the main Camera")]


    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
        Debug.Log($"Camera: {_mainCam}");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    #region ENABLE/DISABLE
    public void Enable()
    {
        ui_InteractPrompt.enabled = true;
        Debug.Log("Enabled");
    }

    public void Disable()
    {
        ui_InteractPrompt.enabled = false;
        Debug.Log("Disabled");
    }
    #endregion
}
