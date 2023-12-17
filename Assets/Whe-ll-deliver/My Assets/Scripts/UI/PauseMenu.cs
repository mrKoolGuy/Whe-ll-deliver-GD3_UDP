using GD;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private SearchableObjectKey mainMenu;
    [SerializeField]
    private GameLayout gameLayout;

    private bool gamePaused;

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        // Gets the input to check if esc is pressed
        if (Input.GetKeyDown(KeyCode.Escape))SwitchPause();
    }

    public void SwitchPause()
    {
        // Checks if game is paused if not unpuases it if not paused pauses game
        if (gamePaused)
        {
            pauseMenu.SetActive(false);
            GameLayout.ResumeTime();
            gamePaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            GameLayout.PauseTime();
            gamePaused = true;
        }
    }

    public void GoMainMenu()
    {
        //Time.timeScale = 1.0f;
        GameObject mainMenuObj = SearchableObjects.FindObject(mainMenu);
        MainMenu script = mainMenuObj.GetComponent<MainMenu>();
        script.ShowMainMenu();
        gameLayout.UnloadLayout(()=>{ });
    }
}