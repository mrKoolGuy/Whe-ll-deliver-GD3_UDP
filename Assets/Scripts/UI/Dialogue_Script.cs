using GD.Selection;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue_Script : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    [SerializeField]
    private float textSpeed;
    [SerializeField]
    private Image headShot;
    private bool isBoss;

    private bool gamePaused;
    private int index;


    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        gamePaused = true;
        //Does this Pause?
        Time.timeScale = 0.0f;

        isBoss = true;
        StartDialogue();

        //This is debug, remove later
        headShot.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grab"))
        {
            if(dialogueText.text == dialogueLines[index])
            {
                nextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];
            }
        }
    }

    //To-Do: Call StartDialogue in another script
    public void StartDialogue()
    {
        index = 0;
        //dialogueLines = dialoguePerLevel[scene];
        StartCoroutine(PrintDialogueLine());
    }

    IEnumerator PrintDialogueLine()
    {
        foreach (char c in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    void nextDialogueLine()
    {
        //Check if this IF is correct
        if(index < dialogueLines.Length - 1)
        {
            index ++;
            dialogueText.text = string.Empty;
            ChangeCharacter();
            StartCoroutine(PrintDialogueLine());
        }
        else
        {
            Unpause();
            gameObject.SetActive(false);
        }
    }

    public void Unpause()
    {
        // Checks if game is paused if not unpuases it if not paused pauses game
        if (gamePaused)
        {
            Time.timeScale = 1.0f;
            gamePaused = false;
        }
    }

    private void ChangeCharacter()
    {
        if (isBoss)
        {
            //Change Image to PlayerCharacter
            headShot.color = Color.blue;
            isBoss = false;
        }
        else
        {
            //Change Image to Boss
            headShot.color = Color.red;
            isBoss = true;
        }
    }
    
}
