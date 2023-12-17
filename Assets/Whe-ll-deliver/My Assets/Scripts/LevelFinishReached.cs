using GD;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelFinishReached : MonoBehaviour
{

    [SerializeField]
    private EmptyGameEvent onLevelFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onLevelFinished.Raise(new Empty());
        }
    }
}
