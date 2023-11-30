using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GD.Selection
{
    //This selection response allows the player to select an object with a key and drag or push it with him.
    //It also signal the state of the object to the user with different materials.
    [CreateAssetMenu(fileName = "SO_GrabRigidbodySelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/InteractPrompt")]
    [Serializable]
    public class SO_UIInteractPrompt : ScriptableObject, ISelectionResponse
    {

        [SerializeField] private InteractionPrompt_Script ui_Interact;
        //True whenever the player grabs something, which means the grabbed object can be pushed or pulled

        public void OnSelect(Transform transform)
        {
            ui_Interact.Enable();
            Debug.Log("Selected");
        }

        public void WhileSelected(Transform transform)
        {
            //This function is not being used, because I figured that I could solve the problem differently, or rather, I MUST solve the problem differently. 
            //Well if I didn't do it here, then where did I do it? 
            //Well thats the question now isn't it. 
            //I could keep this a mystery, but why bother? In the end, this is just one small diversion from our path in life, that will inevitably lead to an
            //answer. And while it may not be the one answer we wanted or expected, in the end, making this a scavenger hunt would just be a round about way
            //to waste more of our precious time, for a potentially underwhelming answer. 
            //Is that really worth it?
            //Yes.
            //Because that is what life is all about. Asking yourself questions, and being scared of receiving potentially underwhelming answers.
            //But with every answer, every subsequent question becomes easier to answer. Every scavenger hunt can only truly waste your time,
            //if you consider it to be useless to the overall arc that is your life. And beauty is, because you can constantly ask yourself new questions,
            //and will always continue asking questions in the future, you might never know, if something is truly useless,
            //and can therefor be considered a waste of time. So yeah, keep asking questions, to yourself, to anyone really.
            //Don't be scared of receiving an answer. 
            //FUN FACT: Did you know that humans are the only living species to have ever been observed asking a question? It's Crazy!
            //No other animal has the intelligence to understand, that another living being might have information that would benefit it's own survival.
            //We are the only animals that can understand that. I think that's very beautiful.
            //And no, a monkey saying "Can I have banana?" with buttons or gestures, does not count as a question. Because while in Language, a question is merely
            //defined by, ending the sentence with a question mark, "Can I have a banana?" is not a real question, as it is more of a "polite demand".
            //Because if you answer "No" to that question, the monkey will be upset & confused. Usually when they ask this, btw the code for While Selected is
            //in the IneractionPrompt_Script in the WhileSelected Method after the if(!grabbing) check, it is simply a way to get to a banana. So if you say "No",
            //the Pavlov reaction of the Monkey will still trigger, but they get nothing in return, which leads to confusion. 
            //The reason I am writing this epic here, is because I HAD to include this function, to comply with the format of the Interface.
            //Was this a waste of time? 
            //No.
            //I already made Moritz smile while writing this, and I love to make people smile. So I hope it made you smile too.
            //Because then this scavenger hunt was not a waste of time.
        }

        public void OnDeselect(Transform transform)
        {
            ui_Interact.Disable();
            Debug.Log("Deselected");
        }
    }
}