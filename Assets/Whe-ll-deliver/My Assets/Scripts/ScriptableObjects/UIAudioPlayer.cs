using UnityEngine;

[CreateAssetMenu(fileName = "UIAudioPlayer", menuName = "DkIT/Scriptable Objects/Audio/UIAudioPlayer")]
public class UIAudioPlayer : ScriptableObject
{
    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private SearchableObjectKey mainMenu;

    private AudioSource audioSource;

    public void playAudio()
    {
        if (audioSource != null) audioSource.PlayOneShot(audioClip);
        else
        {
            audioSource = SearchableObjects.FindObject(mainMenu).GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip);
        }
    }
}