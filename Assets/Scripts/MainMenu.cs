using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    public void StartGame()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");

    }

    public void ShowCreditsMenu()
    {
        // Show Credits Menu
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        // Show Main Menu
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        // Quit Game
        Application.Quit();
    }
}
