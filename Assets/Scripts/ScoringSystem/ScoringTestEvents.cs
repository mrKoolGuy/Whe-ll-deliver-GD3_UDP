using UnityEngine;

//TODO: delete when UI for the score is implemented
public class ScoringTestEvents : MonoBehaviour
{
    public void HandleZeroStars()
    {
        Debug.Log("Zero score reached");
    }

    public void HandleStarsChanged(int stars)
    {
        Debug.Log($"Stars changed to: {stars}");
    }

    public void HandleScoreChanged(int score)
    {
        Debug.Log($"Score changed to: {score}");
    }
}
