using System;
using System.Collections.Generic;
using GD;
using UnityEngine;
using UnityEngine.Serialization;

public class DisplayHighScore : MonoBehaviour
{
    [SerializeField]
    private GameLevel level;

    [SerializeField] private List<GameObject> emptyStars;
    
    private void OnEnable()
    {
        Stars starsScript = GetComponent<Stars>(); 
        
        //only display the empty stars when level was already played
        emptyStars.ForEach((star) => star.SetActive(level.highestStars >= 0));
        
        //set the stars. If highScore is -1 for unplayed, all the fullStars are automatically deactivated
        starsScript.SetStars(level.highestStars);
    }
}
