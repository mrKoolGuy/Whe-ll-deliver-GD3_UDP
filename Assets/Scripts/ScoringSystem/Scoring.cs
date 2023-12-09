using System;
using GD;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
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
            return TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss");
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

        private GameLevel level;

        public int Stars { get; private set; } = 3;
        private int score;

        // time in seconds since level started to reaching the goal in seconds
        public int TotalFallDamage { get; private set; } = 0;
        public double PlayDuration { get; private set; } = 0;

        private float startTime;

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


        public void OnLevelLoaded(GameLevel level)
        {
            this.level = level;
            ResetScore();
        }

        public void OnLevelFinished(Empty empty)
        {
            PlayDuration = Time.time - startTime;
            if (score > level.highestScore)
                level.highestScore = score;
            if (Stars > level.highestStars)
                level.highestStars = Stars;
            if (PlayDuration < level.fastedPlayDuration || level.fastedPlayDuration == -1)
                level.fastedPlayDuration = PlayDuration;
            if (TotalFallDamage < level.leastDamage || level.leastDamage == -1)
                level.leastDamage = TotalFallDamage;

        }

        private void ResetScore(){
            Score = MaxScore;
            TotalFallDamage = 0;
            startTime = Time.time;
            InvokeRepeating(nameof(DecreaseOnTime), 0, scoreDecreaseInterval);
        }

        private void CalcStars()
        {
            int oldStars = Stars;
            Stars = Score >= threeStarsScore ? 3 : (Score > twoStarsScore ? 2 : (Score > oneStarScore ? 1 : 0));
            if(oldStars != Stars)
                onStarsChanged?.Invoke(Stars);
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
            if (offset < 0) //this would allow a future feature to add store on collectibles without affecting the damage
                TotalFallDamage -= offset;
        }
    }
}
