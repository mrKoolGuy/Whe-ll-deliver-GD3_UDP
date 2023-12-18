using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class ChangeSkyOffset : MonoBehaviour
{

    [SerializeField]
    private SearchableObjectKey mainCameraKey;
    
    private Material material;
    private Texture2D texture2dCPU;
    
    private const int HorizonY = 12; //measured on the texture in Gimp. The row with this y index in the texture contains the colors you see along the horizon.
    
    private void Start()
    {
        material = GetComponent<Renderer>().material;
        if (Application.platform == RuntimePlatform.LinuxPlayer)
        {
            //this is the stored texture of the skybox, normally only accessible in the GPU
            Texture textureGPU = material.mainTexture;

            //this creates a new texture which we can access from the CPU
            texture2dCPU = new Texture2D(textureGPU.width, textureGPU.height, textureGPU.graphicsFormat, TextureCreationFlags.DontInitializePixels);

            //copy the data from the GPU into the CPU
            Graphics.CopyTexture(textureGPU, 0, 0, 0, 0, textureGPU.width, textureGPU.height, texture2dCPU, 0, 0, 0, 0);
        }
    }

    private Color GetColorAtOffset(float offset)
    {
        if (Application.platform == RuntimePlatform.LinuxPlayer)
        {
            //the offset goes from -0.5 on the left edge to 0.5 on the right edge. The pixels go from 0 to texture2dCPU.width
            int xPixelIndex = Math.Clamp((int)(texture2dCPU.width / 2.0 + offset * texture2dCPU.width), 0, texture2dCPU.width);
            return texture2dCPU.GetPixel(xPixelIndex, HorizonY);
        }
        return new Color(171,217,228);
    }
    
    //offset has to be between -0.5 and 0.5 and controls the look of the sky. 0 is midday, the limits in both directions are a dark sky
    [Button]
    public void SetSkyOffset(float offset)
    {
        if (offset < -0.5 || offset > 0.5)
            throw new ArgumentOutOfRangeException(nameof(offset), "The offset has to be between -0.5 and 0.5");
        
        material.mainTextureOffset = new Vector2(offset,material.mainTextureOffset.y);
        SearchableObjects.FindObject(mainCameraKey).GetComponent<Camera>().backgroundColor = GetColorAtOffset(offset);
    }
}
