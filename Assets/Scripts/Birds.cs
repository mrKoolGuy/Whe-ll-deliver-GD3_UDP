using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Birds : MonoBehaviour
{

    [SerializeField] private AudioClip birdsFlapping;
    
    //Selects a random tree and starts the AudioSource there.
    //It makes sure to select a tree that has no birds playing already and tries to avoid the tree the birds where just fleeing from.
    void FindNewTree(GameObject oldBirdSpot)
    {
        GameObject[] birdSpots = GameObject.FindGameObjectsWithTag("BirdSpot");

        if (birdSpots.Length == 1)
        {
            //if there is only one tree in the level, continue playing the bird sounds there
            birdSpots[0].GetComponent<AudioSource>().Play();
        } else if (birdSpots.Length > 1)
        {
            List<GameObject> freeBirdSpots = birdSpots.ToList().FindAll(bs => (!bs.GetComponent<AudioSource>().isPlaying) && bs != oldBirdSpot);
            int numberOfBirdSpots = freeBirdSpots.Count;

            if (numberOfBirdSpots > 0)
                freeBirdSpots[Random.Range(0, numberOfBirdSpots)].GetComponent<AudioSource>().Play();
        }
    }
    
    void Start()
    {
        FindNewTree(null);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            GameObject birds = other.gameObject.transform.parent.Find("Birds").gameObject;
            AudioSource audioSource = birds.GetComponent<AudioSource>();
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                AudioSource.PlayClipAtPoint(birdsFlapping, birds.transform.position);
                FindNewTree(birds);
            }
        }
    }
}
