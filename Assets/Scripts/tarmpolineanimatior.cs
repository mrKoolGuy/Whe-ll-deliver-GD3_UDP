using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trampolineanimation : MonoBehaviour
{
    [SerializeField]
    private bool isinanimation = false;
    [SerializeField]
    private float timepassed;
    [SerializeField]
    private float framsperseconde = 10;
    [SerializeField]
    voxelanimator nett;

    // Start is called before the first frame update
    public void onColision()
    {
        isinanimation = true;
        timepassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isinanimation)
        {
            if (timepassed < nett.famecount / framsperseconde)
            {

                nett.setframe(Mathf.RoundToInt(timepassed * framsperseconde));
                timepassed += Time.deltaTime;

            }
            else
            {

                isinanimation = false;
                timepassed = 0;
            }

        }
    }
}
