using Shader.colsion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertex_waves_shader_logic : MonoBehaviour
{
    //publich velue for aktive the collusion animaton 
    [SerializeField]
    public bool doshake;

    [SerializeField]
    collusioneffect colision;

    //Values tate 
    private bool inshake;
    private double timestorage = 0;
    private Renderer render;

    //Data tath is sorte in collusioneffect 
    private AnimationCurve shakegraph;
    private Vector2 offset_Range_X;
    private Vector2 offset_Range_Y;
    private Vector2 offset_Range_Z;
    private float X_offset = 0;
    private float Y_offset = 0;
    private float Z_offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        Vector3 r = transform.eulerAngles;
        render.material.SetVector("_Rotation", new Vector4(-r.x,-r.y,-r.z,0));
    }

    private void Update()
    {
        if (doshake)
        {
            timestorage = 0;
            inshake = true;
            doshake = false;
            //get setting from Skribel objekt
            shakegraph = colision.getshake();
            offset_Range_X = colision.get_ofset_Range_X();
            offset_Range_Z = colision.get_ofset_Range_Z();
            offset_Range_Y = colision.get_ofset_Range_Y();

            Z_offset = Random.Range(offset_Range_Z.x, offset_Range_Z.y);
            X_offset = Random.Range(offset_Range_X.x, offset_Range_X.y);
            Y_offset = Random.Range(offset_Range_Y.x, offset_Range_Y.y);

        }

        if(inshake)
        {
            if(timestorage < shakegraph.length) {
                
                float ofset = shakegraph.Evaluate((float)timestorage);
                render.material.SetVector("_OfsetBais", new Vector3(X_offset,Y_offset,Z_offset)*ofset);
                timestorage += Time.deltaTime;

            }
            else
            {
                timestorage = 0;
                inshake = false;
            }
            
        }
    }

}
