using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private SearchableObjectKey skyDomeKey;

    [SerializeField]
    private float initialSkyDomeOffset = 0;
    
    private ChangeSkyOffset skyChanger;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
        ChangeSkyOffset(initialSkyDomeOffset);
    }

    public void ShowMainMenu()
    {
        // Show Main Menu
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
    }

    public void ChangeSkyOffset(float i)
    {
        SearchableObjects.FindObject(skyDomeKey).GetComponent<ChangeSkyOffset>().SetSkyOffset(i);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
