using System.Collections;
using System.Collections.Generic;
using GD;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionPrompt_Script : MonoBehaviour
{
    [SerializeField] [Tooltip("This is the key to lookup the main Camera")]
    private SearchableObjectKey mainCameraKey;
    
    [SerializeField] private Canvas ui_InteractPrompt;

    private GameObject _mainCam;

    public void OnLevelLoaded(Empty empty)
    {
        _mainCam = SearchableObjects.FindObject(mainCameraKey);
        Debug.Log($"Camera: {_mainCam}");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_mainCam)
        {
            var rotation = _mainCam.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }
    }

    #region ENABLE/DISABLE
    public void Enable()
    {
        ui_InteractPrompt.enabled = true;
    }

    public void Disable()
    {
        ui_InteractPrompt.enabled = false;
    }
    #endregion
}
