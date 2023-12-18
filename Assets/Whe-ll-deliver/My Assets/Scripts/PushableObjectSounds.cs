using UnityEngine;
using AudioBehaviour = Colision.AudioBehaviour;

public class PushableObjectSounds : MonoBehaviour
{
    [SerializeField]
    private AudioBehaviour pickupAudioBehaviour;

    [SerializeField]
    private AudioBehaviour setDownAudioBehaviour;
    
    public void OnPickup()
    {
        pickupAudioBehaviour.PlayRandomSound(transform.position);
    }

    public void OnSetDown()
    {
        setDownAudioBehaviour.PlayRandomSound(transform.position);
    }
}
