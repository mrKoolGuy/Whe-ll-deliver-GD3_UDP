using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainMenu;
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
            Time.timeScale = 1.0f;
            gamePaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
            gamePaused = true;
        }
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1.0f;
    }
}