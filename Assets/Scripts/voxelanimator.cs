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
    public int currentframe { get; private set; }



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
        currentframe = 0;
        famecount = frameList.Count;

    }

    public void setframe(int frametoload)
    {
        if (frametoload != currentframe)
        {
            frametoload = frametoload>= 0?frametoload % famecount: famecount - ((-frametoload)%famecount+1);
            
            frameList[currentframe].SetActive(false);
            frameList[frametoload].SetActive(true);
            currentframe = frametoload;
            
        }

    }

    //To use Animator you need an skrip similar to this.
    /*
    private float vergangeneZeit = 0f;
    private int nextframe;
    void Update()
    {
        // Akkumuliere die vergangene Zeit
        vergangeneZeit += Time.deltaTime;

        // Überprüfe, ob 0,2 Sekunden vergangen sind
        if (vergangeneZeit >= 0.1f)
        {
            nextframe -= 1;
            setframe(nextframe);
            vergangeneZeit = 0f;
        }
    }
    */


}
