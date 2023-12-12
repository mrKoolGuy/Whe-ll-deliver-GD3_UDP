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

        [SerializeField] [Tooltip("Each containing UnityEvent controls one of the stars")]
        private List<UnityEvent<bool>> setStarEnabled;

        [SerializeField] private UnityEvent<string> setDamage;

        [SerializeField] private UnityEvent<string> setTime;

        private void OnEnable()
        {
            Scoring scoring = SearchableObjects.FindObject(scoringSystemKey).GetComponent<Scoring>();
            setDamage?.Invoke(scoring.TotalFallDamage.ToString());
            setTime?.Invoke(TimeSpan.FromSeconds(scoring.PlayDuration).ToString(@"mm\:ss"));

            for (int i = 0; i < setStarEnabled.Count; i++)
            {
                setStarEnabled[i]?.Invoke(scoring.Stars > i);
            }
        }
    }
}
