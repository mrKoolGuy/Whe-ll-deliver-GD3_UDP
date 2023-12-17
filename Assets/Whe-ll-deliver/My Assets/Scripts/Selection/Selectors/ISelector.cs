using UnityEngine;

//taken from Niall's examples
namespace GD.Selection
{
    public interface ISelector
    {
        void Check(Ray ray);

        Transform GetSelection();

        RaycastHit GetHitInfo();
    }
}