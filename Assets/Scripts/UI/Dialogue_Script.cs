using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue_Script : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float textSpeed;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
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

    void StartDialogue()
    {
        index = 0;
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
            gameObject.SetActive(false);
        }
    }
}
