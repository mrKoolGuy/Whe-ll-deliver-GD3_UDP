using UnityEngine;

//taken from Niall's examples
namespace GD.Selection
{
    public interface IRayProvider
    {
        Ray CreateRay();
    }
}
