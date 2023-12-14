using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UISoundPlayer", menuName = "DkIT/Scriptable Objects/Sound/UISoundPlayer")]

public class UIAudioPlayer : ScriptableObject
{
    [SerializeField]
    AudioClip audioClip;

    [SerializeField]
    private SearchableObjectKey audioSourceKey;

    public void ButtonClick()
    {
        GameObject audioSourceObject = SearchableObjects.FindObject(audioSourceKey);
        AudioSource audioSource = audioSourceObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip,1);
    }


}
