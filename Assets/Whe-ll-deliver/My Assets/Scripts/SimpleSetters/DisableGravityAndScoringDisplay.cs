using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD;
using UnityEngine.Serialization;

public class DisableGravityAndScoringDisplay: MonoBehaviour
{
    [SerializeField]
    SearchableObjectKey playerkey;
    [FormerlySerializedAs("ScoringHUDkey")] [FormerlySerializedAs("Scoringkey")] [SerializeField]
    SearchableObjectKey ScoringHUDKey;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody playerRB = SearchableObjects.FindObject(playerkey).GetComponent<Rigidbody>();
        playerRB.useGravity = false;
        // Blog remainig motion in Y 
        playerRB.constraints |= RigidbodyConstraints.FreezePositionY;
        
        SearchableObjects.FindObject(ScoringHUDKey).SetActive(false);
        GameLayout.ResumeTime();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Rigidbody playerRB = SearchableObjects.FindObject(playerkey).GetComponent<Rigidbody>();
        playerRB.useGravity = true;
        // undo Blog remainig motion in Y  
        playerRB.constraints &= ~RigidbodyConstraints.FreezePositionY;
    }
}
