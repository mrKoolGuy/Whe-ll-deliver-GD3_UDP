using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Colision
{
    [CreateAssetMenu(fileName = "AudioBehaviour", menuName = "DkIT/Scriptable Objects/Behaviours/AudioBehaviour")]

    public class AudioBehaviour : ScriptableObject
    {
        [SerializeField]
        [Tooltip("Each time a sound is played, one random one is selected out of this list")]
        public List<AudioClip> sounds;
    
        [DoNotSerialize]
        private readonly Random rnd = new();
        
        public void PlayRandomSound(Vector3 position)
        {
            if (sounds.Count > 0)
            {
                AudioSource.PlayClipAtPoint(sounds[rnd.Next(sounds.Count)], position);
            }
        }
        
    }
}