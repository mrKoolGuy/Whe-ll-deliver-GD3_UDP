using GD.Selection;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows us to attach multiple responses to a selected object
/// adapted from Nial's code
/// </summary>
public class AdvancedSelectionManager : MonoBehaviour
{
    [SerializeField]
    //[RequireInterface(typeof(ISelectionResponse))]
    [Tooltip("Must Contain an ISelectionResponse")]
    private List<ScriptableObject> selectionResponses;

    private IRayProvider rayProvider;
    private ISelector selector;
    private Transform currentSelection;

    private void Awake()
    {
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();
    }
    
    private void Update()
    {

        Transform oldSelection = currentSelection;

        //create/get ray
        selector.Check(rayProvider.CreateRay());

        //get current selection (cast ray, do tag comparison)
        currentSelection = selector.GetSelection();

        //deselect the oldSelection if there is nothing selected, or another object is selected
        if (currentSelection is null || currentSelection != oldSelection)
        {
            //set de-selected if we were previously selecting an appropriate (i.e., layer, distance) game object
            if (oldSelection is not null)
            {
                foreach (ISelectionResponse selectionResponse in selectionResponses)
                    selectionResponse.OnDeselect(oldSelection);
            }
        }

        if (currentSelection is not null)
        {
            //call all OnSelect handlers
            if(currentSelection != oldSelection)
                foreach (ISelectionResponse selectionResponse in selectionResponses)
                    selectionResponse.OnSelect(currentSelection);
            
            //and call WhileSelected, in every frame where this object is selected
            foreach (ISelectionResponse selectionResponse in selectionResponses)
                selectionResponse.WhileSelected(currentSelection);
        }
    }
}