using UnityEngine;

namespace Whe_ll_deliver.My_Assets.Scripts.SimpleSetters
{
    public class ScoringDisplayActiveSetter: MonoBehaviour
    {
        [SerializeField]
        private SearchableObjectKey scoringSystemHUDKey;

        public void SetScoreDisplayActive(bool active)
        {
            SearchableObjects.FindObject(scoringSystemHUDKey).SetActive(active);            
        }
    }
}