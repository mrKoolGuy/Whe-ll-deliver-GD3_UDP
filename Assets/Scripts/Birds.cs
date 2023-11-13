using UnityEngine;
using Random = UnityEngine.Random;

public class Birds : MonoBehaviour
{

    [SerializeField] private AudioClip birdsFlapping;
    
    //Selects a random tree and starts the AudioSource there.
    //if an oldBirdSpot is given, it makes sure to select another tree
    void FindNewTree(GameObject oldBirdSpot)
    {
        GameObject[] birdSpots = GameObject.FindGameObjectsWithTag("BirdSpot");
        int numberOfBirds = birdSpots.Length;

        GameObject selectedBirds;
        do
        {
            selectedBirds = birdSpots[Random.Range(0, numberOfBirds)];
        } while (numberOfBirds > 1 && selectedBirds == oldBirdSpot);
        
        selectedBirds.GetComponent<AudioSource>().Play();
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
