using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HUD_Script : MonoBehaviour
{
    #region Fields
    [Header("Progress Bar")]
    private float max = 100.0f;
    [SerializeField] [Tooltip("This is the Image that is used to display the Progress Bar of the Score")]
    private Slider slider;
    
    [Header("Stars")] [SerializeField]
    [Tooltip("The Stars Prefab")]
    private GameObject starsPrefab;
    #endregion

    #region Progress Bar
    public void ScoreChanged(int newScore)
    {
        ChangeFill(newScore);
    }

    private void ChangeFill(int current)
    {
        float fillAmount = current / max;
        slider.value = fillAmount;
    }
    #endregion

    #region Stars
    //TO-DO: Add bell sound effect
    public void StarsChanged(int stars)
    {
        starsPrefab.GetComponent<Stars>().SetStars(stars);
    }  
    #endregion
}
