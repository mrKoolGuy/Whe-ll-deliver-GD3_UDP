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
    [SerializeField] private Image star1;
    [SerializeField] private Image star2;
    [SerializeField] private Image star3;
    [Tooltip("The TextMeshPro Objects for all the Stars")]
    //[SerializeField] private Sprite fullStar;
    //[SerializeField] private Sprite emptyStar;
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
    //To-Do: Uncomment these lines and remove the Color Changes
    public void StarLost(int stars)
    {
        switch (stars)
        {
            case 2:
                //star3.sprite = emptyStar; 
                star3.color = Color.grey;
                break;
            case 1:
                //star2.sprite = emptyStar;
                star2.color = Color.grey;
                break;
            case 0:
                //star1.sprite = emptyStar;
                star1.color = Color.grey;
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
