using System;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores data relating to a level comprised of multiple scenes
/// </summary>
/// <see cref="https://blogs.unity3d.com/2020/07/01/achieve-better-scene-workflow-with-scriptableobjects/"/>
namespace GD
{
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/Level", order = 2)]
    public class GameLevel : ScriptableGameObject
    {
        [TabGroup("tab1", "Scenes", SdfIconType.PieChartFill)]
        [Searchable]
        public List<GameScene> Scenes;

        public int highestScore = -1;
        public int highestStars = -1;
        public int leastDamage = -1;
        
        [HorizontalGroup("fastestPlayDuration")]
        public double fastedPlayDuration = 0; //in seconds
        [ShowInInspector] [ReadOnly] [LabelText("")]
        [HorizontalGroup("fastestPlayDuration", Width = 50)]
        public string FastedPlayDurationString => TimeSpan.FromSeconds(fastedPlayDuration).ToString(@"mm\:ss");


        [Button]
        public void ResetHighScore()
        {
            highestScore = -1;
            highestStars = -1;
            leastDamage = -1;
            
            fastedPlayDuration = 0;
        }
        
        
        public void LoadLevel(AsyncOperationsWatcher watcher)
        {
            foreach (GameScene scene in Scenes)
                scene.LoadScene(watcher);
        }

        public void UnloadLevel(AsyncOperationsWatcher watcher)
        {
            foreach (GameScene scene in Scenes)
                scene.UnloadScene(watcher);
        }
    }
}