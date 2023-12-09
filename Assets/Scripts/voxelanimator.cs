using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class voxelanimator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> frameList = new List<GameObject>();
    public int famecount {  get; private set; }
    public int aktuellfame { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < transform.childCount; i++)
        {
            frameList.Add(transform.GetChild(i).gameObject);
        }
        foreach (var frame in frameList)
        {
            frame.gameObject.SetActive(false);
        }

        frameList[0].SetActive(true);
        aktuellfame = 0;
        famecount = frameList.Count;

    }

    public void setframe(int toloadeframe)
    {
        if (toloadeframe != aktuellfame)
        {
            toloadeframe = toloadeframe>= 0?toloadeframe % famecount: famecount - ((-toloadeframe)%famecount+1);
            
            frameList[aktuellfame].SetActive(false);
            frameList[toloadeframe].SetActive(true);
            aktuellfame = toloadeframe;
            
        }

    }


    /* For debug perpose
    private float vergangeneZeit = 0f;
    void Update()
    {
        // Akkumuliere die vergangene Zeit
        vergangeneZeit += Time.deltaTime;

        // Überprüfe, ob 0,2 Sekunden vergangen sind
        if (vergangeneZeit >= 0.1f)
        {
            change -= 1;
            setframe(change);
            vergangeneZeit = 0f;
        }
    }
    */


}
