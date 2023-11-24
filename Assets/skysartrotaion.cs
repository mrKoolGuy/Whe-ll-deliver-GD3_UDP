using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skysartrotaion : MonoBehaviour
{
    [SerializeField]
    float secondforfullrotation =10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, (float)((1 + Time.deltaTime )/ secondforfullrotation), 0);
    }
}
