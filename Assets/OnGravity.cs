using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD;

public class OnGravity: MonoBehaviour
{
    [SerializeField]
    SearchableObjectKey playerkey;
    [SerializeField]
    SearchableObjectKey Scoringkey;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody playerRB = SearchableObjects.FindObject(playerkey).GetComponent<Rigidbody>();
        playerRB.useGravity = false;
        // Blog remainig motion in Y 
        playerRB.constraints |= RigidbodyConstraints.FreezePositionY;
        
        SearchableObjects.FindObject(Scoringkey).SetActive(false);
        GameLayout.ResumeTime();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Rigidbody playerRB = SearchableObjects.FindObject(playerkey).GetComponent<Rigidbody>();
        playerRB.useGravity = false;
        // undo Blog remainig motion in Y  
        playerRB.constraints &= ~RigidbodyConstraints.FreezePositionY;
        SearchableObjects.FindObject(Scoringkey).SetActive(true);
    }
}
