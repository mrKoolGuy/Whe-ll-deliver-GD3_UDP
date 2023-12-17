using UnityEngine;

public class SkyDomeOffsetSetter : MonoBehaviour
{
    [SerializeField] private float offset;
    
    [SerializeField]
    private SearchableObjectKey skyDomeKey;
    void Start()
    {
        SearchableObjects.FindObject(skyDomeKey).GetComponent<ChangeSkyOffset>().SetSkyOffset(offset);
    }
}
