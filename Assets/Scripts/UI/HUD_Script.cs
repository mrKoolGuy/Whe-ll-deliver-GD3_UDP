using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Script : MonoBehaviour
{
    #region Fields
    [Header("Progress Bar")]
    private float max = 100.0f;
    [SerializeField] private Slider slider;
    [Tooltip("This is the Image that is used to display the Progress Bar of the Score")]

    [Header("Stars")]
    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;
    [Tooltip("The TextMeshPro Objects for all the Stars")]
    #endregion

    #region Progress Bar
    public void ScoreChanged(int newScore)
    {
        ChangeFill(newScore);
        DebugScoreChanged(newScore);
    }

    private void ChangeFill(int current)
    {
        float fillAmount = current / max;
        slider.value = fillAmount;
        DebugFillAmountChanged(slider.value);
    }
    #endregion

    #region Stars
    //TO-DO: Add bell sound effect
    public void StarLost(int stars)
    {
        switch (stars)
        {
            case 2:
                star3.SetActive(false); 
                break;
            case 1:
                star2.SetActive(false);
                break;
            case 0:
                star1.SetActive(false);
                break;
        }
            
    }
    #endregion

    #region TESTING
    private void Update()
    {
        //ChangeFill();
    }
    public void DebugScoreChanged(int score)
    {
        Debug.Log($"Score changed to: {score}");
    }
    public void DebugFillAmountChanged(float fillAmount)
    {
        Debug.Log($"FillAmount changed to: {fillAmount}");
    }
    #endregion
}
