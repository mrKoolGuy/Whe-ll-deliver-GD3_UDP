using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private Material skyMaterial;

    [SerializeField] private ScriptableObject gameLayout;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
        changeSkyOffset(1);
    }

    public void ShowMainMenu()
    {
        // Show Main Menu
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
    }

    public void changeSkyOffset(float i)
    {
        skyMaterial.mainTextureOffset = new Vector2(i,0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
