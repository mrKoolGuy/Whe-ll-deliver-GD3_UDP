using System.Collections;
using GD;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Script : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    [SerializeField]
    private float textSpeed;
    [SerializeField]
    private Image headShot;
    [SerializeField]
    private Sprite boss;
    [SerializeField]
    private Sprite postman;
    private bool isBoss;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        GameLayout.PauseTime();

        isBoss = true;
        headShot.sprite = boss;
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
    
    //To Start the Dialogue playing
    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(PrintDialogueLine());
    }

    //To print every dialogue line, char by char
    IEnumerator PrintDialogueLine()
    {
        foreach (char c in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    //To go to the next Dialogue Line, after all characters have been printed
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
            gameObject.SetActive(false);
            //unpause the game, after dialogue is done playing
            GameLayout.ResumeTime();
        }
    }



    //change the sprite of the character whos talking
    private void ChangeCharacter()
    {
        if (isBoss)
        {
            //Change Image to PlayerCharacter
            headShot.sprite = postman;
            isBoss = false;
        }
        else
        {
            //Change Image to Boss
            headShot.sprite = boss;
            isBoss = true;
        }
    }
    
}
