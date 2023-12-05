using GD.Selection;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue_Script : MonoBehaviour
{
    private TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    [SerializeField]
    private float textSpeed;


    private bool gamePaused;
    private int index;


    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        gamePaused = true;
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
    public void StartDialogue(int scene)
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
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextDialogueLine()
    {
        if(index < dialogueLines.Length - 1)
        {
            index ++;
            dialogueText.text = string.Empty;
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
}
