using GD;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelFinishReached : MonoBehaviour
{

    [SerializeField]
    private EmptyGameEvent onLevelFinished;
    
    //Todo: can all be done with above Event
    //public UnityEvent OnLevelEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("next level inc");
            onLevelFinished.Raise(new Empty());
            //TODO: Remove code below it doesn't work with the split scenes. Level Switching shouldn't be implemented here, but just somewhere with a listener to the above event
            
            //Tell Level Manager to go to next level

            //OnLevelEnd?.Invoke();
        }

    }
}
