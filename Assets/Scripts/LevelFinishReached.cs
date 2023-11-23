using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishReached : MonoBehaviour
{

    [SerializeField] private ELevel nextLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Do somthing here when level finishes
            string newLevel = nextLevel.ToString();
            SceneManager.LoadScene(1);
            Debug.Log(newLevel);
        }

    }
}
