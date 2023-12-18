using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScoringSystem
{
    public class SetScoreValues : MonoBehaviour
    {
        [SerializeField]
        private SearchableObjectKey scoringSystemKey;

        [SerializeField] [Tooltip("Containing a reference to the stars prefab that is included in the End Level UI")]
        private GameObject starsPrefab;

        [SerializeField] private UnityEvent<string> setDamage;

        [SerializeField] private UnityEvent<string> setTime;

        private void OnEnable()
        {
            Scoring scoring = SearchableObjects.FindObject(scoringSystemKey).GetComponent<Scoring>();
            setDamage?.Invoke(scoring.TotalFallDamage.ToString());
            setTime?.Invoke(TimeSpan.FromSeconds(scoring.PlayDuration).ToString(@"mm\:ss"));

            starsPrefab.GetComponent<Stars>().SetStars(scoring.Stars);
        }
    }
}
