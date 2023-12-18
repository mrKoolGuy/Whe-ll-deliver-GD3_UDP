using System.Collections.Generic;
using UnityEngine;

namespace Whe_ll_deliver.My_Assets.Scripts
{
    public class ChangeMusicOnPlayerHeight : MonoBehaviour
    {
        [SerializeField]
        private SearchableObjectKey spawnPointKey;

        [SerializeField]
        private SearchableObjectKey playerKey;
        
        [SerializeField]
        private List<AudioSource> instruments;

        private GameObject spawnPoint;
        private GameObject player;

        [SerializeField]
        [Tooltip("Distance between two elevations")]
        private float stepHeight;
        [SerializeField]
        [Tooltip("reduces required height to turn on track")]
        private float tolerance;
        
        public void StartMusic()
        {
            spawnPoint = SearchableObjects.FindObject(spawnPointKey);
            player = SearchableObjects.FindObject(playerKey);

            //mute all tracks except the first one
            for (int i = 1; i < instruments.Count; i++)
                instruments[i].mute = true;
            instruments.ForEach((source) => source.Play());
        }
        
        private void FixedUpdate()
        {
            if (player is not null && spawnPoint is not null)
            {
                float relativeHeight= player.transform.position.y - spawnPoint.transform.position.y;

                //this mutes/unmutes the different Tracks depending on the height of the player
                //first instrument is always playing
                //other instruments are turned on when a minimum height is reached
                for (int i = 1; i < instruments.Count; i++)
                    instruments[i].mute = relativeHeight < (i * stepHeight - 0.1);
            }
        }
    }
}
