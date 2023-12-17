using UnityEngine;

//adapted from Niall's code
namespace GD.Selection
{
    public interface ISelectionResponse
    {
        void OnSelect(Transform transform);

        //Gets called in every frame where something is selected.
        //This includes the first frame where the object gets selected
        void WhileSelected(Transform transform);

        void OnDeselect(Transform transform);
    }
}