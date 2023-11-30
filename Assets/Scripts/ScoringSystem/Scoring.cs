using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ScoringSystem
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] [Range(0.1f, 15)]
        [Tooltip("Score will be decreased by 1 in the here configured interval.\nZero score will be reached after the following time")]
        [HorizontalGroup("interval")]
        private float scoreDecreaseInterval;
    
        [SerializeField][Range(0, MaxScore)]
        [Tooltip("Ignoring damage, three stars are kept during the following time")]
        [HorizontalGroup("threeStars")]
        private int threeStarsScore;
    
        [FormerlySerializedAs("twoStarScore")]
        [SerializeField][Range(0, MaxScore)]
        [Tooltip("Ignoring damage, two stars are kept during the following time")]
        [HorizontalGroup("twoStars")]
        private int twoStarsScore;
    
        [SerializeField][Range(0, MaxScore)]
        [Tooltip("Ignoring damage, one star is kept during the following time")]
        [HorizontalGroup("oneStar")]
        private int oneStarScore;
    
#if UNITY_EDITOR
        private string SecondsToTimeString(float seconds)
        {
            int roundedSeconds = (int)Math.Round(seconds);
            int min = roundedSeconds/60;
            int sec = roundedSeconds%60;

            return $"{min:00}:{sec:00}";
        }
    
        private string ScoreLimitToTime(int scoreLimit)
        {
            return SecondsToTimeString((MaxScore - (scoreLimit - 1)) * scoreDecreaseInterval);
        }
        
        private const int TimeFieldWidth = 50; //width of the time display in the inspector in pixels

        [ShowInInspector]
        [ReadOnly]
        [LabelText("")]
        [HorizontalGroup("interval", Width = TimeFieldWidth)]
        private string ZeroScoreTime => SecondsToTimeString(scoreDecreaseInterval * MaxScore);


        [ShowInInspector] [ReadOnly] [LabelText("")]
        [HorizontalGroup("threeStars", Width = TimeFieldWidth)]
        private string ThreeStarsTimeLimit => ScoreLimitToTime(threeStarsScore);
    
        [ShowInInspector] [ReadOnly] [LabelText("")]
        [HorizontalGroup("twoStars", Width = TimeFieldWidth)]
        private string TwoStarsTimeLimit => ScoreLimitToTime(twoStarsScore);
    
        [ShowInInspector] [ReadOnly] [LabelText("")]
        [HorizontalGroup("oneStar", Width = TimeFieldWidth)]
        private string OneStarTimeLimit => ScoreLimitToTime(oneStarScore);
#endif
        
        [SerializeField] private UnityEvent<int> onScoreChanged;
        [SerializeField] private UnityEvent<int> onStarsChanged;
        [SerializeField] private UnityEvent onZeroScore;
    
        private const int MaxScore = 100;
        //this is the amount of score reduction for the scheduled interval
        private const int ScoreDecreaseBy = 1;

        private int stars = 3;
        private int score;
        
        //this property prevents the score from being set outside its bounds. It also calls events on score or star change.
        private int Score
        {
            get => score;
            set
            {
                int oldScore = score;
                score = Math.Max(0, Math.Min(MaxScore, value));

                if (score != oldScore)
                {
                    onScoreChanged?.Invoke(score);
                    CalcStars();
                    if (score == 0)
                        onZeroScore?.Invoke(); //calls onZeroScore once when it reaches zero the first time, but not if it is set zero repeatedly
                }
            }
        }

        private void Start()
        {
            Score = MaxScore;
            InvokeRepeating(nameof(DecreaseOnTime), 0, scoreDecreaseInterval);
        }

        private void CalcStars()
        {
            int oldStars = stars;
            stars = Score >= threeStarsScore ? 3 : (Score > twoStarsScore ? 2 : (Score > oneStarScore ? 1 : 0));
            if(oldStars != stars)
                onStarsChanged?.Invoke(stars);
        }
        
        private void DecreaseOnTime()
        {
            Score -= ScoreDecreaseBy;
        }
    
        //Based on the sign of the offset, it increments or decrements the score by the given offset.
        //Normally gets called through a GameEventListener in the ScoringSystem object.
        public void AdjustScore(int offset)
        {
            Score += offset;
        }
    }
}
