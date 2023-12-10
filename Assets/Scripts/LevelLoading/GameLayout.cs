using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores data relating to a complete game (i.e. multiple levels)
/// </summary>
/// <see cref="https://blogs.unity3d.com/2020/07/01/achieve-better-scene-workflow-with-scriptableobjects/"/>
namespace GD
{
    [CreateAssetMenu(fileName = "GameLayout", menuName = "DkIT/Scriptable Objects/Game/Layout", order = 1)]
    public class GameLayout : ScriptableObject
    {
        #region Title & Level Layout

        [Header("Title")]
        public string Title;

        #region Level

        [TabGroup("layout_tabs", "Levels", SdfIconType.Diagram2Fill)]
        [Min(0)]
        [Tooltip("Zero-based index in the list of level layouts for the start level in the game (e.g. 0)")]
        public int StartLevel;

        [TabGroup("layout_tabs", "Levels")]
        [Searchable]
        public List<GameLevel> Levels;

        [TabGroup("layout_tabs", "Levels")]
        [Header("Debug")]
        [ReadOnly]
        public bool IsLevelLoaded;

        [TabGroup("layout_tabs", "Levels")]
        [ReadOnly]
        public int CurrentLevel = 0;

        #endregion Level

        #endregion Title & Level Layout

        #region Menu

        [TabGroup("layout_tabs", "Menus", SdfIconType.MenuAppFill)]
        public GameScene MainMenu;

        [TabGroup("layout_tabs", "Menus")]
        public GameScene PauseMenu;

        [TabGroup("layout_tabs", "Menus")]
        public GameScene UIMenu;

        [SerializeField]
        [Tooltip("This event gets called when all components of the level are loaded.")]
        private EmptyGameEvent onLevelLoaded;

        #endregion Menu

        [ContextMenu("Load Level")]
        public void LoadLayout(int levelNr, Action onLevelLoadCompleted)
        {
            if (Levels.Count == 0)
                return;
            CurrentLevel = levelNr;
            AsyncOperationsWatcher watcher = new AsyncOperationsWatcher(() =>
            {
                IsLevelLoaded = true;
                onLevelLoaded.Raise(new Empty());
                onLevelLoadCompleted();
            });
            Levels[levelNr].LoadLevel(watcher);
        }

        [ContextMenu("Unload Level")]
        public void UnloadLayout(Action onLevelUnloadCompleted)
        {
            if (Levels.Count == 0)
                return;

            AsyncOperationsWatcher watcher = new AsyncOperationsWatcher(() =>
            {
                IsLevelLoaded = false;
                onLevelUnloadCompleted();
            });
            Levels[CurrentLevel].UnloadLevel(watcher);
        }

        public void LoadLevelByNumber(int nr) //Loads a specific Level
        {
            if (IsLevelLoaded)
            {
                UnloadLayout(() =>
                {
                    LoadLayout(nr, () => { });
                });
            }
            else
            {
                LoadLayout(nr, () => { });
            }
        }

        public void NextLevel() // Goes to Next Level
        {
            UnloadLayout(() =>
            {
                CurrentLevel++;
                LoadLayout(CurrentLevel + 1, () => { });
            });
        }

        public void RestartLevel() // Restarts the current Level
        {
            // TODO reset state of player or some of doNotDestroyObjects
            UnloadLayout(() =>
            {
                LoadLayout(CurrentLevel, () => { });
            });
        }

        public void NewGame() // Load the first Level
        {
            if (IsLevelLoaded)
            {
                UnloadLayout(() =>
                {
                    LoadLayout(StartLevel, () => { });
                });
            }
            {
                LoadLayout(StartLevel, () => { });
            }
        }

        public void Resume() // Maybe goes away *************************
        {
            UnloadLayout(() =>
            {
                LoadLayout(CurrentLevel, () => { });
            });
        }
    }
}