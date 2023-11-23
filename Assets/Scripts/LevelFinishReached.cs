using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelFinishReached : MonoBehaviour
{

    public UnityEvent OnLevelEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Tell Level Manager to go to next level

            OnLevelEnd?.Invoke();


            // Do somthing here when level finishes

            int thisLevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(thisLevel + 1);


            Debug.Log("Going to level : " + (thisLevel + 1));
        }

    }
}
