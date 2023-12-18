using UnityEngine;

namespace Whe_ll_deliver.My_Assets.Scripts.ScriptableObjects.Audio
{
    [CreateAssetMenu(fileName = "VolumeController", menuName = "DkIT/Scriptable Objects/Audio/VolumeController")]
    public class VolumeController : ScriptableObject
    {
        private float oldVolume;
        public void UnmuteAudio()
        {
            // SetVolume(oldVolume);
            AudioListener.pause = false;
        }
    
        public void MuteAudio()
        {
            AudioListener.pause = true;
            // if (AudioListener.volume != 0)
            // {
            //     oldVolume = AudioListener.volume;
            //     SetVolume(0);
            // }
        }

        //sets the volume off the AudioListener has to be between 0 and 1
        public void SetVolume(float volume)
        {
            AudioListener.volume = volume;
        }
    }
}
