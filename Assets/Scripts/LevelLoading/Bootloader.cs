using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GD
{
    /// <summary>
    /// Loads core game object that persists across scenes and the game layout as specified in the ScriptableObject
    /// </summary>
    ///  [ExecuteAlways]
    public class Bootloader : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Contains the levels, scenes, objectives, and UI data to load the game")]
        private GameLayout gameLayout;

        [SerializeField]
        [Tooltip("Spawns once to load core managers and persists between scenes")]
        private GameObject[] corePersistentPrefabs = null;

        [SerializeField]
        [Tooltip("This event gets called when all components of the level are loaded.")]
        private EmptyGameEvent onLevelLoaded;
        
        private bool isLoaded = false;
        
        private void Start()
        {
            //don't destroy if we are running the game (i.e. not in Edit mode)
            //    if (Application.isPlaying)
            DontDestroyOnLoad(this);

            //do we have core system prefabs?
            if (corePersistentPrefabs == null)
                throw new ArgumentNullException("persistentObjectPrefab has not been set in bootloader!");

            if (isLoaded)
                return;

            //load all the core system objects (camera, managers etc)
            LoadPersistentObjectPrefab();

            //load the start level in the game layout SO file
            LoadGameLayout();
        }

        private void LevelLoaded()
        {
            isLoaded = true;
            
            if(onLevelLoaded)
                onLevelLoaded.Raise(new Empty());
        }

        private void LoadGameLayout()
        {
            if(gameLayout)
                gameLayout.LoadLayout(LevelLoaded);
        }

        private void LoadPersistentObjectPrefab()
        {
            foreach (var corePrefab in corePersistentPrefabs)
            {
                //instantiate and dont destroy if we load a new scene (i.e. persist across scenes)
                var instance = Instantiate(corePrefab);

                //set name
                instance.name = corePrefab.name;

                //dont destroy if we are running the game (i.e. not in Edit mode) and load a new scene (i.e. persist across scenes)
                //      if (Application.isPlaying)
                DontDestroyOnLoad(instance);
            }
        }

        // This function is called when the MonoBehaviour will be destroyed
        private void OnDestroy()
        {
            if(gameLayout)
                gameLayout.UnloadLayout();
        }
    }
}