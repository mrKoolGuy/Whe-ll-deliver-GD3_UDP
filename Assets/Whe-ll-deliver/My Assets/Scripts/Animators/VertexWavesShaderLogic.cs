using Shader.Collision;
using Sirenix.OdinInspector;
using UnityEngine;

public class VertexWavesShaderLogic : MonoBehaviour
{
    [SerializeField]
    private CollisionEffect collision;

    //State values
    private bool inshake;
    private double timestorage = 0;
    private Renderer render;

    //Data is set in DoShake with values from CollisionEffects 
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
        Vector3 p = transform.position;
        render.material.SetVector("_Position", new Vector4(-p.x, -p.y, -p.z, 0));
    }

    [Button]
    //activates the collision animation 
    public void DoShake()
    {
        timestorage = 0;
        inshake = true;
        //get setting from CollisionEffect scriptable object
        shakegraph = collision.getshake();
        offset_Range_X = collision.get_ofset_Range_X();
        offset_Range_Z = collision.get_ofset_Range_Z();
        offset_Range_Y = collision.get_ofset_Range_Y();

        Z_offset = Random.Range(offset_Range_Z.x, offset_Range_Z.y);
        X_offset = Random.Range(offset_Range_X.x, offset_Range_X.y);
        Y_offset = Random.Range(offset_Range_Y.x, offset_Range_Y.y);
    }

    private void Update()
    {
        if(inshake)
        {
            if(timestorage < shakegraph.length) {
                
                float offset = shakegraph.Evaluate((float)timestorage);
                render.material.SetVector("_OfsetBais", new Vector3(X_offset,Y_offset,Z_offset)*offset);
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
