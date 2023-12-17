using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class Stars : MonoBehaviour
{
    [SerializeField] [Tooltip("Each containing UnityEvent controls one of the stars")]
    private List<UnityEvent<bool>> setStarEnabled;

    [Button]
    public void SetStars(int numberOfStars)
    {
        for (int i = 0; i < setStarEnabled.Count; i++)
        {
            setStarEnabled[i]?.Invoke(numberOfStars > i);
        }
    }
}
